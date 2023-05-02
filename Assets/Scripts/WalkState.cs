using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI
{
    public class WalkState : BaseState
    {
        public override string Name => BaseState.WALK_STATE;

        public WalkState(AgentController agent, Action<string> changeState) : base(agent, changeState) { }

        public override void Enter()
        {
            Vector3 pos = new Vector3(
                UnityEngine.Random.Range(-49f,49f),
                0,
                UnityEngine.Random.Range(-49f, 49f)
            );

            Agent.MoveToPosition(pos);
        }

        public override void Exit()
        {
            
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}
