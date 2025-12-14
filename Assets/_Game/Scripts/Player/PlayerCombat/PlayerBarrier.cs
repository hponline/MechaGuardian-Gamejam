using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    private enum ShieldState
    {
        Ready,      
        Active,     
        Cooldown    
    }

    [Header("Settings")]
    [SerializeField] private float shieldDuration = 5f;
    [SerializeField] private float shieldCooldown = 15f;
    [SerializeField] private GameObject shieldVFX;

    [Header("Shield HP")]
    public int maxShield = 100;
    public int currentShield = 0;

    private ShieldState state = ShieldState.Ready;
    [SerializeField]private float timer;

    private void Start()
    {
        currentShield = maxShield;
    }

    private void Update()
    {
        if (state == ShieldState.Ready)
            return;

        timer += Time.deltaTime;

        switch (state)
        {
            case ShieldState.Active:
                if (timer >= shieldDuration)
                {
                    DeactivateShield();
                    state = ShieldState.Cooldown;
                    timer = 0f;
                }
                break;

            case ShieldState.Cooldown:
                if (timer >= shieldCooldown)
                {
                    state = ShieldState.Ready;
                    timer = 0f;
                }
                break;
        }
    }

    public int AbsorbDamage(int damage)
    {
        if (state != ShieldState.Active)
            return damage;

        currentShield -= damage;

        if (currentShield <= 0)
        {
            int remainingDamage = -currentShield;

            currentShield = 0;
            DeactivateShield();

            state = ShieldState.Cooldown;
            timer = 0f;

            return remainingDamage;
        }

        return 0;
    }


    public void UseShield()
    {
        if (state != ShieldState.Ready)
            return;

        ActivateShield();
        state = ShieldState.Active;
        timer = 0f;
    }

    private void ActivateShield()
    {
        currentShield = maxShield;
        shieldVFX.SetActive(true);
    }

    private void DeactivateShield()
    {
        shieldVFX.SetActive(false);
    }

    // Debug / UI için
    public bool IsReady() => state == ShieldState.Ready;
    public bool IsActive() => state == ShieldState.Active;
}
