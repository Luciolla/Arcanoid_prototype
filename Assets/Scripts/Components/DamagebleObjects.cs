using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DamagebleObjects : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] private float _force;
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
            collision.rigidbody.AddForce(transform.forward * _force, ForceMode.Acceleration);
            //todo score
            //todo сделать основной компонент из которого будут наследовать логику force
        }
    }
}