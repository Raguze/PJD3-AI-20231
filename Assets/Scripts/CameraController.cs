using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target { get; set; }

    protected Transform tf;

    public float t = 0.005f;

    private void Awake()
    {
        tf = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(Target.position.x, tf.position.y, Target.position.z);
        Vector3 currentPos = tf.position;
        tf.position = Vector3.Lerp(currentPos,targetPos,t);
        
    }
}
