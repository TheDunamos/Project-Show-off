using UnityEngine;

public class CamTransition : MonoBehaviour
{

    [Header("Player1")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Player2")]
    public GameObject cam3;
    public GameObject cam4;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            cam3.SetActive(false);
            cam4.SetActive(true);
        }
    }
}
