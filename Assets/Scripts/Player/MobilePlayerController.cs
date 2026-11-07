using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MobilePlayerController : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 12f;

    [Header("Ataque")]
    [SerializeField] private float fireRate = 0.18f;
    [SerializeField] private float projectileDamage = 25f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;

    [Header("Vida")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;

    private CharacterController characterController;
    private float nextShotTime;
    private Vector2 movementInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (ZombieGameManager.Instance != null)
        {
            ZombieGameManager.Instance.RegisterPlayer(transform);
        }
    }

    private void Update()
    {
        UpdateMovement();
        TryHandleShootInput();
    }

    private void UpdateMovement()
    {
        Vector2 input = GetInput();
        movementInput = input;

        Vector3 move = transform.right * input.x + transform.forward * input.y;
        if (move.sqrMagnitude > 0.01f)
        {
            characterController.Move(move.normalized * moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private Vector2 GetInput()
    {
        if (Application.isMobilePlatform)
        {
            Vector2 mobileInput = Vector2.zero;

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.position.x < Screen.width * 0.45f)
                {
                    mobileInput.x = (touch.position.x / (Screen.width * 0.45f)) - 1f;
                    mobileInput.y = (touch.position.y / Screen.height) * 2f - 1f;
                }
                else if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
                {
                    TryShoot();
                }
            }

            if (mobileInput.sqrMagnitude > 0.01f)
            {
                return mobileInput.normalized;
            }

            return Vector2.zero;
        }

        Vector2 keyboardInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }

        return keyboardInput.normalized;
    }

    private void TryHandleShootInput()
    {
        if (!Application.isMobilePlatform && Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }
    }

    public void TryShoot()
    {
        if (Time.time < nextShotTime)
        {
            return;
        }

        if (projectilePrefab == null)
        {
            Debug.LogWarning("Prefab do projétil não foi atribuído no MobilePlayerController.");
            return;
        }

        Vector3 shotDirection = transform.forward;
        if (firePoint == null)
        {
            firePoint = transform;
        }

        GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(shotDirection));
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Initialize(shotDirection, projectileDamage);
        }

        nextShotTime = Time.time + fireRate;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0f;
            if (ZombieGameManager.Instance != null)
            {
                ZombieGameManager.Instance.OnPlayerDefeated();
            }
        }
    }

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
}
