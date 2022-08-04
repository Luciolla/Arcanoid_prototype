using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arcanoid.Components
{
    public class OptionsComponent : MonoBehaviour
{
        [SerializeField] Toggle _muteToggle;
        [SerializeField] Slider _volumeSlider;
        [SerializeField] Toggle _casualToggle;
        [SerializeField] Toggle _insaneToggle;

        void Awake()
        {
            LoadOptions();
            //DebugMethod();
        }

        private void Mute()
        {
            PlayerPrefs.SetInt("IsMute", 1);
            _muteToggle.isOn = true;
            _volumeSlider.value = 0;
        }

        private void Unmute()
        {
            PlayerPrefs.SetInt("IsMute", 0);
            _muteToggle.isOn = false;
        }

        public void MuteToggle()
        {
            if (_muteToggle.isOn)
            {
                Mute();
            }
            else
            {
                Unmute();
            }
        }

        public void VolumeSlider()
        {
            PlayerPrefs.SetFloat("Volume", _volumeSlider.value);
            if (_volumeSlider.value == 0)
            {
                Mute();
            }
            else
            {
                Unmute();
            }
        }

        public void SetDifficultyCasual()
        {
            if (_casualToggle.isOn)
            {
                PlayerPrefs.SetString("Difficulty", "Casual");
            }
        }
        public void SetDifficultyInsane()
        {
            if (_insaneToggle.isOn)
            {
                PlayerPrefs.SetString("Difficulty", "Insane");
            }
        }

        private void LoadOptions()
        {
            if (PlayerPrefs.GetInt("IsMute") == 0)
            {
                _muteToggle.isOn = true;
            }
            else
            {
                _muteToggle.isOn = false;
            }
            _volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            switch (PlayerPrefs.GetString("Difficulty"))
            {
                case "Casual":
                    _casualToggle.isOn = true;
                    _insaneToggle.isOn = false;
                    break;
                case "Insane":
                    _casualToggle.isOn = false;
                    _insaneToggle.isOn = true;

                    break;
                default:
                    _casualToggle.isOn = true;
                    _insaneToggle.isOn = false;
                    break;
            }
        }
    }
}