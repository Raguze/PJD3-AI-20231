using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class GameController : MonoBehaviour
{
    public AgentController agent;

    public Camera cam;

    private void Awake()
    {
        agent = FindObjectOfType<AgentController>();

        var cameraController = FindObjectOfType<CameraController>();
        cameraController.Target = agent.Tf;

        cam = Camera.main;
    }




    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo))
        //    {
        //        agent.MoveToPosition(hitInfo.point);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            agent.Fsm.StartFSM(BaseState.IDLE_STATE);
        }
    }

    
}
