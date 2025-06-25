using UnityEngine;

public class CamTransition : MonoBehaviour
{

    public GameObject nextRespawn;
    [Header("Player1")]
    public GameObject cam1;
    public GameObject cam2;
    
    [Header("Player2")]
    public GameObject cam3;
    public GameObject cam4;

    private GameObject VarManager;
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (other.gameObject.CompareTag("Player"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            Vars.P1Respawn = nextRespawn;
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            cam3.SetActive(false);
            cam4.SetActive(true);
            Vars.P2Respawn = nextRespawn;
        }
    }
}
