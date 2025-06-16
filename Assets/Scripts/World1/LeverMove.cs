using UnityEngine;

public class LeverMove : MonoBehaviour
{
    public GameObject door;


    private void Update()
    {
        Dooring();
    }
    void Dooring()
    {
        DoorOpening door1 = door.GetComponent(typeof(DoorOpening)) as DoorOpening;
        Animator Anim = GetComponent<Animator>();
        if (door1.OpenLight == true && gameObject.tag == "InteractLight")
        {
           Anim.SetTrigger("Down");
        }
        if (door1.OpenDark == true && gameObject.tag == "InteractDark")
        {
            Anim.SetTrigger("Down");
        }
    }


}
