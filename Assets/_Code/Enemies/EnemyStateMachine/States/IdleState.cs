using Assets._Code.Enemies;
using UnityEngine;

namespace Assets.Scripts.BehaviourStates
{
    public class IdleState : IBehaviourState
    {
        private BehaviourStateMachine _stateMachine;
        private EnemyBehaviour _agentContext;

        private EnemyPerception _perception;

        public IdleState(EnemyBehaviour agentContext, BehaviourStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _agentContext = agentContext;

            _perception = _agentContext.Perception;
        }

        public void Enter()
        {
            _agentContext.SetTarget(null);
        }

        public void Handle()
        {
            foreach (var enemy in _perception.DetectedCharacters)
            {
                if (enemy.CompareTag("Player") == true)
                {
                    _agentContext.SetTarget(enemy);
                    _stateMachine.Enter<ChaseState>();
                    return;
                }
            }
        }

        public void Exit()
        {
            
        }
    }
}