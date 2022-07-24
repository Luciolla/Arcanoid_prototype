using Arcanoid.Components.Levels;
using UnityEngine;

namespace Arcanoid.Components
{
    public class DamagebleObjects : MonoBehaviour
    {
        private Collider _collider;
        private Quaternion _rotation;

        private void Start()
        {
            _rotation = transform.rotation;
            _collider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
            BallComponent.instance.OnDamageEffect();
            LevelOne.instance.GetHP -= 1;
            //todo score
            //todo сделать основной компонент из которого будут наследовать логику force
        }
    }
}