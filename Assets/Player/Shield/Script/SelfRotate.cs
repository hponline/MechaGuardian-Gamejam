using UnityEngine;
using Game.Events;

namespace Game.Utility
{
    public sealed class SelfRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis = Vector3.up;
        [SerializeField] private float rotationSpeed = 90f;

        private bool isRotating;

        private void OnEnable()
        {
            RotationEvents.OnRotationToggle += HandleRotationToggle;
        }

        private void OnDisable()
        {
            RotationEvents.OnRotationToggle -= HandleRotationToggle;
        }

        private void Update()
        {
            if (!isRotating)
                return;

            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, Space.Self);
        }

        private void HandleRotationToggle(bool shouldRotate)
        {
            isRotating = shouldRotate;
        }
    }
}
