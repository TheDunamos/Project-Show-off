using UnityEngine;

public class SpawnTransitionOnly : MonoBehaviour
{
    public GameObject nextRespawn;


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
          
            Vars.P1Respawn = nextRespawn;
      
        }
        if (other.gameObject.CompareTag("Player2"))
        {
        
            Vars.P2Respawn = nextRespawn;
 
        }
    }
}
