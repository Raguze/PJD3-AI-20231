using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{

    public class ChaseState : BaseState
    {
        public Transform Target { get; protected set; }

        public ChaseState(BaseAgentController agent, Action<string> changeState,Transform target) : base(agent, changeState)
        {
            Target = target;
        }

        public override string Name => BaseState.CHASE_STATE;

        public override void Enter()
        {
            CalculatePlayerPosition();
        }

        public override void Update(float deltaTime)
        {
            CalculatePlayerPosition();

            if(!CheckDistance())
            {
                ChangeState(BaseState.PATROL_STATE);
            }
        }

        public override void Exit()
        {
            
        }

        public void CalculatePlayerPosition()
        {
            Vector3 pos = new Vector3(
                Target.position.x,
                Agent.Tf.position.y,
                Target.position.z
            );
            Agent.MoveToPosition(pos);

            LogPhase($"{pos.x} {pos.z}");
        }

    }

}