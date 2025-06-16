using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatherPickup : MonoBehaviour

{
    public GameObject ThisBush;
    bool heatherSphere;
    public Transform CheckFrom;
    public float playerDistance = 10;
    public LayerMask playerMask;
    public Material newMaterial;
    private AudioSource sound;
    public GameObject Arrow;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        heatherSphere = Physics.CheckSphere(CheckFrom.position, playerDistance, playerMask);

        if (heatherSphere)
        {
            ThisBush.GetComponent<Renderer>().material = newMaterial;
            sound.enabled = true;
            Arrow.SetActive (false);

        }
        /*if (Input.GetKeyDown("space"))
        {
            ThisBush.SetActive(false);
        }*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        ThisBush.SetActive(false);
    }*/
}
