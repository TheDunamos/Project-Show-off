using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using StarterAssets;
using UnityEngine.SceneManagement;



public class InteractionChecks : MonoBehaviour
{
    [Header("Player Select")]
    public bool lightPlayer = true;
    public GameObject PRoot1;
    public GameObject blockDark;
    public GameObject PRoot2;
    public GameObject blockLight;

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


    public UnityEvent onPlayerOnBridge;
    public UnityEvent onPlayerOffBridge;
    public UnityEvent onIsland;
    public UnityEvent ofIsland;

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

        PickupThrow();

        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnInteract(InputValue value)
    {
        InteractInput(value.isPressed);
    }
    public void InteractInput(bool newInteractState)
    {
        interact = newInteractState;
    }

    private void PickupThrow()
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        PRoot1 = GameObject.FindGameObjectWithTag("Player");
        PRoot2 = GameObject.FindGameObjectWithTag("Player2");
        blockDark = Vars.blockDark;
        blockLight = Vars.blockLight;


        if (Vars.P1Throwable == true && interact == true && lightPlayer == true)
        {
            Instantiate(blockDark, transform.position + Vars.offset, transform.rotation);

            Debug.Log("AAAAAH");
        }
        if (Vars.P2Throwable == true && interact == true && lightPlayer == false)
        {
            Instantiate(blockLight, transform.position + Vars.offset, transform.rotation);

            Debug.Log("AAAAAH2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.CompareTag("InteractLight"))
        {
            lightInteract = true;
        }
        if (other.gameObject.CompareTag("InteractDark"))
        {
            darkInteract = true;
        }
        if (other.gameObject.CompareTag("Bridge"))
        {
            onPlayerOnBridge?.Invoke();
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
        if (other.gameObject.CompareTag("Bridge"))
        {
            onPlayerOffBridge?.Invoke();
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
