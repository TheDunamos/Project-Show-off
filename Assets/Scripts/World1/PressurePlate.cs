using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Component door;

    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        PressureDoor door1 = door.GetComponent(typeof(PressureDoor)) as PressureDoor;
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            door1.Opened = true;
            Debug.Log("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PressureDoor door1 = door.GetComponent(typeof(PressureDoor)) as PressureDoor;
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            door1.Opened = false;
            Debug.Log("Close");
        }
    }
}
