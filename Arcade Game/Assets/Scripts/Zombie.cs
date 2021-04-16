using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform player;

    [HideInInspector]
    public bool dead;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (!dead)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }


}
