// EKLENECEÐÝ YER:
// SpawnPoint’leri parent olarak tutan EMPTY GameObject (SpawnPointGroup)

using System.Collections.Generic;
using UnityEngine;

namespace Game.Spawning
{
    // Birden fazla SpawnPoint’i yönetir
    // SpawnPoint’leri runtime’da aramaz, Inspector’dan alýr
    public sealed class SpawnPointGroup : MonoBehaviour
    {
        // Inspector’dan manuel baðlanýr
        [SerializeField]
        private List<SpawnPoint> spawnPoints = new();

        // Rastgele bir spawn noktasý döner
        public SpawnPoint GetRandom()
        {
            if (spawnPoints.Count == 0)
            {
                Debug.LogError("SpawnPointGroup boþ!");
                return null;
            }

            int index = Random.Range(0, spawnPoints.Count);
            return spawnPoints[index];
        }
    }
}
