using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunToBuildingBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    public Transform building;
    float attackrange = 4f;
    float chaseRange = 10f;
    public GameObject gameManager;


    public List<GameObject> buildings;


    GameObject closest;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;
        gameManager = GameObject.Find("GameManager");
        buildings = gameManager.GetComponent<Shop>().buildings;
        Debug.Log(buildings.Count);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //building = GameObject.FindGameObjectWithTag("Building").transform;
        //building = FindClosestBuilding().transform;


        //agent.SetDestination(building.position);

        //float distance = Vector3.Distance(animator.transform.position, building.position);
        //if(distance < chaseRange)
        //{
        //    animator.SetBool("RunToBuilding", true);
        //}

        //    if (distance < attackrange)
        //    {
        //        animator.SetBool("Attack", true);
        //    }

        //    if (distance > 10)
        //    {
        //        animator.SetBool("RunToBuilding", false);
        //    }       
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.speed = 2;
    }




    //Поиск ближайшего строения
    GameObject FindClosestBuilding()
    {
        float distance = 10f;
        Vector3 position = agent.gameObject.transform.position;
        foreach (GameObject gameObject in buildings)
        {
            Vector3 diff = gameObject.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = gameObject;
                distance = currentDistance;
            }
        }
        return closest;
    }
}
