using UnityEngine;

public class BlockAnchor : MonoBehaviour
{
    public GameObject PRoot;
    public float xOff;
    public float yOff;
    public float zOff;
    private GameObject VarManager;

    public string playerTag = "Player";
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }
    private void Update()
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        PRoot = GameObject.FindGameObjectWithTag(playerTag);
        InteractionChecks Player = PRoot.gameObject.GetComponent(typeof(InteractionChecks)) as InteractionChecks;
        Vector3 pos = new Vector3(PRoot.transform.position.x + xOff, PRoot.transform.position.y + yOff, PRoot.transform.position.z + zOff);
        transform.position = pos;
     
        transform.rotation = PRoot.transform.rotation;
        
        if(Player.interact == true && Vars.P1Throwable == true)
        {
            Debug.Log("P1Drop");
            Vars.P1Carry = false;
            Vars.P1Throwable = false;
            Destroy(gameObject);
        }
        if (Player.interact == true && Vars.P2Throwable == true)
        {
            Debug.Log("P2Drop");
            Vars.P2Carry = false;
            Vars.P2Throwable = false;
            Destroy(gameObject);
        }
    }
}
