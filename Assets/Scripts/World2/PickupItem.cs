using UnityEngine;


public class PickupItem : MonoBehaviour
{

    /*Check if player is in trigger area.
     check for interaction and check player colour.
     Spawn prefab of the floating object.

     Prefab: Float up and down using sin wave
     Have two colour options.
    */
    public bool Player1 = false;
    public GameObject armature1;

    public bool Player2 = false;
    public GameObject armature2;

    public GameObject whiteCube;
    public GameObject blackCube;

    private GameObject VarManager;


    private void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");

    }

    private void OnTriggerStay(Collider other)
    {
        InteractionChecks Player = other.gameObject.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (Player.lightPlayer == true && Player.interact == true && Vars.P1Carry == false){
            Player1 = true;
            Vars.P1Carry = true;
            Instantiate(whiteCube);
        }
        if(Player.lightPlayer == false && Player.interact == true && Vars.P2Carry == false)
        {
            Player2 = true;
            Vars.P2Carry = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InteractionChecks Player = other.gameObject.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (Player.lightPlayer == true)
        {
            Player1 = false;

        }
        if (Player.lightPlayer == false)
        {
            Player2 = false;
        }
    }
}
