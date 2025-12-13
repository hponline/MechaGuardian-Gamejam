using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30f;
    public float destroyTime = 2f;


    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealt enemy = other.GetComponent<EnemyHealt>();
            enemy.TakeDamage(PlayerCombat.instance.ShooterAttackDamage);
        }
    }
}
