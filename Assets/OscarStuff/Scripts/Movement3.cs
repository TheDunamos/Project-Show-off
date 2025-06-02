using UnityEngine;

public class Movement3 : MonoBehaviour
{
    public Animator anim;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool jumped;

    Vector3 velocity;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && jumped)
        {
            velocity.y = -2f;
            anim.SetBool("jumpAnim", false);
            jumped = false;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("jumpAnim", true);
            Invoke("jumpTimer", 0.4f);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", 0.5f);
        }

        else
        {
            anim.SetFloat("Speed", 0f);
        }

    }

    void jumpTimer()
    {
        jumped = true;
    }
}
