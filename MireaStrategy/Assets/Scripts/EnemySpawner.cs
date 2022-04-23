using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject spawnPoint;
    public float speed;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,8));
            Instantiate(enemys[Random.Range(0,enemys.Length)], spawnPoint.transform);
        }
    }
}
