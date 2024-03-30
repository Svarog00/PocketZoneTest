using Assets._Code.Characters;
using Assets._Code.Enemies;
using UnityEngine;

namespace Assets.Scripts.BehaviourStates
{
    public class ChaseState : IBehaviourState
	{
        private const float PlayerPositionDifference = 0.1f;

        private HealthController _playerHP;

        private CharacterMovement _movement;
		private EnemyAttack _enemyAttack;

		private EnemyBehaviour _agentContext;
        private EnemyPerception _perception;
        private BehaviourStateMachine _stateMachine;
        
		private float _elapsedTime = 0f;

        public ChaseState(EnemyBehaviour agentContext, BehaviourStateMachine stateMachine)
        {
			_agentContext = agentContext;
			_stateMachine = stateMachine;

            _perception = _agentContext.Perception;
			_movement = _agentContext.gameObject.GetComponent<CharacterMovement>();
			_enemyAttack = _agentContext.gameObject.GetComponentInChildren<EnemyAttack>();
        }

		public void Enter()
		{

        }

		public void Handle()
		{
            var distance = Vector2.Distance(_agentContext.transform.position, _agentContext.Target.transform.position);
            var direction = _agentContext.Target.transform.position - _agentContext.transform.position;
            _movement.SetDirection(direction.normalized);

            //Если игрок вне дистанции агрессии, то продолжать какое-то время преследовать
            if (distance > _perception.VisionDistance) 
			{
				_elapsedTime += Time.deltaTime;

                //Если цель уже слишком далеко, то возврат в патрулю
                if (_elapsedTime >= _agentContext.ChaseTimeOut) 
				{
                    _stateMachine.Enter<IdleState>();
					_elapsedTime = 0;
				}
            }//Если игрок слишком близко, то остановиться для атаки
            else if (distance <= _enemyAttack.AttackDistance)
            {
                _elapsedTime = 0f;
			    _stateMachine.Enter<EngageState>();
			}
        }

        public void Exit()
        {
            
        }
    }
}