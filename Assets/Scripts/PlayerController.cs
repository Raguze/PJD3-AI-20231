using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{

    public class PlayerController : BaseAgentController
    {
        protected override void Init()
        {
            nma.speed = 4f;
        }
    }

}