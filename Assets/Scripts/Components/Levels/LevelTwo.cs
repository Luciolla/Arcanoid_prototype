using System.Linq;

namespace Arcanoid.Components.Levels
{
    public class LevelTwo : LevelComponent
    {
        public bool activeSelf;
        public static LevelTwo instance;

        protected override void Start()
        {
            base.Start();
            instance = this;
            _levelHP = _levelBlocks.Count();
        }
    }
}