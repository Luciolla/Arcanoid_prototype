using System;
using System.IO;
using UnityEngine;

namespace Arcanoid.Components
{
    public class GameLog : MonoBehaviour
    {
        public static GameLog instance; //скоро я от него избавлюсь... но не сегодня :')

        private StreamWriter _logStream;
        private FileInfo _logFile;

        private int _hour;
        private int _minute;
        private int _second;

        private void Start()
        {
            instance = this;
        }

        public void WriteLogChecker(GameLogEnum logEnum)     
        {
            switch (logEnum)
            {
                case GameLogEnum.MainMenu:
                    WriteLog("Open settings");
                    break;
                case GameLogEnum.Start:
                    WriteLog("Start Game");
                    break;
                case GameLogEnum.Restart:
                    WriteLog("Restart Game");
                    break;
                case GameLogEnum.Pause:
                    WriteLog("Pause Game");
                    break;
                case GameLogEnum.Resume:
                    WriteLog("Resume Game");
                    break;
                case GameLogEnum.Exit:
                    WriteLog("Exit Game");
                    break;
                default:
                    WriteLog("Пользователь запустил какую то неведомую хрень...");
                    break;
            }
        }

        private void CheckTime()
        {
            _hour = DateTime.Now.Hour;
            _minute = DateTime.Now.Minute;
            _second = DateTime.Now.Second;
        }

        private void WriteLog(string text)
        {
            CheckTime();
            _logFile = new FileInfo("GameLog.txt");

            _logStream = _logFile.AppendText();
            _logStream.WriteLine("{0}:{1}:{2} : {3}", _hour, _minute, _second, text);
            _logStream.Close();
        }
    }
}