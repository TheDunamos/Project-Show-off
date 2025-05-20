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



    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;
    private CharacterController _controller;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();

    }
    private void Update()
    {
        LeverDoor();
    }

    public void OnInteract(InputValue value)
    {
        InteractInput(value.isPressed);
    }
            public void InteractInput(bool newInteractState)
    {
        interact = newInteractState;
    }

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
