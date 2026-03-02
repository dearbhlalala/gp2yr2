using UnityEngine;

public class EnemyAnim : MonoBehaviour
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
        animator.SetFloat("vAxisInput", verticalInput);
        animator.SetFloat("hAxisInput", horizontalInput);

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("runBool", true);

        }
        else
        {
            animator.SetBool("runBool", false);


        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetLayerWeight(1, 0.5f);
        }
        else
        {
            animator.SetLayerWeight(1, 0.0f);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jumpBool", true);
            UnityEngine.Debug.Log("jump");

        }
        else
        {
            animator.SetBool("jumpBool", false);

        }*/

    }
}
