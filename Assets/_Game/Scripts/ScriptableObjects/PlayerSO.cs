using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSO/Weapons/Fire")]
public class PlayerSO : ScriptableObject
{
    public Transform bulletPrefab;
    public float fireRate = 0.3f;
    public float attackDamage = 10f;
    public float attackRange = 10f;

}
