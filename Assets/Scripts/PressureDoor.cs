using UnityEngine;

public class PressureDoor : MonoBehaviour
{
    public bool Opened = false;



    private void Update()
    {
        OpeningCheck();
    }

    private void OpeningCheck()
    {
        Animator doorAnim = GetComponent<Animator>();

        if (Opened == true)
        {
            doorAnim.SetTrigger("Open");
        }
        if (Opened == false)
        {
            doorAnim.SetTrigger("Close");
        }
    }
}
