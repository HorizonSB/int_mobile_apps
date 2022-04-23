using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public Slider slider;
    public int maxHealth;
    public int currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth < maxHealth) slider.gameObject.SetActive(true);
        if (currentHealth <= 0) Destroy(gameObject);

        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
    }

    public void SetMaxHealth(int buildingHp)
    {
        slider.maxValue = buildingHp;
        slider.value = buildingHp;
    }

    public void SetHealth(int buildingHp)
    {
        slider.value = buildingHp;
    }
}
