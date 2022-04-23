using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRadius : MonoBehaviour
{
    public Transform building;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            building = other.transform;
        }
    }
}
