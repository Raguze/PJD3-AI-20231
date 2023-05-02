using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class FSM : MonoBehaviour
    {
        public Dictionary<string, IState> states = new Dictionary<string, IState>();

        public IState CurrentState { get; protected set; }

        private void Awake()
        {
            IState state;

            var agent = GetComponent<AgentController>();

            state = new IdleState(agent,ChangeState);
            states.Add(state.Name,state);

            state = new WalkState(agent,ChangeState);
            states.Add(state.Name,state);
        }

        public void ChangeState(string name)
        {
            var state = states[name];
            CurrentState = state;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            foreach (var keyValuePair in states)
            {
                var state = keyValuePair.Value;
                state.Update(deltaTime);
            }
        }
    }
}
