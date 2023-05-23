using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Newtonsoft.Json;

namespace AI
{
    [RequireComponent(typeof(Rigidbody))]
    public class AgentController : BaseAgentController
    {
        protected override void Init()
        {
            fsm = gameObject.AddComponent<FSM>();
        }

    }

}
