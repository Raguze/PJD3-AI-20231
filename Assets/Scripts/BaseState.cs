using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI
{
    public enum StatePhase { None, Enter, Update, Exit }

    public class BaseState : IState
    {
        public const string IDLE_STATE = "IdleState";
        public const string WALK_STATE = "WalkState";
        public const string PATROL_STATE = "PatrolState";

        public StatePhase Phase { get; set; }
        public AgentController Agent { get; protected set; }
        public Action<string> ChangeState { get; protected set; }

        public BaseState(AgentController agent, Action<string> changeState)
        {
            Agent = agent;
            ChangeState = changeState;
        }

        public virtual string Name => throw new System.NotImplementedException();

        public virtual void Enter()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public virtual void LogPhase(string msg = "")
        {
            Debug.Log($"{Name} {Phase} {msg}");
        }
    }
}
