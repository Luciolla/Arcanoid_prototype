using System.Linq;

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
            _levelHP = _levelBlocks.Count();
        }
    }
}