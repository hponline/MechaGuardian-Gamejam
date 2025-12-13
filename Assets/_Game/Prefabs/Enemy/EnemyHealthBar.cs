using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    Camera _cam;
    Image _healthBar;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }

    public void UpdateHealhtBar(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / maxHealth;
        Debug.Log("Update içinde çalýþtýr");
    }
}
