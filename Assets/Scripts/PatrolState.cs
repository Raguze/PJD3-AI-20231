using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI
{

    public class PatrolState : BaseState
    {
        public List<Transform> Points = new List<Transform>();

        private int currentIndexPoint;
        public int CurrentIndexPoint 
        {
            get => currentIndexPoint;
            protected set {
                currentIndexPoint = value % Points.Count;
            } 
        }

        public Transform CurrentPoint { get => Points[CurrentIndexPoint]; }

        public PatrolState(BaseAgentController agent, Action<string> changeState, Transform[] points) : base(agent, changeState)
        {
            Points.AddRange(points);
        }

        public override string Name => BaseState.PATROL_STATE;

        public int GetNearestIndexPoint()
        {
            float minDistance = float.MaxValue;
            int index = 0;
            for (int i = index; i < Points.Count; i++)
            {
                var point = Points[i];
                var diffVector = Agent.Tf.position - point.position;
                var diff = diffVector.sqrMagnitude;
                if(diff <= minDistance)
                {
                    minDistance = diff;
                    index = i;
                }
            }
            return index;
        }

        public override void Enter()
        {
            CurrentIndexPoint = GetNearestIndexPoint();
            LogPhase($"Near Point {CurrentIndexPoint}");
            Debug.Break();

            Agent.MoveToPosition(CurrentPoint.position);
        }

        public override void Exit()
        {
            
        }

        public override void Update(float deltaTime)
        {
            if (CheckDistance())
            {
                ChangeState(BaseState.CHASE_STATE);
                //return;
            }
            else if (Agent.Nma.remainingDistance <= 0.001f)
            {
                CurrentIndexPoint++;
                Agent.MoveToPosition(CurrentPoint.position);
            }
        }
    }

}