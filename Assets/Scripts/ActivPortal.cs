using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivPortal : MonoBehaviour
{
    private JobController _jobController;
    [SerializeField] private GameObject _portal;


    private void Start()
    {
        _jobController = FindObjectOfType<JobController>();
        print(_jobController);
    }

    private void Update()
    {
        if (_jobController._completed)
            _portal.SetActive(true);
    }
}
