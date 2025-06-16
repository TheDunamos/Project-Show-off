using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class adobeHell: MonoBehaviour
{
    public Material M1;
    public Material M2;
    MeshRenderer Mrender;
    GameObject VarManager;

    private void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }

    private void Update()
    {
        ColourChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (Vars.P1Carry == true)
        {
            Vars.LampsOn = true;
        }
        if (Vars.P1Carry == false)
        {
            Vars.LampsOn = false;
        }

    }

    void ColourChange()
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;

        if (Vars.LampsOn == true)
        {
            Mrender = GetComponent<MeshRenderer>();
            Mrender.material = M2;
        }
        if (Vars.LampsOn == false)
        {
            Mrender = GetComponent<MeshRenderer>();
            Mrender.material = M1;
        }
    }
}