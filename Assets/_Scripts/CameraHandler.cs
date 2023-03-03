using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    
    
    private void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
    }


    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y);
        float moveSpeed = 30f;
        transform.position += moveDir * (moveSpeed * Time.deltaTime);

        float zoomAmount = 2f;
        orthographicSize += Input.mouseScrollDelta.y * zoomAmount;
        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
