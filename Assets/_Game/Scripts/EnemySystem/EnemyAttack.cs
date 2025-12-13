// EKLENECEÐÝ YER:
// Enemy PREFAB root GameObject

using UnityEngine;
using Game.Combat;

namespace Game.Enemy
{
    // Enemy'nin SADECE saldýrý logic'i
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float attackInterval = 1f;
        [SerializeField] private float attackRange = 1.5f;

        private float lastAttackTime;
        private BaseHealth targetHealth;
        private Transform targetTransform;

        // EnemyController tarafýndan çaðrýlýr
        public void Initialize(BaseTarget baseTarget)
        {
            targetTransform = baseTarget.transform;
            targetHealth = baseTarget.GetComponent<BaseHealth>();
        }

        //Geçici - State Machine kullanýlana kadar
        private void Update()
        {
            if (targetHealth == null) return;

            float distance = Vector3.Distance(
                transform.position,
                targetTransform.position
            );

            if (distance > attackRange) return;

            if (Time.time - lastAttackTime < attackInterval) return;

            lastAttackTime = Time.time;
            targetHealth.TakeDamage(damage);
        }
    }
}
