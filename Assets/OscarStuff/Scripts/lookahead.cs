using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookahead : MonoBehaviour
{
    public GameObject targetCenter;
    public GameObject targetLeft;
    public GameObject targetRight;

    public float smooth = 1f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    

    void Update()
    {
        Transform target;

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position = Vector3.SmoothDamp(transform.position, targetRight.transform.position, ref velocity, smooth);
            target = targetRight.transform;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            //transform.position = Vector3.SmoothDamp(transform.position, targetLeft.transform.position, ref velocity, smooth);
            target = targetLeft.transform;
        }

        else
        {
            //transform.position = Vector3.SmoothDamp(transform.position, targetCenter.transform.position, ref velocity, smooth);
            target = targetCenter.transform;
        }

        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smooth);



        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);

    }
}
