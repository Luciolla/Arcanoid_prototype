using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Arcanoid.Components.Levels
{
    public class LevelThree : LevelComponent
    {
        public bool activeSelf;
        public static LevelThree Instance;
        private void Avake() //кажется лишнее
        {
            _levelHP = _levelBlocks.Count();
        }
        protected override void Start()
        {
            base.Start();
            Instance = this;
        }
    }
}