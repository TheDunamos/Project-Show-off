using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Movement3 : MonoBehaviour
{
    public Animator anim;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool jumped;
    private StarterAssetsInputs _input;
    Vector3 velocity;

    private void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && jumped)
        {
            velocity.y = -2f;
            anim.SetBool("jumpAnim", false);
            jumped = false;
        }


        if (_input.jump && isGrounded)
        {
            anim.SetBool("jumpAnim", true);
            Invoke("jumpTimer", 0.4f);
        }

        if (_input.move != Vector2.zero)
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
