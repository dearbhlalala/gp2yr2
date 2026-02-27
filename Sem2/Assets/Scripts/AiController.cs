using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class AiController : MonoBehaviour
{
    NavMeshAgent agent;
    AiTrigger aiTrigger;
    public GameObject player;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        aiTrigger = GetComponentInChildren<AiTrigger>();
    }

    public void Update()
    {
        if (aiTrigger.playerInTrigger)
        {
            SeekPlayer();
            return;
        }

        MoveToRandomPoint();

    }

    public void SeekPlayer()
    {
        agent.speed = 2;
        Vector3 newPos = player.transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(newPos, out hit, 5, NavMesh.AllAreas))
        {
            newPos = hit.position;
        }
        agent.SetDestination(newPos);

    }
    public void MoveToRandomPoint()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.speed = 5;
            Vector3 newPos = RandomWaypoint();
            agent.SetDestination(newPos);
        }
    }

    public Vector3 RandomWaypoint()
    {
        int randomindex = Random.Range(0, WaypointManager.instance.Waypoints.Count - 1);
        Vector3 newposition = WaypointManager.instance.Waypoints[randomindex].position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(newposition, out hit, 5, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return transform.position;
    }


    
}
