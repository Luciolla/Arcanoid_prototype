using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


namespace Assets.Scripts.Player
{
    public enum PlayerSide
    {
        FirstPlayer,
        SecondPlayer
    }

    public class PlayerMotion : MonoBehaviour
    {
        [Tooltip("Выбор управления"), SerializeField]
        private PlayerSide _player;

        public PlayerControls _controls;

        private Vector3 _object;

        private void Awake()
        {
            _controls = new PlayerControls();
        }

        private void Start()
        {
            CheckPlayer();
        }

        private void OnEnable()
        {
            SelectPlaterControls();
        }

        private void FixedUpdate()
        {
            Motion();
        }
        private bool CheckPlayer() => _player == PlayerSide.FirstPlayer ? true : false;

        private void SelectPlaterControls()
        {
            if (CheckPlayer() == true)
            {
                _controls.FirstPlayer.Enable();
                Debug.Log("первый");
            }
            else if (CheckPlayer() == false)
            {
                _controls.SecondPlayer.Enable();
                Debug.Log("второй");
            }
        }

        private void Motion()
        {
            var value = new Vector3();
            if (_player == PlayerSide.FirstPlayer)
            {
                value = _controls.FirstPlayer.Motion.ReadValue<Vector3>();
            }
            else if (_player == PlayerSide.FirstPlayer)
            {
                value = _controls.FirstPlayer.Motion.ReadValue<Vector3>();
            }
            Vector3 direction = new Vector3(value.x, 0f, -value.z);
            GetComponent<Rigidbody>().AddForce(direction, ForceMode.Acceleration);
        }
    }
}