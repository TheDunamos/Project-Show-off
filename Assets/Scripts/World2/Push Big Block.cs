using UnityEngine;


public class PushBigBlock : MonoBehaviour
{
    public GameObject player;
    public bool inCollider = false;
    public string PlaySelect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlaySelect) )
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag(PlaySelect))
        {
            inCollider = false;
        }
    }

    private void Update()
    {
        InteractionChecks checking = player.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
        Animator blockAnim = GetComponent<Animator>();
        Transform moving = GetComponent<Transform>();


        if (inCollider == true && checking.interact == true)
        {
            blockAnim.SetTrigger("Moved");
        }

    }

}
