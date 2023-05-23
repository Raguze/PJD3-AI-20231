using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        public override void Enter()
        {
            CurrentIndexPoint = 0;
            Agent.MoveToPosition(CurrentPoint.position);
        }

        public override void Exit()
        {
            
        }

        public override void Update(float deltaTime)
        {
            if(Agent.Nma.remainingDistance <= 0.001f)
            {
                CurrentIndexPoint++;
                Agent.MoveToPosition(CurrentPoint.position);
            }
        }
    }

}