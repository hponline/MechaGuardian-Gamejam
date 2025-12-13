// EKLENECEÐÝ YER:
// Base GameObject (BaseTarget ile AYNI objede olabilir)

using UnityEngine;

namespace Game.Combat
{
    public sealed class BaseHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 1000;

        private int currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        // Enemy tarafýndan çaðrýlýr
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0);

            Debug.Log($"Base Damage aldý! Kalan HP: {currentHealth}");

            if (currentHealth <= 0)
            {
                OnBaseDestroyed();
            }
        }

        private void OnBaseDestroyed()
        {
            Debug.Log("BASE YIKILDI!");
            // Game Over logic’i ileride buraya
        }
    }
}
