using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arcanoid.Components
{
    public class TubeComponent : MonoBehaviour
    {

        [SerializeField] protected Material _islevel1Material;
        [SerializeField] protected Material _islevel2Material;
        [SerializeField] protected Material _islevel3Material;

        private static MeshRenderer _mesh;

        private static Material[] _meshMaterials = new Material[2];

        public static TubeComponent instance;

        private void Start()
        {
            instance = this;
            _mesh = GetComponent<MeshRenderer>();
            _meshMaterials[0] = _mesh.material;
        }

        private void ChangeLevelMaterial(Material material)
        {
            //_meshMaterials[1] = null;
            //_meshMaterials[1] = material;
            //_mesh.materials = _meshMaterials.Where(t => t != null).ToArray();
            gameObject.GetComponent<MeshRenderer>().material = material;
        }

        public void SetLevelTwo() => ChangeLevelMaterial(_islevel2Material);

        public void SetLevelThree() => ChangeLevelMaterial(_islevel3Material);
    }
}