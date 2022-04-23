using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
   


    [Header("Buildings")]
    public GameObject[] buildings;


    [Header("Other")]
    public GameObject shopPanel;
    public GameObject AllCell;
    public GameObject resourcesPanel;
    public int _gold;
    public int _wood;
    public int _rock;
    public int _buildings;

    [Header("ErrorMessage")]
    public GameObject resourceError;

    //[Header("Price Build")]
    //public int goldPrice;
    //public int woodPrice;
    //public int rockPrice;
    //public Text goldText;
    //public Text woodText;
    //public Text rockText;

    //public void Start()
    //{
    //_gold = resourcesPanel.GetComponent<ResourceController>()._gold;
    //_rock = resourcesPanel.GetComponent<ResourceController>()._rock;
    //_wood = resourcesPanel.GetComponent<ResourceController>()._wood;
    //_buildings = resourcesPanel.GetComponent<ResourceController>()._buildings;
    //}

    //private void Update()
    //{
    //resourcesPanel.GetComponent<ResourceController>()._gold = _gold; 
    //resourcesPanel.GetComponent<ResourceController>()._rock = _rock;
    //resourcesPanel.GetComponent<ResourceController>()._wood = _wood;
    //resourcesPanel.GetComponent<ResourceController>()._buildings = _buildings;


    //goldText.text = goldPrice.ToString();
    //woodText.text = woodPrice.ToString();
    //rockText.text = rockPrice.ToString();

    //goldPrice = button.goldCost;
    //woodPrice = button.woodCost;
    //rockPrice = button.rockCost;

    //}

    //public void BuyBuilding(int woodCost, int rockCost, int goldCost, GameObject buildingPrefab)
    //{
    //    for (int i = 0; i < AllCell.transform.childCount; i++)
    //    {
    //        if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
    //        {
    //            if (woodCost <= _wood && rockCost <= _rock && goldCost <= _gold)
    //            {
    //                AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildingPrefab);
    //            }

    //        }
    //    }
    //    Cancel();
    //}


    public void Cancel()
    {
        resourceError.SetActive(false);
        shopPanel.SetActive(false);
        for(int i = 0; i < AllCell.transform.childCount; i++)
        {
            if(AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true)
            {
                AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell = false;
                break;
            }
        }
    }

    //public void BuildTower()
    //{
    //    if(_gold < goldPrice)
    //    {
    //        resourceError.SetActive(true);
    //        return;
    //    }

    //    for (int i = 0; i < AllCell.transform.childCount; i++)
    //    {
    //        if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
    //        {
    //            AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildings[0]);
    //            _gold -= goldPrice;
    //        }
    //    }
    //    Cancel();
    //}

    //public void BuildSawmill()
    //{
    //    for (int i = 0; i < AllCell.transform.childCount; i++)
    //    {
    //        if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
    //        {
    //            AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildings[1]);
    //        }
    //    }
    //    Cancel();
    //}

    //public void BuildQuarry()
    //{
    //    for (int i = 0; i < AllCell.transform.childCount; i++)
    //    {
    //        if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
    //        {
    //            AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildings[2]);
    //        }
    //    }
    //    Cancel();
    //}

    //public void BuildMine()
    //{
    //    for (int i = 0; i < AllCell.transform.childCount; i++)
    //    {
    //        if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
    //        {
    //            AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildings[3]);
    //        }
    //    }
    //    Cancel();
    //}



}
