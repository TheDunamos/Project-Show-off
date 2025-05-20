using UnityEngine;

public class BlockAnchor : MonoBehaviour
{
    public GameObject PRoot;

    private void Update()
    {
        transform.position = PRoot.transform.position;
        transform.rotation = PRoot.transform.rotation;
    }
}
