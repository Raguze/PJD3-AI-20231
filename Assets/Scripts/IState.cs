using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public interface IState
    {
        string Name { get; }
        void Enter();
        void Update(float deltaTime);
        void Exit();
    }
}
