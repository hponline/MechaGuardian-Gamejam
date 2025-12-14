// EKLENECEÐÝ YER:
// Enemy PREFAB root GameObject
// Animator component ile birlikte

using UnityEngine;

namespace Game.Enemy
{
    // Enemy animator kontrolü (VIEW katmaný)
    public sealed class EnemyAnimator : MonoBehaviour
    {
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int DieHash = Animator.StringToHash("Die");

        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void SetMoveSpeed(float speed)
        {
            animator.SetFloat(SpeedHash, speed);
        }

        public void PlayAttack()
        {
            animator.SetTrigger(AttackHash);
        }

        public void PlayDeath()
        {
            animator.SetTrigger(DieHash);
        }
    }
}
