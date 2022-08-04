using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuComponent : MonoBehaviour
{
    public static int _activeScene;
    public static bool _gameIsPaused = false;

    private Coroutine _closeAnimationCoroutine = null;
    private Coroutine _openAnimationCoroutine = null;
    private Coroutine _twoCoroutinesCoroutine = null;

    //public delegate void RestartLevelDelegate();
    [Header("Список меню")]
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject _mainMenuUI;

    [Header("Кнопки главного меню")]
    [SerializeField] private Button _newGameButtonMain;
    [SerializeField] private Button _optionsButtonMain;
    [SerializeField] private Button _exitButtonMain;

    [Header("Кнопки меню настроек")]
    [SerializeField] private Button _backButton;

    [Header("Кнопки меню-паузы")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;

    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Preferences()
    {
        var _panel = PanelSearch();
        _gameIsPaused = true;
        _optionsMenuUI.transform.localScale = new Vector3(0.01f, 0.01f, 1);
        _optionsMenuUI.SetActive(true);
        _twoCoroutinesCoroutine = StartCoroutine(TwoCoroutinesCoroutine(_panel, _optionsMenuUI));
    }

    private void Back()
    {
        var _panel = PanelSearch();
        _panel.SetActive(true);
        _twoCoroutinesCoroutine = StartCoroutine(TwoCoroutinesCoroutine(_optionsMenuUI, _panel));
    }


    private void Update()
    {
        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            if (_pauseMenuUI.activeSelf == false)
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        _gameIsPaused = false;
        ClosePanelAnimation(_pauseMenuUI);
    }

    private void Pause()
    {
        _gameIsPaused = true;
        _pauseMenuUI.transform.localScale = new Vector3(0.01f, 0.01f, 1);
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        OpenPanelAnimation(_pauseMenuUI);
    }

    private void RestartLevel()
    {
        NewGame();
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

    //Два повторящющиеся кода под вайлами в корутинах: думал вынести то, что под вайлами в отдельную рутину...
    //Но юнити вешается. Оставил так...
    private IEnumerator CloseAnimationCoroutine(GameObject _panel)
    {
        while (_panel.transform.localScale.x >= 0.01)
        {
            _panel.transform.localScale = new Vector3(_panel.transform.localScale.x - 0.1f, _panel.transform.localScale.y - 0.1f, 1);
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
            _panel.transform.localScale = new Vector3(_panel.transform.localScale.x + 0.1f, _panel.transform.localScale.y + 0.1f, 1);
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

    private void StopGame()
    {
        UnityEditor.EditorApplication.isPaused = true;
        Debug.Log("Игра остановлена");
    }

    #region "включение и отключение кнопок"
    //мне больно на это смотреть... кажется, можно сделать лучше...
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

    public void AllButtonsTurnOff()
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