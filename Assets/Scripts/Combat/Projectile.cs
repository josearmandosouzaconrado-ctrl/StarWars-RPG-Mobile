using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 18f;
    [SerializeField] private float lifeTime = 1.5f;
    [SerializeField] private float damage = 25f;

    private Vector3 direction;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Initialize(Vector3 shootDirection, float projectileDamage)
    {
        direction = shootDirection.normalized;
        damage = projectileDamage;
        transform.forward = direction;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var zombie = other.GetComponent<ZombieEnemy>();
        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
