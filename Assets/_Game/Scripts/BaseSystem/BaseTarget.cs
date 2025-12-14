// EKLENECEÐÝ YER:
// Enemy’lerin ulaþmaya çalýþacaðý Base GameObject’i

using UnityEngine;

namespace Game.Combat
{
    // Enemy’ler için hedef noktayý temsil eder
    // Hareket veya saldýrý logic’i içermez
    public sealed class BaseTarget : MonoBehaviour
    {
        public Vector3 Position => transform.position;
    }
}
