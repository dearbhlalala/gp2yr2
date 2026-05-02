using System.Globalization;
using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;
public class ClickToMoveNetwork : NetworkBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();
    private Animator m_Animator;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            enabled = false;
            return;
        }
    }
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = m_HitInfo.point;
        }
        if (m_Agent.velocity.magnitude != 0f && !Input.GetKey(KeyCode.LeftShift))
        {
            m_Animator.SetBool("Walking", true);
            m_Animator.SetBool("Running", false);

        }
        else if (m_Agent.velocity.magnitude != 0f && Input.GetKey(KeyCode.LeftShift))
        {
            m_Animator.SetBool("Walking", false);
            m_Animator.SetBool("Running", true);
        }
        else
        {
            m_Animator.SetBool("Walking", false);
            m_Animator.SetBool("Running", false);


        }
    }

    private void OnAnimatorMove()
    {
        if (m_Animator.GetBool("Walking"))
        {
            m_Agent.speed = (m_Animator.deltaPosition / Time.deltaTime).magnitude;
        }
        if (m_Animator.GetBool("Running"))
        {
            m_Agent.speed = (m_Animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}
