using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public float speed;
    public Rigidbody rb;
    public SpriteRenderer sr;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        sr = transform.Find("sr").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }
    }
}
