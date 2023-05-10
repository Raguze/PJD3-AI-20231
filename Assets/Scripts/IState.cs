using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public interface IState
    {

        StatePhase Phase { get; set; }
        string Name { get; }
        void Enter();
        void Update(float deltaTime);
        void Exit();
    }
}
