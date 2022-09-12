using Arcanoid.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Arcanoid.Player
{

    public class PlayerHealth : MonoBehaviour
    {
        [Tooltip("Количество общих жизней игроко"), SerializeField, Range(1, 100)]
        private int _playerCurrentHP = 3;
        [Tooltip("объект для вывода текущих ХП на сцене"), SerializeField]
        private Text _playerHPText;
        [Tooltip("объект для вывода надписи экрана смерти"), SerializeField]
        private Text _playerDieText;

        public static PlayerHealth instance;

        public int PlayerHP { get => _playerCurrentHP; set => _playerCurrentHP = value; }

        private void Start()
        {
            instance = this;
        }

        private void Update()
        {
            CheckHealth();
            UpdateHealthStatus();
        }

        private void CheckHealth()
        {
            if (PlayerHP == 0)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPaused = true;
#endif
                _playerDieText.text = "YOU DIED...";
                MenuComponent._gameIsPaused = true;
            }
        }

        private void UpdateHealthStatus()
        {
            _playerHPText.text = " = " + _playerCurrentHP;
        }
    }
}