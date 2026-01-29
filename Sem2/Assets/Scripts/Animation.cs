using System.Diagnostics;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;

    float verticalInput;
    float horizontalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

    }

    void FixedUpdate()
    {
        animator.SetFloat ("vAxisInput", verticalInput);
        animator.SetFloat ("hAxisInput", horizontalInput);
        
        if (Input.GetKey (KeyCode.Z))
        {
            animator.SetBool ("runBool", true);
            UnityEngine.Debug.Log("Run");
        }
        else
        {
            animator.SetBool ("runBool", false);
            UnityEngine.Debug.Log(" No Run");
            
        }
    }
}
