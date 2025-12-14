// EKLENECEÐÝ YER:
// Sahnedeki spawn noktasý olarak kullanýlacak EMPTY GameObject’ler
// (SpawnPoint_A, SpawnPoint_B, vs.)

using UnityEngine;

namespace Game.Spawning
{
    // Spawn noktasý marker’ý
    // SADECE pozisyon ve rotasyon saðlar
    public sealed class SpawnPoint : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

#if UNITY_EDITOR
        // Scene view’da spawn noktasýný görselleþtirmek için
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
            Gizmos.DrawRay(transform.position, transform.forward);
        }
#endif
    }
}
