using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat instance;

    [Header("References")]
    public Transform firePoint;

    [Header("Shooter Attack")]
    public Transform shooterBulletPrefab;
    public float ShooterFireRate = 0.3f;
    public int ShooterAttackDamage = 10;
    public float shooterAttackTimer = 0;
    public bool shooterIsAttacking = false;

    [Header("Laser Attack")]
    //public Transform laserBulletPrefab;
    public LaserDamage laserDamage;
    public ParticleSystem laserParticlePrefab;
    public float laserFireRate = 3f;
    public float laserAttackDamage = 10f;
    public float laserAttackRange = 10f;
    [SerializeField] float laserAttackTimer = 0;
    [SerializeField] float laserActiveTimer = 0f;
    public float laserActiveDuration = 3f; // Laserin açýk kaldýgý süre
    public bool laserIsAttacking = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // karakter ateþ ettme mekanigi

        UpdateAttackState();
    }


    void UpdateAttackState()
    {
        shooterAttackTimer += Time.deltaTime;
        laserAttackTimer += Time.deltaTime;

        if (shooterIsAttacking && shooterAttackTimer >= ShooterFireRate)
            shooterIsAttacking = false;

        if (laserIsAttacking)
        {
            laserActiveTimer += Time.deltaTime;
            if (laserActiveTimer >= laserActiveDuration)
            {
                StopLaser();
            }
        }
    }

    public void PlayerAttack()
    {
        if (shooterIsAttacking) return;
        if (shooterAttackTimer < ShooterFireRate) return;

        Instantiate(shooterBulletPrefab, firePoint.position, transform.rotation);
        shooterIsAttacking = true;
        shooterAttackTimer = 0;
        Debug.Log("Shooter Ateþ etti");
        // vfx/sound
    }
    void StopLaser()
    {
        if (laserParticlePrefab.isPlaying)
            laserParticlePrefab.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        laserIsAttacking = false;
        laserActiveTimer = 0;
        laserDamage.StopLaser();
    }

    public void PlayerLaserAttack()
    {
        if (laserIsAttacking) return;
        if (laserAttackTimer < laserFireRate) return;
        if (!laserParticlePrefab.isPlaying)
            laserParticlePrefab.Play();

        laserIsAttacking = true;
        laserAttackTimer = 0;
        laserActiveTimer = 0;

        laserDamage.StartLaser();
        Debug.Log("Laser Ateþ etti");
        // vfx/sound

    }

}
