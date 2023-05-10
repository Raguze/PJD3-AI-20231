using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI
{
    public class FSM : MonoBehaviour
    {
        public Dictionary<string, IState> states = new Dictionary<string, IState>();

        public IState CurrentState { get; protected set; }

        protected IState nextState;

        private void Awake()
        {
            IState state;

            var agent = GetComponent<AgentController>();

            state = new IdleState(agent,ChangeState);
            states.Add(state.Name,state);

            state = new WalkState(agent,ChangeState);
            states.Add(state.Name,state);

            var tfs = FindObjectsOfType<PatrolPoint>().Select(pp => pp.Tf).ToArray() ;
            state = new PatrolState(agent, ChangeState, tfs);
            states.Add(state.Name, state);
        }

        public void ChangeState(string name)
        {
            var state = states[name];
            nextState = state;

            Debug.Log($"Change State {CurrentState.Name} > {nextState.Name}");
        }

        public void StartFSM(string name)
        {
            var state = states[name];
            StartFSM(state);
        }

        public void StartFSM(IState state)
        {
            CurrentState = state;
            CurrentState.Phase = StatePhase.Enter;
        }

        private void Update()
        {
            if(CurrentState != null)
            {
                switch (CurrentState.Phase)
                {
                    case StatePhase.None:
                        break;
                    case StatePhase.Enter:
                        CurrentState.Enter();
                        CurrentState.Phase = StatePhase.Update;
                        break;
                    case StatePhase.Update:
                        float deltaTime = Time.deltaTime;
                        CurrentState.Update(deltaTime);
                        break;
                    case StatePhase.Exit:
                        CurrentState.Exit();
                        if(nextState != null)
                        {
                            CurrentState = nextState;
                            nextState = null;
                            CurrentState.Phase = StatePhase.Enter;
                        }
                        break;
                    default:
                        Debug.Log("Unknown Phase");
                        Debug.Break();
                        break;
                }
                
            }

            if(nextState != null)
            {
                //CurrentState.Exit();
                //CurrentState = nextState;
                //nextState = null;
                CurrentState.Phase = StatePhase.Exit;
            }
        }
    }
}
