using UnityEngine;

public class Movement4 : MonoBehaviour
{
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform swayReference; 
    private Vector3 lastSwayPosition;
    private bool onBridge;

    Vector3 velocity;

    void Start()
    {
        lastSwayPosition = swayReference.position;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        RaycastHit hit;
        onBridge = Physics.SphereCast(groundCheck.position, groundDistance, Vector3.down, out hit, 0.1f, groundMask)
                   && hit.collider.CompareTag("Bridge");

        Vector3 swayDelta = swayReference.position - lastSwayPosition;
        Vector3 horizontalDelta = new Vector3(swayDelta.x, 0f, swayDelta.z);
        transform.position += horizontalDelta * 2;

        /*if (onBridge)
        {
            Vector3 swayDelta = swayReference.position - lastSwayPosition;
            transform.position += new Vector3(swayDelta.x, 0f, swayDelta.z); // Apply horizontal sway only
        }*/

        lastSwayPosition = swayReference.position;

    }
}
