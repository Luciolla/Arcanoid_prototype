﻿namespace Arcanoid.Components.Levels
{
    public class LevelOne : LevelComponent
    {
        public bool activeSelf;
        public static LevelOne instance;

            protected override void Start()
        {
            base.Start();
            instance=this;
        }
    }
}