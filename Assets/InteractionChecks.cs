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


        [Header("Dark Player")]
        public bool darkInteract = false;


        [Header("Interactions")]
        public bool DoorOpen = false;
        public GameObject door1;


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
            LeverSwitch();
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
            if (lightPlayer == true)
            {
                lightInteract = false;
            }
            if (lightPlayer == false)
            {
                darkInteract = false;
            }

        }

        private void LeverSwitch()
        {
            Animator doorAnim = door1.GetComponent<Animator>();

            if (_input.interact == true && lightInteract == true)
            {
                DoorOpen = true;

                doorAnim.SetTrigger("Open");
            }
        }
    }
}