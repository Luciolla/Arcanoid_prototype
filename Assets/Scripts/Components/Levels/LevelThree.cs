using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Components.Levels
{
    public class LevelThree : LevelComponent
    {
        public bool activeSelf;
        public static LevelThree instance;
        protected override void Start()
        {
            base.Start();
            instance = this;
        }
    }
}