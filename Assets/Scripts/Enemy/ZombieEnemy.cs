using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float attackDamage = 12f;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1f;

    private Transform target;
    private float currentHealth;
    private float nextAttackTime;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Initialize(Transform playerTarget, float speedMultiplier = 1f)
    {
        target = playerTarget;
        moveSpeed *= speedMultiplier;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (target == null || currentHealth <= 0f)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance > attackRange)
        {
            direction.y = 0f;
            if (direction.sqrMagnitude > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), 10f * Time.deltaTime);
            }
        }
        else if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown;
            var player = target.GetComponent<MobilePlayerController>();
            if (player != null)
            {
                player.TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0f)
        {
            return;
        }

        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (ZombieGameManager.Instance != null)
        {
            ZombieGameManager.Instance.OnZombieKilled(this);
        }

        Destroy(gameObject);
    }

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
}
