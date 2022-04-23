using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{

    public Text resourcesText;
    [Header("Resources")]
    public int _gold;
    public int _rock;
    public int _wood;
    public int _buildings;


    void Start()
    {
        
    }


    void Update()
    {
        resourcesText.text = " Золото:"+ _gold + " Камень:" + _rock + " Дерево:"+_wood + " Постройки:" + _buildings;
    }
}
