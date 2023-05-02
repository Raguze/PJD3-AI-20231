using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI
{
    public class IdleState : BaseState
    {
        public IdleState(AgentController agent, Action<string> changeState ) : base(agent,changeState) { }

        public override string Name => BaseState.IDLE_STATE;

        protected float duration;
        public override void Enter()
        {
            duration = UnityEngine.Random.Range(2f, 5f);
        }

        public override void Exit()
        {
            duration = 0;
        }

        public override void Update(float deltaTime)
        {
            duration -= deltaTime;
            if(duration <= 0)
            {
                Debug.Log("Change State");
                ChangeState("Walk State");
            }
        }
    }
}
