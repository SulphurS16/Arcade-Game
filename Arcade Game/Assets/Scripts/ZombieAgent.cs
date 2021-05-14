using UnityEngine.AI;
using UnityEngine;

public class ZombieAgent : MonoBehaviour
{
    private NavMeshAgent agent { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(PlayerInfo.playerPos);
    }
}
