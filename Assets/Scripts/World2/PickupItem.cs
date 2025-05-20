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
    public bool Player2 = false;
    public GameObject whiteCube;
    public GameObject blackCube;


    private void OnTriggerStay(Collider other)
    {
        InteractionChecks Player = other.gameObject.GetComponent(typeof(InteractionChecks)) as InteractionChecks;

        if(Player.lightPlayer == true && Player.interact == true){
            Player1 = true;

        }
        if(Player.lightPlayer == false && Player.interact == true)
        {
            Player2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InteractionChecks Player = other.gameObject.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
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
