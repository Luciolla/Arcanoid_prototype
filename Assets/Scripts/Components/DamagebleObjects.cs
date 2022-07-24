using Arcanoid.Components.Levels;
using UnityEngine;

namespace Arcanoid.Components
{
    public class DamagebleObjects : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
            BallComponent.instance.OnDamageEffect();
            LevelOne.instance.GetHP -= 1;
        }
    }
}