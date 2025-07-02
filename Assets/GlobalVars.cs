using UnityEngine;
/*using Adobe.Substance.Runtime;*/

public class GlobalVars : MonoBehaviour
{
    public bool P1Carry = false;
    public bool P1Throwable = false;
    public float delayP1 = 0.5f;
    public float delayTimerP1 = 0f;
    public GameObject blockDark;
    public GameObject blockLight;
    public Vector3 offset = new Vector3(1, 2, 0);
    public float throwForce = 8f;

    public bool P2Carry = false;
    public bool P2Throwable = false;
    public float delayP2 = 0.5f;
    public float delayTimerP2 = 0f;

    public GameObject P1Respawn;
    public GameObject P2Respawn;


    public bool P1Lamp = false;
    public bool P2Lamp = false;

    public bool LampsOn = false;

    public void Update()
    {
        if(P1Carry == true)
        {
           if(delayTimerP1 > 0f)
            {
                delayTimerP1 -= Time.deltaTime;
                if(delayTimerP1 <= 0f)
                {
                    P1Throwable = true;
                }
            }
        }
        if (P2Carry == true)
        {
            if (delayTimerP2 > 0f)
            {
                delayTimerP2 -= Time.deltaTime;
                if (delayTimerP2 <= 0f)
                {
                    P2Throwable = true;
                }
            }
        }


    }

}