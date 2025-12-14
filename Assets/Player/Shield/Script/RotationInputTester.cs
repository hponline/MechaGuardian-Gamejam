using UnityEngine;
using Game.Events;

namespace Game.Debug
{
    public sealed class RotationInputTester : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RotationEvents.OnRotationToggle?.Invoke(true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                RotationEvents.OnRotationToggle?.Invoke(false);
            }
        }
    }
}
