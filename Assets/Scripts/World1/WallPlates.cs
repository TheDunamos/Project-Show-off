using UnityEngine;

public class WallPlates : MonoBehaviour
{

    public Component door;
    private bool Plate1 = false;

    private void OnTriggerStay(Collider other)
    {
        CloudWall door1 = door.GetComponent(typeof(CloudWall)) as CloudWall;
        if (other.gameObject.CompareTag("Player") && Plate1 == true)
        {
            door1.Open1 = true;
            Debug.Log("Open");
        }
        if (other.gameObject.CompareTag("Player2") && Plate1 == false)
        {
            door1.Open2 = true;
            Debug.Log("Open2");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CloudWall door1 = door.GetComponent(typeof(CloudWall)) as CloudWall;
        if (other.gameObject.CompareTag("Player") && Plate1 == true)
        {
            door1.Open1 = false;
            Debug.Log("Close");
        }
        if (other.gameObject.CompareTag("Player2") && Plate1 == false)
        {
            door1.Open2 = false;
            Debug.Log("Close2");
        }
    }
}
