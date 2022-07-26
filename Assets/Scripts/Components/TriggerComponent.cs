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
            if (collider == BallComponent.Instance.GetCollider)
            {
                PlayerHealth.Instance.PlayerHP -= 1;
                BallComponent.Instance.OnMotionEnd();
                BallComponent.Instance.ResetSpeed();
                BallComponent.Instance.ResetRotation();
                collider.transform.position = PlayerMotion.Instance.GetGameObject.transform.position;
                PlayerMotion.Instance.IsPlaying = false;
            }
        }
    }
}