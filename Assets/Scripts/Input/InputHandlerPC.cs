using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Класс-мост между обьектом и системой ввода
namespace InputSytem
{
    public class InputHandlerPC : MonoBehaviour
    {
        [SerializeField] private GameInput _gameInput;
        private MobComponents.Controllable _controllable;

        private void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
            _controllable = GetComponent<MobComponents.Controllable>();
        }

        private void OnEnable()
        {
            _gameInput.Character.Fire.performed += Fire;
            _gameInput.Character.Dash.performed += Dash;
            _gameInput.Character.Run.performed += RunPerformed;
            _gameInput.Character.Run.canceled += RunCanceled;
            _gameInput.Character.Pause.performed += Pause;
        }

        private void OnDisable()
        {
            _gameInput.Character.Fire.performed -= Fire;
            _gameInput.Character.Dash.performed -= Dash;
            _gameInput.Character.Run.performed -= RunPerformed;
            _gameInput.Character.Run.canceled -= RunCanceled;
            _gameInput.Character.Pause.performed -= Pause;
        }

        private void FixedUpdate()
        {
            ReadMovement();
            ReadGazeDirection();
        }

        private void Fire(InputAction.CallbackContext obj) { }

        private void Dash(InputAction.CallbackContext obj) {
            _controllable.Dash();
        }

        private void RunPerformed(InputAction.CallbackContext obj) 
        {
            _controllable.Run(true);
        }

        private void RunCanceled(InputAction.CallbackContext obj) 
        {
            _controllable.Run(false);
        }

        private void Pause(InputAction.CallbackContext obj) { }

        private void ReadGazeDirection() { }

        private void ReadMovement()
        {
            Vector2 inputDirection = _gameInput.Character.Movement.ReadValue<Vector2>();

            _controllable.ReadMovement(inputDirection.normalized);
        }
    }
}
