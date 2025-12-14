// EKLENECEÐÝ YER:
// SpawnSystem altýnda bulunan EMPTY GameObject (Spawner)

using UnityEngine;
using Game.Enemy;
using Game.Combat;

namespace Game.Spawning
{
    // Spawn kararýný veren sistem
    // Enemy AI veya hareket logic’i içermez
    public sealed class Spawner : MonoBehaviour
    {
        // Spawn noktalarýný yöneten grup
        [SerializeField] private SpawnPointGroup spawnPointGroup;

        // Spawn edilecek enemy prefab’ý
        [SerializeField] private GameObject enemyPrefab;

        // Enemy’lerin gideceði Base
        [SerializeField] private BaseTarget baseTarget;

        private void Awake()
        {
            baseTarget = GameObject.FindGameObjectWithTag("BASE").GetComponent<BaseTarget>();
        }

        private void Start()
        {
            SpawnTest();

        }

        // Enemy spawn iþlemi
        public void Spawn()
        {
            // Rastgele spawn noktasý seç
            SpawnPoint spawnPoint = spawnPointGroup.GetRandom();
            if (spawnPoint == null) return;

            // Enemy instantiate edilir
            GameObject enemyInstance = Instantiate(
                enemyPrefab,
                spawnPoint.Position,
                spawnPoint.Rotation
            );

            // Enemy controller alýnýr
            EnemyController enemyController =
                enemyInstance.GetComponent<EnemyController>();

            // Enemy base’e yönlendirilir
            enemyController.Initialize(baseTarget);
        }

#if UNITY_EDITOR
        // Editor’dan test amaçlý spawn
        [ContextMenu("Spawn Test")]
        private void SpawnTest()
        {
            Spawn();
        }
#endif
    }
}
