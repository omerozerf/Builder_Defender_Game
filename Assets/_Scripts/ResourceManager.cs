﻿using System;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public event EventHandler OnResourceAmountChanged;
    
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;


    private void Awake()
    {
        Instance = this;
        
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();
        
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }
        
        
        TestLogResourceAmountDictionary();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        { 
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }


    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + " : " + resourceAmountDictionary[resourceType]);
        }
    }


    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        
        TestLogResourceAmountDictionary();
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }
}