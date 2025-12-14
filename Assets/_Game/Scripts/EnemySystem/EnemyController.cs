// EKLENECEÐÝ YER:
// Enemy PREFAB’ýnýn root GameObject’i

using UnityEngine;
using Game.Combat;
using UnityEngine.AI;

namespace Game.Enemy
{
    // Enemy’nin spawn sonrasý baþlatýlmasýndan sorumludur
    // Spawner bu class ile konuþur
    public sealed class EnemyController : MonoBehaviour
    {
        private EnemyMovement movement;
        private EnemyAttack attack;

        private void Awake()
        {
            // Enemy içindeki movement component’i alýnýr
            movement = GetComponent<EnemyMovement>();
            // Enemy içindeki attack component’i alýnýr
            attack = GetComponent<EnemyAttack>();
        }

        // Enemy spawn edildikten hemen sonra çaðrýlýr
        public void Initialize(BaseTarget baseTarget)
        {
            // Enemy base noktasýna doðru hareket etmeye baþlar
            movement.MoveTo(baseTarget.Position);

            //Saldýrý sistemi hedefi tanýsýn
            attack.Initialize(baseTarget);
        }
    }
}
