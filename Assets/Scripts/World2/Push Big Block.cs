using UnityEngine;

public class PushBigBlock : MonoBehaviour
{
    public bool inCollider = false;

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


    // get other objects "interact" value from InteractinChecks, use update to check if interact and inCollider are true. set anim bool to true.
}
