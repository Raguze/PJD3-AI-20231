using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI
{
    public class IdleState : BaseState
    {
        public IdleState(BaseAgentController agent, Action<string> changeState ) : base(agent,changeState) { }

        public override string Name => BaseState.IDLE_STATE;

        protected float duration;
        public override void Enter()
        {
            duration = UnityEngine.Random.Range(10f, 20f);
            LogPhase(duration.ToString());
            //Debug.Break();
        }

        public override void Exit()
        {
            LogPhase();
            duration = 0;
        }

        public override void Update(float deltaTime)
        {
            duration -= deltaTime;
            LogPhase(duration.ToString());

            if(CheckDistance())
            {
                ChangeState(BaseState.CHASE_STATE);
            }

            if(duration <= 0)
            {
                //ChangeState(BaseState.WALK_STATE);
                ChangeState(BaseState.PATROL_STATE);
            }
        }
    }
}
