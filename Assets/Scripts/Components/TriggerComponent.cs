using Arcanoid.Player;
using UnityEngine;

namespace Arcanoid.Components
{
    public class TriggerComponent : MonoBehaviour
    {
        private BoxCollider _collider;
        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider == BallComponent.instance.GetCollider)
            {
                BallComponent.instance.OnMotionEnd();
                BallComponent.instance.ResetSpeed();
                BallComponent.instance.ResetRotation();
                collider.transform.position = PlayerMotion.instance.GetGameObject.transform.position;
            }
        }
    }
}