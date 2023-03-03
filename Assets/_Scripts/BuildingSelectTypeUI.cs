using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectTypeUI : MonoBehaviour
{
    private void Awake()
    {
        Transform buttonTemplate = transform.Find("button template");
        buttonTemplate.gameObject.SetActive(false);
        
        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));

        int index = 0;
        foreach (BuildingTypeSO buildingType in buildingTypeList.list)
        {
            Transform buttonTransform = Instantiate(buttonTemplate, transform);
            buttonTransform.gameObject.SetActive(true);
            
            float offsetAmount = +160f;
            buttonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            buttonTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            buttonTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });
            
            index++;
        }
    }
}
