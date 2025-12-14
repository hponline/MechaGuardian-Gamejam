using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] bool isActive;
    [SerializeField] float maxDistance = 10;
    public void StartLaser() => isActive = true;
    public void StopLaser() => isActive = false;

    private void Update()
    {
        if (!isActive) return;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, PlayerCombat.instance.laserAttackRange, enemyLayer))
        {
            hit.collider.GetComponent<EnemyHealt>()?.TakeDamage(PlayerCombat.instance.laserAttackDamage * Time.deltaTime);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    }
}
