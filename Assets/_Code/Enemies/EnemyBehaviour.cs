using Assets._Code.Characters;
using Assets.Scripts.BehaviourStates;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Code.Enemies
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _chaseTimeOut;
        
        [SerializeField] private EnemyPerception _perception;
        [SerializeField] private CharacterMovement _characterMovement;

        private BehaviourStateMachine _behaviourStateMachine;

        private GameObject _target;

        public float ChaseTimeOut => _chaseTimeOut;
        public GameObject Target => _target;
        public EnemyPerception Perception => _perception;

        private void Awake()
        {
            _behaviourStateMachine = new BehaviourStateMachine();
            _behaviourStateMachine.States = new Dictionary<System.Type, IBehaviourState>
            {
                [typeof(IdleState)] = new IdleState(this, _behaviourStateMachine),
                [typeof(ChaseState)] = new ChaseState(this, _behaviourStateMachine),
                [typeof(EngageState)] = new EngageState(this, _behaviourStateMachine),
            };

            _behaviourStateMachine.Enter<IdleState>();
        }

        private void Update()
        {
            _behaviourStateMachine.Work();
        }

        public void SetTarget(GameObject target)
            => _target = target;
    }
}