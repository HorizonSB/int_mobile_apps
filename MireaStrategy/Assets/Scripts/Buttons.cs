using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject gameManager;

    [SerializeField] private Button _button;

    //Building cost
    public int woodCost;
    public int rockCost;
    public int goldCost;


    //Building Prefab
    public GameObject buildingPrefab;

    //Display building cost
    public Text woodText;
    public Text rockText;
    public Text goldText;


    public void Start()
    {
        _button.onClick.AddListener(BuyBuilding);
    }


    private void Update()
    {
        woodText.text = woodCost.ToString();
        rockText.text = rockCost.ToString();
        goldText.text = goldCost.ToString();
    }

    private void BuyBuilding()
    {
        gameManager.GetComponent<Shop>().TryBuy(woodCost, rockCost, goldCost, buildingPrefab);
    }



}
