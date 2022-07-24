using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arcanoid.Components.Levels
{
    public class LevelTwo : LevelComponent
    {
        public bool activeSelf;
        public static LevelTwo instance;
        private void Avake() //видимо лишнее
        {
            _levelHP = _levelBlocks.Count();
        }
        protected override void Start()
        {
            base.Start();
            instance = this;
        }
    }
}