using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Components
{
    public class BallComponent : MonoBehaviour
    {
        [Tooltip("Начальная скорость движения шара")]
        [SerializeField][Range(0, 10)] private float _moveSpeed = 0.01f;
        [Tooltip("Максимальная скорость движения шара")]
        [SerializeField][Range(0, 3)] private float _speedMaxLimit = 10f;

        public static BallComponent instance;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private Quaternion _startRotation;
        private float _startSpeed;

        private void Start()
        {
            instance = this;
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _startSpeed = _moveSpeed;
            _startRotation = transform.rotation;
        }

        public void OnMotionStart() => StartCoroutine(StartMotion());

        public void OnMotionEnd() => StopAllCoroutines();

        public void OnDamageEffect() => IncreaseSpeed();

        public void ResetSpeed() => _moveSpeed = _startSpeed;

        public void ResetRotation() => transform.rotation = _startRotation;

        public Collider GetCollider {get => _collider;}

        private IEnumerator StartMotion()
        {
            while (true)
            {
                transform.position += _moveSpeed * Time.deltaTime * transform.forward;
                yield return null;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint _point = collision.GetContact(0);

            Vector3 startVector = transform.forward;
            Vector3 endVector = Vector3.Reflect(startVector, _point.normal);

            transform.forward = endVector;
        }

        private void IncreaseSpeed()
        {
            if (_moveSpeed < _speedMaxLimit)
            {
                _moveSpeed = _moveSpeed + 0.02f;
            }
        }
    }
}