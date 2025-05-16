using UnityEngine;
using UnityEngine.InputSystem;


namespace StarterAssets
{
    public class InteractionChecks : MonoBehaviour
    {
        [Header("Player Select")]
        public bool lightPlayer = true;

        [Header("Light Player")]
        public bool lightInteract = false;
        private bool Door1Light = false;


        [Header("Dark Player")]
        public bool darkInteract = false;
        private bool Door1Dark = false;

        [Header("Interactions")]
        public bool interact = false;
        public GameObject door1;


        [Header("Double Button Door")]
        public GameObject pressure1;
        bool pressed1 = false;
        public GameObject pressure2;
        bool pressed2 = false;
        public GameObject door2;
        bool door2Open = false;



        public GameObject pressure3;
        public GameObject pressure4;
        public GameObject cloudWall;


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
           DoubleDoor();
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
            
            if(other.gameObject == pressure1  )
            {
                door2Open = true;
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
            if (other.gameObject == pressure1);

        }

        private void DoubleDoor()
        {
            Animator doorAnim2 = door2.GetComponent <Animator>();
            if(door2Open == true)
            {

            }

            
        }


        private void LeverDoor()
        {
            Animator doorAnim = door1.GetComponent<Animator>();

            if (interact == true && lightInteract == true)
            {
                Door1Light = true;
            }
            if (interact == true && darkInteract == true)
            {
                Door1Dark = true;
            }
            if (Door1Light == true && Door1Dark == true)
            {
                doorAnim.SetTrigger("Open");
            }
        }
    }
}