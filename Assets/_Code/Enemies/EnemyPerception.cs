using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Enemies
{
    public class EnemyPerception : MonoBehaviour
    {
        [SerializeField] private float _visionRadius;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private List<string> _enemiesTags;

        private List<GameObject> _detectedCharacters = new List<GameObject>();

        public float VisionDistance => _visionRadius;
        public IEnumerable<GameObject> DetectedCharacters => _detectedCharacters;

        private void Awake()
        {
            _visionRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ProcessNewDetection(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            ProcessLostDetection(collision);
        }

        private void ProcessNewDetection(Collider2D enemy)
        {
            if (_enemiesTags.Contains(enemy.tag))
            {
                _detectedCharacters.Add(enemy.gameObject);
            }
        }

        private void ProcessLostDetection(Collider2D enemy)
        {
            if (_enemiesTags.Contains(enemy.tag))
            {
                _detectedCharacters.Remove(enemy.gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _visionRadius);
        }
    }
}