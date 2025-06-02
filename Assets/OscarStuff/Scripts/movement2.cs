using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 5f;
    public Transform cam;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        controller.Move(move.normalized * Time.deltaTime * Speed);
    }
}
