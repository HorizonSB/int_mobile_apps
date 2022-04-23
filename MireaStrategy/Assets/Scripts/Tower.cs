using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float speed;
    public GameObject arrow;
    public Transform target;
    public GameObject shootObject;
    //public bool lockOnTarget;
    public float range = 10f;
    public int controlShoot = 0;


    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    //private void Update()
    //{
        //if (target == null)
        //{
        //    Des
        //}
        //if(target == null)
        //{
        //    lockOnTarget = false;
        //}
    //}



    //private void OnTriggerEnter(Collider other)
    //{
    //    if(target == null && lockOnTarget == false && other.gameObject.CompareTag("Enemy"))
    //    {
    //        target = other.gameObject.transform;
    //        lockOnTarget = true;
    //        StartCoroutine(shoot());
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Escape Trigger");
    //    if (other.gameObject.transform == target)
    //    {
    //        target = null;
    //        lockOnTarget = false;
    //        StopCoroutine(shoot());
    //        Debug.Log("Enemy exit");
    //    }
    //}


    IEnumerator shoot()
    {
        while(target != null)
        {
            yield return new WaitForSeconds(speed);
            GameObject b = Instantiate(arrow, shootObject.transform.position, Quaternion.identity);
            b.GetComponent<Arrow>().target = target;
        }
    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortetsDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToBuilding = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToBuilding < shortetsDistance)
            {
                shortetsDistance = distanceToBuilding;
                nearesEnemy = enemy;
            }
        }
        if (nearesEnemy != null && shortetsDistance <= range)
        {
            target = nearesEnemy.transform;
            controlShoot += 1;
            if(controlShoot == 1)
            StartCoroutine(shoot());
        }
        else
        {
            controlShoot = 0;
            target = null;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
