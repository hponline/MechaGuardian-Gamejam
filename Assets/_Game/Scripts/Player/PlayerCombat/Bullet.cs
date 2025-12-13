using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float destroyTime = 5f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }
    private void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
