using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public bool building;
    public bool water;
    public bool activeCell;
    public GameObject shopPanel;

    void Start()
    {
        //shopPanel = GameObject.FindGameObjectWithTag("ShopPanel");
    }

    void Update()
    {
        if (shopPanel.activeInHierarchy)
        {
            return;
        }


        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0) && transform.GetChild(0).gameObject.GetComponent<Light>().color == Color.green && transform.GetChild(0).gameObject.activeSelf == true)
            {
                if (water == false)
                {
                    shopPanel.SetActive(true);
                    activeCell = true;
                }
            }
        }
        
    }

    private void OnMouseEnter()
    {
        if (shopPanel.activeInHierarchy)
        {
            return;
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (building == true || water == true)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.red;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<Light>().color = Color.green;
            }
        }
            
        
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void setBuild(GameObject build)
    {
        Instantiate(build).transform.position = transform.GetChild(1).transform.position;
        building = true;
        activeCell = false;
    }
}
