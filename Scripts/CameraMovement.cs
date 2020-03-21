using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.1f;
    private GameObject _player;
    private Vector3 offset = new Vector3(0f, 0f, 2f);
    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void LateUpdate()
    {
        Vector3 desPos = new Vector3(_player.transform.position.x, 8f,_player.transform.position.z) - offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
