using UnityEngine;

public class CloudWall : MonoBehaviour
{
    public bool Open1 = false;
    public bool Open2 = false;

    private void Update()
    {
        OpeningCheck();
    }

    private void OpeningCheck()
    {
        Animator doorAnim = GetComponent<Animator>();

        if (Open1 == true && Open2 == true)
        {
            doorAnim.SetTrigger("Open");
        }

    }
}
