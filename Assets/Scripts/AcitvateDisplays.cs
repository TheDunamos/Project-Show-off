using UnityEngine;
using System.Collections;

public class AcitvateDisplays : MonoBehaviour
{
  
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }

    }

 
}
