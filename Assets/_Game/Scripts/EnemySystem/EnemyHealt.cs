using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] EnemyHealthBar healthBar;
    public GameObject canvasHealth;
    public int health = 100;
    [SerializeField] float currentHealth;

    private void Awake()
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealhtBar(health, currentHealth);
        Debug.Log(currentHealth);
        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
