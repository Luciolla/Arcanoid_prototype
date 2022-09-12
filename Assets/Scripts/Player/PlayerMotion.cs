using UnityEngine;
using Arcanoid.Components;

namespace Arcanoid.Player
{
    public class PlayerMotion : MonoBehaviour
    {
        private static bool IsGameStart = false;

        [Tooltip("Выбор управления"), SerializeField]
        private PlayerSideEnum _player;

        [Tooltip("Точка респа шара"), SerializeField]
        public GameObject _gameObject;

        public PlayerControls _controls;
        public static PlayerMotion instance;

        public GameObject GetGameObject { get => _gameObject; }
        public bool IsPlaying { get => IsGameStart; set => IsGameStart = value; }

        private void Awake()
        {
            _controls = new PlayerControls();
        }

        private void OnEnable()
        {
            SelectPlaterControls();
        }

        private void Start()
        {
            instance = this;
            CheckPlayer();
        }

        private void Update()
        {
            ApplyGameStart();
        }
        private void FixedUpdate()
        {
            MovePlayer();
#if UNITY_EDITOR
            EditorMovementCheck();
#endif
        }

        private bool CheckPlayer() => _player == PlayerSideEnum.FirstPlayer ? true : false;

        private void SelectPlaterControls()
        {
            if (CheckPlayer())
            {
                _controls.FirstPlayer.Enable();
            }
            else _controls.SecondPlayer.Enable();

        }
        private void MovePlayer()
        {
            var value = new Vector3();
            if (_player == PlayerSideEnum.FirstPlayer)
            {
                value = _controls.FirstPlayer.Motion.ReadValue<Vector3>();
            }
            else value = _controls.SecondPlayer.Motion.ReadValue<Vector3>();

            Vector3 direction = new Vector3(value.x, 0f, -value.z);
            GetComponent<Rigidbody>().AddForce(direction, ForceMode.Acceleration);
        }

#if UNITY_EDITOR
        private void EditorMovementCheck()
        {
            var changePosition = new Vector3();
            if (Input.GetKey(KeyCode.UpArrow))
            {
                changePosition += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                changePosition += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                changePosition += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                changePosition += new Vector3(1, 0, 0);
            }

            Vector3 direction = new Vector3(changePosition.x, 0f, -changePosition.z);
            GetComponent<Rigidbody>().AddForce(direction, ForceMode.Acceleration);
        }
#endif

        private void ApplyGameStart()
        {
            if (IsGameStart == true) return;
            else if (_controls.FirstPlayer.GameStart.IsPressed())
            {
                BallComponent.instance.OnMotionStart();
                IsGameStart = true;
            }
        }
    }
}