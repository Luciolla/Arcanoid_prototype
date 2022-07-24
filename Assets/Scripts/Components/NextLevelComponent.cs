using UnityEngine;
using Arcanoid.Components.Levels;

namespace Arcanoid.Components
{
    enum LevelEnum
    {
        LevelOne,
        LevelTwo,
        LevelThree
    }

    public class NextLevelComponent : MonoBehaviour
    {
        [Tooltip("Список левелов:")]
        [SerializeField] private GameObject _levelOne;
        [SerializeField] private GameObject _levelTwo;
        [SerializeField] private GameObject _levelThree;

        private void Update()
        {
            TryToAllpyNextLevel();
        }

        private void TryToAllpyNextLevel()
        {
            if (_levelOne.activeSelf == true)
            {
                if (LevelOne.instance.GetHP == 0) ApplyNextLevel(LevelEnum.LevelTwo);
            }
            else if (_levelTwo.activeSelf == true)
            {
                if (LevelTwo.instance.GetHP == 0) ApplyNextLevel(LevelEnum.LevelThree);
            }
        }

        private void ApplyNextLevel(LevelEnum level)
        {
            if (level == LevelEnum.LevelTwo)
            {
                TubeComponent.instance.SetLevelTwo();
                _levelOne.gameObject.SetActive(false);
                _levelTwo.gameObject.SetActive(true);
                Debug.Log("Второй Уровень!");
            }
            else if (level == LevelEnum.LevelThree)
            {
                TubeComponent.instance.SetLevelThree();
                _levelTwo.gameObject.SetActive(false);
                _levelThree.gameObject.SetActive(true);
                Debug.Log("Третий уровень!");
            }
        }
    }
}