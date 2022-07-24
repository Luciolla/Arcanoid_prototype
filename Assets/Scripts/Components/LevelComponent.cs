using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arcanoid.Components
{
    public abstract class LevelComponent : MonoBehaviour
    {
        protected int _levelHP;
        [Tooltip("Список блоков на левеле")]
        [SerializeField] protected List<GameObject> _levelBlocks;

        protected virtual void Start()
        {
            _levelHP = _levelBlocks.Count();
        }

        public int GetHP { get => _levelHP; set { _levelHP = value; } }
    }
}