using UnityEngine;
using DarkShadowHunter;
public class ShootingMechanic : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GunAmmoToFire ammoToFire;
    private void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            FireWeapon();
        }
    }
    
    private void FireWeapon()
    {
        foreach (var g in ammoToFire.ammoManager)
        {
            if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.SingleTarget)
            {
                Instantiate(bulletPrefab, transform.GetChild(1).transform.position, Quaternion.identity);
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.SplitShot)
            {
                Vector3 spawnPosition = transform.GetChild(1).position;
                
                Instantiate(bulletPrefab, spawnPosition + Vector3.right, Quaternion.identity);
                Instantiate(bulletPrefab, spawnPosition - Vector3.right, Quaternion.identity);
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.Projectile)
            {
                Vector3 spawnPosition = transform.GetChild(1).position;
                
                Instantiate(bulletPrefab, spawnPosition + Vector3.forward, Quaternion.identity);
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.DragonFire)
            {
                int numBullets = 8; // Number of bullets to spawn in a circular pattern
                float radius = 2f; // Radius of the circle

                Vector3 centerPosition = transform.position; // Center position for the circle (can adjust if needed)

                for (int i = 0; i < numBullets; i++)
                {
                    float angle = i * (360f / numBullets); // Calculate angle for each bullet

                    // Calculate position on circle using trigonometry
                    float x = centerPosition.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                    float z = centerPosition.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                    Vector3 spawnPosition = new Vector3(x, centerPosition.y, z);

                    // Instantiate bullet at calculated position with no rotation
                    Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                }

            }
        }
    }
}
