using UnityEngine;
using Utilities;
using StateMachineNameSpace;

namespace ObstacleHit
{
    public class ObstacleHitComponent : MonoBehaviour
    {
        //---------------Private---------------//
        private StateMachine _stateMachine;

        //---------------Functions---------------//
        private void Start() => _stateMachine = StateMachine.Instance;

        private void HitObstacle() => _stateMachine.SetState(StateMachineState.GAME_OVER);

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
                HitObstacle();
        }
    }
}