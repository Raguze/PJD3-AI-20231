using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI
{
    public class WalkState : BaseState
    {
        public override string Name => BaseState.WALK_STATE;

        public WalkState(BaseAgentController agent, Action<string> changeState) : base(agent, changeState) { }

        public override void Enter()
        {
            Vector3 pos = new Vector3(
                UnityEngine.Random.Range(-24f,24f),
                0,
                UnityEngine.Random.Range(-24f, 24f)
            );

            Agent.MoveToPosition(pos);

            LogPhase($"{pos.x} {pos.z}");

            //Debug.Break();
        }

        public override void Exit()
        {
            LogPhase();
        }

        public override void Update(float deltaTime)
        {
            LogPhase();
            if(Agent.Nma.remainingDistance <= 0.001f)
            {
                ChangeState(BaseState.IDLE_STATE);
            }
            
        }
    }
}
