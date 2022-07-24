using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Components.Levels
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
        //protected void RandomRotation() => _objects.Where(obj => obj.transform.rotation == Random.rotation);
        //не работает... хотел сделать доп.задание на вращение... но пока затык из-за непродуманной архитектуры.
    }
}