using System.Collections;
using Arcanoid.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Arcanoid.Components
{
    public class MenuComponent : MonoBehaviour
    {
        public static int _activeScene;
        public static bool _gameIsPaused = false;

        [Header("Список меню")]
        [SerializeField]
        private GameObject _pauseMenuUI;

        [SerializeField] private GameObject _optionsMenuUI;
        [SerializeField] private GameObject _mainMenuUI;

        [Header("Кнопки главного меню")]
        [SerializeField]
        private Button _newGameButtonMain;

        [SerializeField] private Button _optionsButtonMain;
        [SerializeField] private Button _exitButtonMain;

        [Header("Кнопки меню настроек")]
        [SerializeField]
        private Button _backButton;

        [Header("Кнопки меню-паузы")]
        [SerializeField]
        private Button _resumeButton;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;

        private Coroutine _closeAnimationCoroutine = null;
        private Coroutine _openAnimationCoroutine = null;
        private Coroutine _twoCoroutinesCoroutine = null;

        private void Start()
        {
            _activeScene = SceneManager.GetActiveScene().buildIndex;
        }

        private void Update()
        {
            if (_activeScene == 0) return;
            {
                ApplyPause();
                RestartCheck();
            }
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene(1);
            GameLog.instance.WriteLogChecker(GameLogEnum.Start);
        }

        private void RestartCheck()
        {
            if (_pauseMenuUI.activeSelf == false && _optionsMenuUI.activeSelf == false && _gameIsPaused == true)
            {
                ApplyResume(); //без этого рестарт кривой... не спрашивайте...
                PlayerMotion.instance.IsPlaying = false;
            }
        }

        private void ApplyPause()
        {
            if (Keyboard.current[Key.Escape].wasPressedThisFrame)
            {
                if (_activeScene == 0) Application.Quit();

                if (_optionsMenuUI.activeSelf == true) GoBack();
                else if (_pauseMenuUI.activeSelf == false)
                {
                    GameLog.instance.WriteLogChecker(GameLogEnum.Pause);
                    _gameIsPaused = true;
                    _pauseMenuUI.transform.localScale = new Vector3(0.01f, 0.01f, 1);
                    _pauseMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    OpenPanelAnimation(_pauseMenuUI);
                }
                else ApplyResume();
            }
        }

        private void OpenPreferences()
        {
            GameLog.instance.WriteLogChecker(GameLogEnum.MainMenu);
            var _panel = PanelSearch();
            _gameIsPaused = true;
            _optionsMenuUI.transform.localScale = new Vector3(0.01f, 0.01f, 1);
            _optionsMenuUI.SetActive(true);
            _twoCoroutinesCoroutine = StartCoroutine(TwoCoroutinesCoroutine(_panel, _optionsMenuUI));
        }

        private void GoBack()
        {
            var _panel = PanelSearch();
            GameLog.instance.WriteLogChecker(GameLogEnum.Pause);
            _panel.SetActive(true);
            _twoCoroutinesCoroutine = StartCoroutine(TwoCoroutinesCoroutine(_optionsMenuUI, _panel));
        }
        private void ApplyResume()
        {
            GameLog.instance.WriteLogChecker(GameLogEnum.Resume);
            _gameIsPaused = false;
            ClosePanelAnimation(_pauseMenuUI);
        }

        private void StopGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
            Debug.Log("Игра остановлена");
#endif
            GameLog.instance.WriteLogChecker(GameLogEnum.Exit);
            Application.Quit();
        }

        private void RestartLevel()
        {
            GameLog.instance.WriteLogChecker(GameLogEnum.Restart);
            StartNewGame();
        }

        private void ClosePanelAnimation(GameObject _panel)
        {
            _closeAnimationCoroutine = StartCoroutine(CloseAnimationCoroutine(_panel));
        }

        private void OpenPanelAnimation(GameObject _panel)
        {
            _openAnimationCoroutine = StartCoroutine(OpenAnimationCoroutine(_panel));
        }

        private GameObject PanelSearch()
        {
            _activeScene = SceneManager.GetActiveScene().buildIndex;
            if (_activeScene == 1)
            {
                var _panel = _pauseMenuUI;
                return _panel;
            }

            if (_activeScene == 0)
            {
                var _panel = _mainMenuUI;
                return _panel;
            }
            else return null;
        }

        private IEnumerator CloseAnimationCoroutine(GameObject _panel)
        {
            while (_panel.transform.localScale.x >= 0.01)
            {
                _panel.transform.localScale = new Vector3(_panel.transform.localScale.x - 0.1f,
                    _panel.transform.localScale.y - 0.1f, 1);
                yield return new WaitForSecondsRealtime(Time.deltaTime);
            }

            _panel.SetActive(false);
            if (_gameIsPaused == false)
            {
                Time.timeScale = 1f;
            }

            yield break;
        }

        private IEnumerator OpenAnimationCoroutine(GameObject _panel)
        {
            while (_panel.transform.localScale.x < 1)
            {
                _panel.transform.localScale = new Vector3(_panel.transform.localScale.x + 0.1f,
                    _panel.transform.localScale.y + 0.1f, 1);
                yield return new WaitForSecondsRealtime(Time.deltaTime);
            }

            AllButtonsTurnOn();
            yield break;
        }

        private IEnumerator TwoCoroutinesCoroutine(GameObject _panelToClose, GameObject _panelToOpen)
        {
            yield return CloseAnimationCoroutine(_panelToClose);
            yield return OpenAnimationCoroutine(_panelToOpen);
            yield break;
        }

        #region "включение и отключение кнопок"

        private void UnButtonMainMenu()
        {
            _newGameButtonMain.interactable = false;
            _optionsButtonMain.interactable = false;
            _exitButtonMain.interactable = false;
        }

        private void ButtonMainMenu()
        {
            _newGameButtonMain.interactable = true;
            _optionsButtonMain.interactable = true;
            _exitButtonMain.interactable = true;
        }

        private void UnButtonPreferencesMenu()
        {
            _backButton.interactable = false;
        }

        private void ButtonPreferencesMenu()
        {
            _backButton.interactable = true;
        }

        private void UnButtonPauseMenu()
        {
            _resumeButton.interactable = false;
            _restartButton.interactable = false;
            _optionsButton.interactable = false;
            _exitButton.interactable = false;
        }

        private void ButtonPauseMenu()
        {
            _resumeButton.interactable = true;
            _restartButton.interactable = true;
            _optionsButton.interactable = true;
            _exitButton.interactable = true;
        }

        private void AllButtonsTurnOn()
        {
            ButtonCheckTurnOn(_newGameButtonMain);
            ButtonCheckTurnOn(_optionsButtonMain);
            ButtonCheckTurnOn(_exitButtonMain);
            ButtonCheckTurnOn(_backButton);
            ButtonCheckTurnOn(_resumeButton);
            ButtonCheckTurnOn(_optionsButton);
            ButtonCheckTurnOn(_restartButton);
            ButtonCheckTurnOn(_exitButton);
        }

        private void AllButtonsTurnOff()
        {
            ButtonCheckTurnOff(_newGameButtonMain);
            ButtonCheckTurnOff(_optionsButtonMain);
            ButtonCheckTurnOff(_exitButtonMain);
            ButtonCheckTurnOff(_backButton);
            ButtonCheckTurnOff(_resumeButton);
            ButtonCheckTurnOff(_optionsButton);
            ButtonCheckTurnOff(_restartButton);
            ButtonCheckTurnOff(_exitButton);
        }

        private void ButtonCheckTurnOn(Button _button)
        {
            if (_button != null)
            {
                _button.interactable = true;
            }
        }

        private void ButtonCheckTurnOff(Button _button)
        {
            if (_button != null)
            {
                _button.interactable = false;
            }
        }

        #endregion
    }
}