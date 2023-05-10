using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public Transform Tf;
    private void Awake()
    {
        Tf = GetComponent<Transform>();
    }
}
