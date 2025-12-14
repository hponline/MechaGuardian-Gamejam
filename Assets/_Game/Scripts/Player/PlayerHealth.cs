using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerBarrier playerShield;

    [Header("Player")]
    public int maxHealt = 100;
    [SerializeField] int currentHealth;

    private void Start()
    {
        playerShield = GetComponent<PlayerBarrier>();

        currentHealth = maxHealt;
    }

    public void TakeDamage(int damage)
    {
        if (playerShield != null && playerShield.IsActive())
        {
            damage = playerShield.AbsorbDamage(damage);
        }

        if (damage <= 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealt);

        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player öldü \nRestart ekraný yap");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}
