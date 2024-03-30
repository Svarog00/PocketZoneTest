using Assets._Code.Characters;
using Assets._Code.Enemies;
using UnityEngine;

namespace Assets.Scripts.BehaviourStates
{
    public class EngageState : IBehaviourState
    {
        private EnemyAttack _attack;

        private BehaviourStateMachine _stateMachine;
        private EnemyBehaviour _agentContext;

        public EngageState(EnemyBehaviour agentContext, BehaviourStateMachine stateMachine)
        {
            _agentContext = agentContext;
            _stateMachine = stateMachine;
            
            _attack = _agentContext.gameObject.GetComponentInChildren<EnemyAttack>();
        }

        public void Enter()
        {

        }

        public void Handle()
        {
            if (Vector2.Distance(_agentContext.transform.position, _agentContext.Target.transform.position) > _attack.AttackDistance)
            {
                _stateMachine.Enter<ChaseState>();
                return;
            }

            _attack.Attack();
        }

        public void Exit()
        {

        }
    }
}