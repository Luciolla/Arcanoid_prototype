using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Components
{
    public class TubeComponent : MonoBehaviour
    {

        [Tooltip("Список материалов для левелов")]
        [SerializeField] private Material _islevel1Material; //просто, чтобы было
        [SerializeField] private Material _islevel2Material;
        [SerializeField] private Material _islevel3Material;
        [SerializeField] private List <GameObject> _sides;

        public static TubeComponent Instance;

        private void Start()
        {
            Instance = this;
        }

        private void ChangeLevelMaterial(Material material)
        {
            foreach (var item in _sides)
            {
                item.gameObject.GetComponent<MeshRenderer>().material = material;
            }
        }

        public void SetLevelTwo() => ChangeLevelMaterial(_islevel2Material);
        public void SetLevelThree() => ChangeLevelMaterial(_islevel3Material);
    }
}