using UnityEngine;

public class RespawnEnding : MonoBehaviour
{
    private GameObject VarManager;
    public GameObject MovingPlate;
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }

    private void OnTriggerEnter(Collider other)
    {

        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = Vars.P1Respawn.transform.position;
            Physics.SyncTransforms();
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("yes");

            other.transform.position = Vars.P2Respawn.transform.position;
            Physics.SyncTransforms();

        }

    }

}
