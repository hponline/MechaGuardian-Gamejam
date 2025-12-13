using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat instance;

    [Header("References")]
    public PlayerSO playerSO;
    public Transform firePoint;

    [Header("Variables")]
    public float attackTimer = 0;
    public bool isAttack = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // karakter ateþ ettme mekanigi
        attackTimer += Time.deltaTime;
    }

    public void PlayerAttack()
    {
        if (!isAttack) return;

        Instantiate(playerSO.bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
