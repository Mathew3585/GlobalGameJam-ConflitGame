using UnityEngine;
using UnityEngine.AI;

public class AI_NavMesh : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    public float chaseRange = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Debug.Log(player.position);
        if (distance <= chaseRange)
        {
            RaycastHit hit;
            Vector3 direction = player.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit, chaseRange))
            {
                if (hit.transform == player)
                {
                    agent.destination = player.position;
                }
            }
        }
    }
}
