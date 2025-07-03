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
        Animator IslandAnim = MovingPlate.GetComponent(typeof(Animator)) as Animator;
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject P1 = GameObject.FindGameObjectWithTag("Player");
            GameObject P2 = GameObject.FindGameObjectWithTag("Player2");
            P1.transform.position = Vars.P1Respawn.transform.position;
            P2.transform.position = Vars.P1Respawn.transform.position;
            Physics.SyncTransforms();
            IslandAnim.SetTrigger("Reset");
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("yes");
            GameObject P1 = GameObject.FindGameObjectWithTag("Player");
            GameObject P2 = GameObject.FindGameObjectWithTag("Player2");

            P2.transform.position = Vars.P2Respawn.transform.position;
            P1.transform.position = Vars.P2Respawn.transform.position;
            Physics.SyncTransforms();

        }

    }

}
