using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
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
        Debug.Log(currentHealth);
        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
