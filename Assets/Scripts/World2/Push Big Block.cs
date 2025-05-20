using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class PushBigBlock : MonoBehaviour
{
    public GameObject player;
    public bool inCollider = false;
    public Vector3 movement;
   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            inCollider = false;
        }
    }

    private void Update()
    {
        InteractionChecks checking = player.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
        Animator blockAnim = GetComponent<Animator>();
        Transform moving = GetComponent<Transform>();


        if (inCollider == true && checking.interact == true)
        {
            blockAnim.SetTrigger("Moved");
        }

    }


    // get other objects "interact" value from InteractionChecks, use update to check if interact and inCollider are true. set anim bool to true.
}
