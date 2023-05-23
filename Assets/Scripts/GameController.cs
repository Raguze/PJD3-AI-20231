using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using AI;

public class GameController : MonoBehaviour
{
    public BaseAgentController agent;
    public BaseAgentController player;

    public Camera cam;

    public float distance;
    public float sqrDistance;

    static private GameController _instance;
    static public GameController Instance
    { 
        get => _instance;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        var agents = FindObjectsOfType<BaseAgentController>();

        foreach (var item in agents)
        {
            if(item as AgentController)
            {
                agent = item;
            } 
            else if(item as PlayerController)
            {
                player = item;
            }
        }


        var cameraController = FindObjectOfType<CameraController>();
        cameraController.Target = player.Tf;

        cam = Camera.main;

        CreateAgentStates();
    }




    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                player.MoveToPosition(hitInfo.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            agent.Fsm.StartFSM(BaseState.IDLE_STATE);
        }

        DistanceBetweenAgents();
    }

    public float DistanceBetweenAgents()
    {
        var vectorDistance = player.Tf.position - agent.Tf.position;

        sqrDistance = vectorDistance.sqrMagnitude;

        return sqrDistance;
    }

    public void CreateAgentStates()
    {
        IState state;
        var fsm = agent.GetComponent<FSM>();

        state = new IdleState(agent, fsm.ChangeState);
        fsm.AddState(state);

        state = new WalkState(agent, fsm.ChangeState);
        fsm.AddState(state);

        var tfs = FindObjectsOfType<PatrolPoint>()
            .Select(pp => pp.Tf)
            .OrderBy(t => t.name)
            .ToArray();

        state = new PatrolState(agent, fsm.ChangeState, tfs);
        fsm.AddState(state);

        state = new ChaseState(agent, fsm.ChangeState, player.Tf);
        fsm.AddState(state);
    }

    
}
