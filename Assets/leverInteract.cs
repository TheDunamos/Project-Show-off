using UnityEngine;

public class leverInteract : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lever"))
        {
            Destroy(other.gameObject);
        }
    }
}
