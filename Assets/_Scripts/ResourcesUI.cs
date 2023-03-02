using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    private void Awake()
    {
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        Transform resourceTemplate = transform.Find("Resource Template");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            
            index++; 
        }
    }
}
