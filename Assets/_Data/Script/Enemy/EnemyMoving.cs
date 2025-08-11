using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    void Update()
    {
    }
     void FixedUpdate()
     {
        agent.SetDestination(target.transform.position);
     }
}
