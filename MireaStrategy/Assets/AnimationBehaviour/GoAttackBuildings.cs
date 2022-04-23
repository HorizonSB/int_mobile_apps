using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoAttackBuildings : StateMachineBehaviour
{
    Transform building;
    public GameObject gameManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameManager = GameObject.Find("GameManager");
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        building = GameObject.FindGameObjectWithTag("Building").transform;

        animator.transform.LookAt(building);
            float distance = Vector3.Distance(animator.transform.position, building.position);
            if (distance > 3)
            {
                animator.SetBool("Attack", false);
            }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
