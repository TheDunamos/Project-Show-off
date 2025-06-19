using UnityEngine;

public class throwmove : MonoBehaviour
{

    private GameObject VarManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        GetComponent<Rigidbody>().AddForce(transform.forward * Vars.throwForce, ForceMode.Impulse);

    }


}
