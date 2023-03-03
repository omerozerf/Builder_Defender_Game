using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    
    private BuildingTypeSO activeBuildingType;
    private BuildingTypeListSO buildingTypeList;
    private Camera mainCamera;


    private void Awake()
    {
        Instance = this;
        
        buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        activeBuildingType = buildingTypeList.list[0];
    }


    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Instantiate(activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        return mouseWorldPosition;
    }


    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
    }
}
