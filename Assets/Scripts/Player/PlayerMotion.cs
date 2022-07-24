using UnityEngine;
using Arcanoid.Components;

namespace Arcanoid.Player
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

        [Tooltip("Точка респа шара"), SerializeField]
        public GameObject _gameObject;

        public PlayerControls _controls;
        public static PlayerMotion instance;

        private static bool _isPlaying = false;

        private void Awake()
        {
            _controls = new PlayerControls();
        }

        private void Start()
        {
            instance = this;
            CheckPlayer();
        }

        private void OnEnable()
        {
            SelectPlaterControls();
        }
        private void Update()
        {
            ApplyGameStart();
        }
        private void FixedUpdate()
        {
            Motion();
        }

        public GameObject GetGameObject { get => _gameObject; }
        public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }
        private bool CheckPlayer() => _player == PlayerSide.FirstPlayer ? true : false;

        private void SelectPlaterControls()
        {
            if (CheckPlayer())
            {
                _controls.FirstPlayer.Enable();
            }
            else _controls.SecondPlayer.Enable();

        }
        private void Motion()
        {
            var value = new Vector3();
            if (_player == PlayerSide.FirstPlayer)
            {
                value = _controls.FirstPlayer.Motion.ReadValue<Vector3>();
            }
            else value = _controls.SecondPlayer.Motion.ReadValue<Vector3>();

            Vector3 direction = new Vector3(value.x, 0f, -value.z);
            GetComponent<Rigidbody>().AddForce(direction, ForceMode.Acceleration);
        }
        private void ApplyGameStart()
        {
            if (_isPlaying) return;
            else if (_controls.FirstPlayer.GameStart.IsPressed())
            {
                BallComponent.instance.OnMotionStart();
                _isPlaying = true;
            }
        }
    }
}