using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public int damage;


    private void Update()
    {
        //Destroy(gameObject, 1f);
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (target.gameObject != null)
        {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        else Destroy(gameObject);

    }
}
