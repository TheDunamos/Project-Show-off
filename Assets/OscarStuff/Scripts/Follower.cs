using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject player;

    public float smooth = 0.3f;
    float yVelocity = 0.0f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //float newPositionx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref yVelocity, smooth);
        //float newPositionz = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref yVelocity, smooth);

        //Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);

        //Quaternion targetRotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, smooth);
        //transform.rotation = targetRotation;
    }
}
