using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AITarget : MonoBehaviour
{
    public Transform target;
    public float distance;

    private NavMeshAgent agent;
    private Animator animator;
    private float m_distance;
    AiTrigger aiTrigger;
    CloseTrigger closeTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aiTrigger = GetComponentInChildren<AiTrigger>();
        closeTrigger = GetComponentInChildren<CloseTrigger>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToRandomPoint();

        if (aiTrigger.playerInTrigger && !closeTrigger.playerIsClose)
        {
            SeekPlayer();
            return;
        }
        if (closeTrigger.playerIsClose && aiTrigger.playerInTrigger)
        {
            //agent.isStopped = true;
            animator.SetBool("Dancing", true);
            return;
        }
        else
        {
            //agent.isStopped = false;
            animator.SetBool("Dancing", false);
            return;
        }

        
    }

    public void SeekPlayer()
    {
        agent.speed = 2;
        Vector3 newPos = target.transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(newPos, out hit, 5, NavMesh.AllAreas))
        {
            newPos = hit.position;
        }
        agent.SetDestination(newPos);
    }

    private void OnAnimatorMove()
    {
        if (animator.GetBool("Dancing") == false)
        {
            agent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
        }
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
