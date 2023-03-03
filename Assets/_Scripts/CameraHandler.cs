using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targerOrthographicSize;

    
    private void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targerOrthographicSize = orthographicSize;
    }


    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y);
        float moveSpeed = 30f;
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }


    private void HandleZoom()
    {
        float zoomAmount = 2f;
        targerOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targerOrthographicSize = Math.Clamp(targerOrthographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targerOrthographicSize, Time.deltaTime * zoomSpeed);
        
        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
