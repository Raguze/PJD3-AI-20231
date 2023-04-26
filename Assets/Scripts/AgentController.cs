using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Newtonsoft.Json;

namespace AI
{
    [RequireComponent(typeof(Rigidbody))]
    public class AgentController : MonoBehaviour
    {

        [SerializeField]
        protected Rigidbody rb;
        [SerializeField]
        protected NavMeshAgent nma;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            nma = GetComponent<NavMeshAgent>();
        }

        public void MoveToPosition(Vector3 pos)
        {
            nma.SetDestination(pos);
        }

        public void Move(float x, float z)
        {
            Vector3 pos = rb.position;
            pos.x = pos.x + x * Time.deltaTime;
            pos.z = pos.z + z * Time.deltaTime;
            rb.MovePosition(pos);
            //rb.velocity = new Vector3(x, 0, z);
        }

    }

}
