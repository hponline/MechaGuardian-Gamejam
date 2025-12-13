using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [Header("Barrier stats ")]
    public GameObject shiledVFX;
    //public int maxShiled = 100;
    public float shieldDuration = 5f;
    public float shieldCooldown = 15f;

    [SerializeField] float shieldCooldownTimer = 0f;
    [SerializeField] float shieldActiveTimer = 0f;

    public bool isShieldActive = false;
    public bool isShieldCooldwon = false;

    [SerializeField] int currentShiled;

    private void Start()
    {
        currentShiled = PlayerCombat.instance.maxShiled;
        DeActiveShiled();
    }

    private void Update()
    {
        shieldActiveTimer += Time.deltaTime;

        if (isShieldActive)
        {
            shieldActiveTimer += Time.deltaTime;
            if (shieldActiveTimer >= shieldDuration)
            {
                DeActiveShiled();
            }
        }
        if (isShieldCooldwon)
        {
            shieldCooldownTimer += Time.deltaTime;
            if (shieldCooldownTimer >= shieldCooldown)
            {
                isShieldActive = false;
                shieldCooldownTimer = 0f;
                // kalkan bitince yeniden aktifleþmiyor (F)
            }
        }
    }

    public void ActiveShield()
    {
        currentShiled = PlayerCombat.instance.maxShiled;
        isShieldActive = true;
        shiledVFX.SetActive(true);
    }

    public void DeActiveShiled()
    {
        isShieldActive = false;
        currentShiled = 0;

        shiledVFX.SetActive(false);
    }

    public int AbsorbDamage(int incomingDamage)
    {
        if (!isShieldActive) return incomingDamage;

        currentShiled -= incomingDamage;
        Debug.Log(currentShiled);
        if (currentShiled <= 0)
        {
            int remainingDamage = -currentShiled;
            DeActiveShiled();
            return remainingDamage;
        }
        return 0;
    }
}
