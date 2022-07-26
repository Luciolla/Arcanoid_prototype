using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Components.Levels
{
    public class LevelOne : LevelComponent
    {
        public bool activeSelf;
        public static LevelOne Instance;
            protected override void Start()
        {
            base.Start();
            Instance=this;
        }
    }
}