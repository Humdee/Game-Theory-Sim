using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveWork : MonoBehaviour
{
    [SerializeField] private float speed = .1f;
    [SerializeField] private Transform targetedWork;
    void Update() {
        if (CreateWork.instance.Works.Count > 0)
        {
            var workSaw = GameObject.FindWithTag("work");
            targetedWork = workSaw.transform;
            transform.position = Vector3.MoveTowards(transform.position, targetedWork.position, speed);
        }
    }
    void OnCollisionEnter (Collision workCollider) {
        if (workCollider.gameObject.tag == "work")
        {
            CreateWork.instance.Works.RemoveAt(0);
            gameObject.GetComponent<StrategyChooser>().RandomGen();
            gameObject.GetComponent<RandomMovement>().getWorkCooldown = 10;
            gameObject.GetComponent<RandomMovement>().enabled = true;
            gameObject.GetComponent<RandomMovement>().agent.isStopped = false;
            gameObject.GetComponent<ReceiveWork>().enabled = false;
        }
        
    }
}