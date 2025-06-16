using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;



public class InteractionChecks : MonoBehaviour
{
    [Header("Player Select")]
    public bool lightPlayer = true;

    [Header("Light Player")]
    public bool lightInteract = false;

    [Header("Dark Player")]
    public bool darkInteract = false;

    [Header("Interactions")]
    public bool interact = false;
    public GameObject FirstDoor;


    private GameObject VarManager;
    private GameObject Block1;
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;
    private CharacterController _controller;
    private Rigidbody rib;
    private Component AnchorScript;
    private Component BobnScript;

    private void Start()
    {

        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        VarManager = GameObject.FindGameObjectWithTag("VarManager");

    }
    private void Update()
    {

        LeverDoor();
/*        PickupThrow();
*/    }

    public void OnInteract(InputValue value)
    {
        InteractInput(value.isPressed);
    }
    public void InteractInput(bool newInteractState)
    {
        interact = newInteractState;
    }

   /* private void PickupThrow()
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;

        if(Vars.P1Carry == true && interact == true)
        {
            
            Block1 = GameObject.FindGameObjectWithTag("PickupP1");
            BlockAnchor AnchorScript = Block1.GetComponentInChildren(typeof(BlockAnchor)) as BlockAnchor;
            BlockBobn BobnScript = Block1.GetComponentInChildren(typeof(BlockBobn)) as BlockBobn;
            
            rib = Block1.GetComponentInChildren<Rigidbody>();
            Destroy(AnchorScript);
            Destroy(BobnScript);
            rib.AddForce (10,0,0);
            rib.isKinematic = true;

            Debug.Log("AAAAAH");
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractLight"))
        {
            lightInteract = true;
        }
        if (other.gameObject.CompareTag("InteractDark"))
        {
            darkInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InteractLight"))
        {
            lightInteract = false;
        }
        if (other.gameObject.CompareTag("InteractDark"))
        {
            darkInteract = false;
        }

    }



    private void LeverDoor()
    {
        DoorOpening door1 = FirstDoor.GetComponent(typeof(DoorOpening)) as DoorOpening;

        if (interact == true && lightInteract == true)
        {
            door1.OpenLight = true;
        }
        if (interact == true && darkInteract == true)
        {
            door1.OpenDark = true;
        }
    }
}
