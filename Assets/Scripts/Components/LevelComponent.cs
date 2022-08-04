using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arcanoid.Components
{
    public abstract class LevelComponent : MonoBehaviour
    {
        protected static int _levelHP;
        [Tooltip("Список блоков на левеле"), SerializeField]
        protected List<GameObject> _levelBlocks;

        protected virtual void Start()
        {
            _levelHP = _levelBlocks.Count();
            //Debug.Log(_levelHP); //проверял загруженное количество блоков на лв
            StartRotate();
        }

        public int GetHP { get => _levelHP; set { _levelHP = value; } }

        protected void StartRotate()
        {
            foreach (var item in _levelBlocks)
            {
                item.gameObject.transform.rotation = Random.rotation;
            }
        }
    }
}