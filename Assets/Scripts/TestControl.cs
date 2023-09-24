using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestControl : MonoBehaviour
{
    [SerializeField]private Camera _cam;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition),out hit)) 
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
