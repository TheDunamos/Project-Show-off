using UnityEngine;

public class BlockAnchor : MonoBehaviour
{
    public GameObject PRoot;
    public float xOff;
    public float yOff;
    public float zOff;

    private void Update()
    {
        PRoot = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = new Vector3(PRoot.transform.position.x + xOff, PRoot.transform.position.y + yOff, PRoot.transform.position.z + zOff);
        transform.position = pos;
     
        transform.rotation = PRoot.transform.rotation;
    }
}
