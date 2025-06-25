using UnityEngine;

public class playerDrag : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            P1.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        P1.transform.SetParent(null);
    }
}
