using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyChooser : MonoBehaviour
{
    [SerializeField] private float speed = .05f;
    [SerializeField] private Transform targetedDone;
    [SerializeField] private float RandomStrat;
    [SerializeField] private bool sendingBool = false;
    void Update() {
        if (sendingBool == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetedDone.position, speed);
        }
    }
    public void RandomGen() {
        RandomStrat = Mathf.Round(Random.value * 100f);
        ChooseStrat();
    }
    void ChooseStrat() {
        if (RandomStrat <= 50)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
            Invoke("fixingStrat", 3);
            Invoke("Reset", 5);
        } else
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            Invoke("Reset", 5);
        }
        
    }
    void Reset() {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
    void fixingStrat() {
        gameObject.GetComponent<RandomMovement>().agent.isStopped = true;
        gameObject.GetComponent<RandomMovement>().enabled = false;
        var done = GameObject.FindWithTag("done");
        targetedDone = done.transform;
        sendingBool = !sendingBool;
    }
    void resetRandomMove() {
        gameObject.GetComponent<RandomMovement>().getWorkCooldown = 10;
        gameObject.GetComponent<RandomMovement>().enabled = true;
        gameObject.GetComponent<RandomMovement>().agent.isStopped = false;
    }
    void OnCollisionEnter(Collision doneCollider) {
        if (doneCollider.gameObject.tag == "done")
        {
            sendingBool = !sendingBool;
            resetRandomMove();
        }
    }
}