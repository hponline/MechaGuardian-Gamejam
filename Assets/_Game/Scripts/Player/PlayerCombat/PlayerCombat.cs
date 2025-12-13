using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat instance;

    [Header("References")]
    public Transform firePoint;

    [Header("Shooter Attack")]
    public Transform shooterBulletPrefab;
    public float ShooterFireRate = 0.3f;
    public float ShooterAttackDamage = 10f;
    public float shooterAttackTimer = 0;
    public bool shooterIsAttacking = false;

    [Header("Laser Attack")]
    public Transform laserBulletPrefab;
    public float laserFireRate = 0.3f;
    public float laserAttackDamage = 10f;
    public float laserAttackRange = 10f;
    public float laserAttackTimer = 0;
    public bool laserIsAttacking = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // karakter ateþ ettme mekanigi
        shooterAttackTimer += Time.deltaTime;
        if (shooterAttackTimer >= ShooterFireRate)
            shooterIsAttacking = false;
        else
            shooterIsAttacking = true;

        if (laserAttackTimer >= laserFireRate)
            laserIsAttacking = false;
        else
            laserIsAttacking = true;

    }

    public void PlayerAttack()
    {
        if (shooterAttackTimer >= ShooterFireRate)
        {
            Instantiate(shooterBulletPrefab, firePoint.position, transform.rotation);
            shooterIsAttacking = true;
            shooterAttackTimer = 0;
            Debug.Log("Shooter Ateþ etti");
            // vfx/sound
        }
    }

    public void PlayerLaserAttack()
    {
        if (laserAttackTimer >= ShooterFireRate)
        {
            Instantiate(shooterBulletPrefab, firePoint.position, transform.rotation);
            laserIsAttacking = true;
            laserAttackTimer = 0;
            Debug.Log("Laser Ateþ etti");
            // vfx/sound
        }
    }

}
