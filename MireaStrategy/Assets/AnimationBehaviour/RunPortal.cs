using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RunPortal : StateMachineBehaviour
{
    Transform portal;
    public Transform building;
    float chaseRange = 10f;
    public List<GameObject> buildings;
    float currentDistance;
    GameObject closest = null;

    NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        portal = GameObject.FindGameObjectWithTag("Portal").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(portal.position);    
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Начало теста



        foreach(GameObject gameObject in buildings)
        {
            Vector3 diff = gameObject.transform.position - agent.gameObject.transform.position;
            currentDistance = diff.sqrMagnitude;
            if (currentDistance < chaseRange)
            {
                closest = gameObject;
                chaseRange = currentDistance;
                animator.SetBool("RunToBuilding", true);
            }
        }


        //Конец теста

        agent.SetDestination(portal.position);

        //building = GameObject.FindGameObjectWithTag("Building").transform;

        

        //float distance = Vector3.Distance(animator.transform.position, building.position);
        //if(distance < chaseRange)
        //{
        //    animator.SetBool("RunToBuilding", true);
        //}

    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
