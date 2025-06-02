using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 12f;

    public float turnSmoothTime = 0.05f;
    float turnSmoothVelocity;

    //gravity related magic
    public float gravity = -9.81f;
    public float jumpNormalHeight = 3f;
    public float jumpChainHeight = 6f;
    public float jumpHeight = 3f;
    bool jumpChainTimer = false;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public CinemachineFreeLook FreeLookCam;
    public CinemachineCameraOffset offsetExtension;

    float fovVelocity = 0.0f;
    public float smoothTime = 0.5f;

    public bool walking;
    bool running = false;

    public Animator anim;

    void Start()
    {
        jumpHeight = jumpNormalHeight;

        offsetExtension = FreeLookCam.GetComponent<CinemachineCameraOffset>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            Invoke("jumpTimer", 0.1f);

            anim.SetBool("jumpAnim", false);
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            CancelInvoke("jumpTimer");
            jumpHeight = jumpChainHeight;

            anim.SetBool("jumpAnim", true);
        }

        if (Input.GetButtonUp("Jump") && velocity.y >= 0f)
        {
            velocity.y = 0f;
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            //anim.SetFloat("Speed", 0.5f);

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking = true;
            anim.SetFloat("Speed", 0.5f);
        }

        else
        {
            walking = false;
            anim.SetFloat("Speed", 0f);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float targetFOV = Input.GetKey(KeyCode.LeftShift) ? 50f : 40f;
        FreeLookCam.m_Lens.FieldOfView = Mathf.SmoothDamp(FreeLookCam.m_Lens.FieldOfView, targetFOV, ref fovVelocity, smoothTime);

        //float targetOffset = Input.GetKey(KeyCode.D) ? 4f : 0f;
        //offsetExtension.m_Offset.x = Mathf.SmoothDamp(offsetExtension.m_Offset.x, targetOffset, ref fovVelocity, smoothTime);


        if (walking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.8f;
            //FreeLookCam.m_Lens.FieldOfView = 50f;
            //float smoothFast = Mathf.SmoothDamp(FreeLookCam.m_Lens.FieldOfView, 70, ref fovVelocity, smoothTime);
            //FreeLookCam.m_Lens.FieldOfView = Mathf.SmoothDamp(FreeLookCam.m_Lens.FieldOfView, 70, ref fovVelocity, smoothTime);

            running = true;
            anim.SetFloat("Speed", 1f);
        }
        if (running && Input.GetKeyUp(KeyCode.LeftShift))//else
        {
            speed /= 1.8f;
            //FreeLookCam.m_Lens.FieldOfView = 40f;
            running = false;
        }


    }
    void jumpTimer()
    {
        jumpHeight = jumpNormalHeight;
    }
}
