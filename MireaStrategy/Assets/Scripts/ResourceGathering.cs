using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGathering : MonoBehaviour
{

    public float gatheringSpeed = 3;
    public int ammountOfResource = 5;
    public GameObject gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }



    private void OnTriggerEnter(Collider other)
    {
        //Metod for Sawmill gathering
        if (gameObject.name == "Sawmill(Clone)")
        {
            if (other.CompareTag("Forest"))
            {
                Debug.Log("���");
                StartCoroutine(CuttingTrees());
            }
        }
            

        //Metod for Quarry gathering
       if(gameObject.name == "Quarry(Clone)")
        {
            if (other.CompareTag("Rocks"))
            {
                Debug.Log("�����");
                StartCoroutine(CuttingRocks());
            }
        }



        //Metod for Quarry gathering
        if (gameObject.name == "Mine(Clone)")
        {
            if (other.CompareTag("Gold"))
            {
                Debug.Log("������");
                StartCoroutine(GetGold());
            }
        }

    }



    IEnumerator CuttingTrees()
    {
        while (true)
        {
            yield return new WaitForSeconds(gatheringSpeed);
            gameManager.GetComponent<Shop>()._wood += ammountOfResource;
        }
    }

    IEnumerator CuttingRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(gatheringSpeed);
            gameManager.GetComponent<Shop>()._rock += ammountOfResource;
        }
    }


    IEnumerator GetGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(gatheringSpeed);
            gameManager.GetComponent<Shop>()._gold += ammountOfResource;
        }
    }
}
