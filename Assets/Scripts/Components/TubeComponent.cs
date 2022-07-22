using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class TubeComponent : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] private float _force = 1f;
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            collision.rigidbody.AddForce(transform.forward * _force, ForceMode.Acceleration);
            //todo сделать основной компонент из которого будут наследовать логику force
        }
    }
}