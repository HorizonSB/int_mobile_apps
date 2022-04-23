using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    //Поведение противника
    public float range = 10f;
    public float attackRange = 4f;
    public Transform building;
    public bool RunToBuilding;



    public GameObject portal;
    public GameObject gameManager;
    private NavMeshAgent agent;
    public GameObject enemyEmpty;

    public float health;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        gameManager = GameObject.Find("GameManager");
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (building == null)
        {
            agent.SetDestination(portal.transform.position);
        }
        if (RunToBuilding)
        {
            agent.SetDestination(building.position);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(enemyEmpty);
        }
    }


    //Поиск башни
    void UpdateTarget()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        float shortetsDistance = Mathf.Infinity;
        GameObject nearesBuilding = null;
        foreach (GameObject building in buildings)
        {
            float distanceToBuilding = Vector3.Distance(transform.position, building.transform.position);
            if(distanceToBuilding < shortetsDistance)
            {
                shortetsDistance = distanceToBuilding;
                nearesBuilding = building;
            }
        }
        if(nearesBuilding != null && shortetsDistance <= range && shortetsDistance > attackRange)
        {
            building = nearesBuilding.transform;
            RunToBuilding = true;
        }
        else
        {
            building = null;
            RunToBuilding = false;
            gameObject.GetComponent<Animator>().SetBool("RunToBuilding", true);
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
        }
        if(nearesBuilding != null && shortetsDistance <= attackRange)
        {
            building = nearesBuilding.transform;
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            transform.LookAt(building.transform);
            RunToBuilding = false;
        }
        

    }

    //Получение урона от стрелы
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            health -= other.gameObject.GetComponent<Arrow>().damage;
            Destroy(other.gameObject);   
        }
    }



    //Поведение противника
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
