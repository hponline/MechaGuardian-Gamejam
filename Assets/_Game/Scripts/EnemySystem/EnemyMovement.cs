// EKLENECEÐÝ YER:
// Enemy PREFAB’ýnýn root GameObject’i
// NavMeshAgent ile birlikte kullanýlýr

using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemy
{
    // Enemy’nin SADECE hareketinden sorumludur
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent agent;

        private void Awake()
        {
            // NavMeshAgent referansý cache edilir
            agent = GetComponent<NavMeshAgent>();
        }

        // Enemy’yi verilen hedefe doðru yürütür
        public void MoveTo(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
    }
}
