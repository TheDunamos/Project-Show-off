using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public bool OpenLight = false;
    public bool OpenDark = false;
  

    private void Update()
    {
        OpeningCheck();
    }

    private void OpeningCheck()
    {
        Animator doorAnim = GetComponent<Animator>();

        if (OpenLight == true && OpenDark == true)
        {
            doorAnim.SetTrigger("Open");
        }
    }
}
