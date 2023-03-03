using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectTypeUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;

    private Transform arrowButton;
    private Dictionary<BuildingTypeSO, Transform> buttonTransformDictionary;
    private BuildingTypeListSO buildingTypeList;

    private void Awake()
    {
        buttonTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();
        
        Transform buttonTemplate = transform.Find("button template");
        buttonTemplate.gameObject.SetActive(false);
        
        buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));

        int index = 0;
        
        arrowButton = Instantiate(buttonTemplate, transform);
        arrowButton.gameObject.SetActive(true);
            
        float offsetAmount = +130f;
        arrowButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

        arrowButton.Find("image").GetComponent<Image>().sprite = arrowSprite;
        arrowButton.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -30);


        arrowButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            BuildingManager.Instance.SetActiveBuildingType(null);
        });

        index++;
        
        foreach (BuildingTypeSO buildingType in buildingTypeList.list)
        {
            Transform buttonTransform = Instantiate(buttonTemplate, transform);
            buttonTransform.gameObject.SetActive(true);
            
            offsetAmount = +130f;
            buttonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            buttonTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            buttonTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            buttonTransformDictionary[buildingType] = buttonTransform;
            
            index++;
        }
    }


    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }


    private void UpdateActiveBuildingTypeButton()
    {
        arrowButton.Find("selected").gameObject.SetActive(false);
        
        foreach (BuildingTypeSO buildingType in buttonTransformDictionary.Keys)
        {
            Transform buttonTransform = buttonTransformDictionary[buildingType];
            buttonTransform.Find("selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null)
        {
            arrowButton.Find("selected").gameObject.SetActive(true);
        }
        else
        {
            buttonTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        }
        
        
    }
}
