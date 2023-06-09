using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RandomMovement : MonoBehaviour
{
    private SpriteRenderer sr;
    public NavMeshAgent agent;
    public float range;
    public Transform centrePoint;
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        sr = transform.Find("sr").GetComponent<SpriteRenderer>();
    }
    void Update() {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
        float xMovement = agent.velocity.x;
        if (xMovement != 0 && xMovement < 0)
        {
            sr.flipX = true;
        } else if (xMovement != 0 && xMovement > 0)
        {
            sr.flipX = false;
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}