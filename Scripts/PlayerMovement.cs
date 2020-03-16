using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private Camera cam = null;
    private NavMeshAgent _playerAgent = null;

    private void Awake()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out var hitInfo, 1000, clickableLayer))
            {
                _playerAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
