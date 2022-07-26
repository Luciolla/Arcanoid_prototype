using Arcanoid.Components.Levels;
using UnityEngine;

namespace Arcanoid.Components
{
    public class DamagebleObjects : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
            BallComponent.Instance.OnDamageEffect();
            LevelOne.Instance.GetHP -= 1;
        }
    }
}