using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower2 : MonoBehaviour
{
    public GameObject player;
    public GameObject freeLookCam;
    public GameObject target;

    public float downSmooth = 0.3f;
    public float upSmooth = 0.3f;
    float yVelocity = 0.0f;
    //private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //transform all axes \/
        //transform.position = player.transform.position;

        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        pos.z = player.transform.position.z;
        float targetY = player.transform.position.y;

        //player falls
        if (player.transform.position.y <= transform.position.y)
        {
            //pos.y = player.transform.position.y;
            pos.y = Mathf.SmoothDamp(pos.y, targetY, ref yVelocity, downSmooth);
        }

        //player jumps
        else
        {
            pos.y = Mathf.SmoothDamp(pos.y, targetY, ref yVelocity, upSmooth);
        }

        transform.position = pos;

        Vector3 camRotation = freeLookCam.transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, camRotation.y, 0f);

        //Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //transform.LookAt(targetPosition);
    }
}
