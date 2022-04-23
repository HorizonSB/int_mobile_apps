using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            other.gameObject.GetComponent<Building>().currentHealth -= damage;
        }
    }
}
