using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float fireRate = 1f;

    private float lastFireTime;

    void Update()
    {
        if (Time.time - lastFireTime > fireRate)
        {
            FireBullet();
            lastFireTime = Time.time;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Dispara hacia la izquierda
        Vector2 direction = Vector2.left;

        rb.velocity = direction * bulletSpeed;
    }
}