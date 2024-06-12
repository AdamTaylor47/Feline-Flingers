using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform launchPoint; // The point where the projectile is launched from
    public GameObject projectilePrefab; // The projectile prefab
    private GameObject projectileInstance;
    private Rigidbody2D projectileRb;
    private bool isDragging = false;

    void Start()
    {
        SpawnProjectile();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (IsTouchingProjectile(touchPosition))
                    {
                        isDragging = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        projectileInstance.transform.position = touchPosition;
                    }
                    break;
                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        isDragging = false;
                        LaunchProjectile();
                    }
                    break;
            }
        }
    }

    void SpawnProjectile()
    {
        projectileInstance = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        projectileRb = projectileInstance.GetComponent<Rigidbody2D>();
        projectileRb.isKinematic = true; // Prevent the projectile from moving until released
    }

    bool IsTouchingProjectile(Vector3 touchPosition)
    {
        return Vector2.Distance(touchPosition, projectileInstance.transform.position) <= 0.5f; // Adjust the distance as needed
    }

    void LaunchProjectile()
    {
        projectileRb.isKinematic = false; // Allow the projectile to be affected by physics
        Vector3 launchDirection = launchPoint.position - projectileInstance.transform.position;
        projectileRb.AddForce(launchDirection * 300); // Adjust the force multiplier as needed
        Invoke("SpawnProjectile", 3f); // Respawn the projectile after a delay

    }
}
