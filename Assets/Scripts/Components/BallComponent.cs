using System.Collections;
using UnityEngine;

namespace Arcanoid.Components
{
    public class BallComponent : MonoBehaviour
    {
        [Tooltip("Начальная скорость движения шара"), SerializeField, Range(1, 10)]
        private float _moveSpeed = 1f;
        [Tooltip("Максимальная скорость движения шара"), SerializeField, Range(0, 10)]
        private float _speedMaxLimit = 10f;
        [Tooltip("Коэффициент прирощения скорости"), SerializeField, Range(0, 3)]
        private float _speedAccelerator = 0.25f;
        [Tooltip("Точка спавна (для поворота)"), SerializeField]
        private GameObject _spawnPoint;

        public static BallComponent instance;

        private Rigidbody _rigidbody; //кажется лишнее
        private Collider _collider;
        private float _startSpeed;

        public Collider GetCollider { get => _collider; }

        private void Start()
        {
            instance = this;
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _startSpeed = _moveSpeed;
        }

        public void OnMotionStart() => StartCoroutine(StartMotion());

        public void OnMotionEnd() => StopAllCoroutines();

        public void OnDamageEffect() => IncreaseSpeed();

        public void ResetSpeed() => _moveSpeed = _startSpeed;

        public void ResetRotation() => transform.rotation = _spawnPoint.transform.rotation * new Quaternion(-1f, 0f, 0f, 0);

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
                _moveSpeed = _moveSpeed + _speedAccelerator;
            }
        }
    }
}