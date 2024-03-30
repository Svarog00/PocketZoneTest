using UnityEngine;

namespace Assets._Code.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;

        private bool _faceRight = false;

        private Vector3 _direction;

        private void Update()
        {
            var translation = _direction * _speed * Time.deltaTime;

            _transform.Translate(translation);
        }

        public void SetDirection(Vector3 direction)
        {
            SetDirection(direction.x, direction.y);


        }

        public void SetDirection(float x, float y)
        {
            _direction.x = x;
            _direction.y = y;

            SetSpriteDirection(_direction);
        }

        private void SetSpriteDirection(Vector2 direction)
        {
            if (direction.x > 0 && _faceRight == true)
            {
                Flip();
            }
            if (direction.x < 0 && _faceRight == false)
            {
                Flip();
            }
        }

        private void Flip() //turn left or right depends on player position
        {
            _faceRight = !_faceRight;
            Vector3 Scaler = gameObject.transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
}