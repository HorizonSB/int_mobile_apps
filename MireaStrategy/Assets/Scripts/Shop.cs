using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    public GameObject shopPanel;
    public GameObject AllCell;

    [Header("Resources")]
    public int _gold;
    public int _rock;
    public int _wood;

    [Header("DisplayResources")]
    public Text goldText;
    public Text rockText;
    public Text woodText;

    [Header("ErrorMessage")]
    public GameObject resourceError;

    void Start()
    {
        
    }


    void Update()
    {
        goldText.text = "" + _gold.ToString();
        rockText.text = "" + _rock.ToString();
        woodText.text = "" + _wood.ToString();
    }


    public void TryBuy(int woodCost, int rockCost, int goldCost, GameObject buildingPrefab)
    {
        for (int i = 0; i < AllCell.transform.childCount; i++)
        {
            if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
            {
                if(_wood >= woodCost && _rock >= rockCost && _gold >= goldCost)
                {
                    _wood -= woodCost;
                    _rock -= rockCost;
                    _gold -= goldCost;

                    AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(buildingPrefab);
                    buildings.Add(buildingPrefab);
                    //Debug.Log(buildings.Count);
                }
                else
                {
                    StartCoroutine(resourcesError());
                }              
            }
        }
        Cancel();
    }



    public void Cancel()
    {
        shopPanel.SetActive(false);
        for (int i = 0; i < AllCell.transform.childCount; i++)
        {
            if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true)
            {
                AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell = false;
                break;
            }
        }
    }

   IEnumerator resourcesError()
    {
        resourceError.SetActive(true);
        yield return new WaitForSeconds(2f);
        resourceError.SetActive(false);
    }
}
