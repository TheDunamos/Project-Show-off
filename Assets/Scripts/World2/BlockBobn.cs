using UnityEngine;

public class BlockBobn : MonoBehaviour
{
    public float speedUpDown = 3;
    public float distanceUpDown = 1;
    void Start()
    {

    }

    void Update()
    {
        Vector3 mov = new Vector3(transform.position.x, Mathf.Sin(speedUpDown * Time.time) * distanceUpDown + transform.parent.position.y, transform.position.z);
        transform.position = mov;
        transform.rotation = transform.parent.rotation;
    }
}
