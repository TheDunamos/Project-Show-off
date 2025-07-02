using UnityEngine;

public class CamTransition : MonoBehaviour
{

    public GameObject nextRespawn;
    [Header("Player1")]
    public GameObject cam1;
    public GameObject cam2;
    public bool P1Past = false;
    
    [Header("Player2")]
    public GameObject cam3;
    public GameObject cam4;
    public bool P2Past = false;

    private GameObject VarManager;
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }
    private void CamSwitch()
    {
        if (P1Past == true && P2Past == true)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(true);
            Debug.Log("CamSwitched" + cam2.gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (other.gameObject.CompareTag("Player"))
        {
            P1Past = true;
            Vars.P1Respawn = nextRespawn;
            CamSwitch();
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            P2Past = true;
            Vars.P2Respawn = nextRespawn;
            CamSwitch();
        }
    }

    
}
