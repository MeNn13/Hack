using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneBoss : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager ??= FindObjectOfType<GameManager>();
        print(_gameManager);
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.LoadLevel(3);
    }
}
