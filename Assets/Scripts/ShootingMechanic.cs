using System;
using System.Collections;
using UnityEngine;
using DarkShadowHunter;
public class ShootingMechanic : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private GunAmmoToFire ammoToFire;
    [SerializeField] private Material[] bulletMaterials;
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

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
            Material bulletMaterial = GetColorForElementalType(g.elementalType);

            if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.SingleTarget)
            {
                if (bulletPrefab != null)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(1).transform.position, Quaternion.identity);
                    bullet.GetComponent<Renderer>().material = bulletMaterial;
                    Rigidbody _rb = bullet.GetComponent<Rigidbody>();
                    //_rb.useGravity = false;
                    _rb.AddForce(_camera.transform.forward * g.shootingSpeed, ForceMode.Impulse);
                }
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.SplitShot)
            {
                if (bulletPrefab != null)
                {
                    GameObject bulletOne = Instantiate(bulletPrefab, transform.GetChild(1).transform.position + new Vector3(0.06f,0,0), Quaternion.identity);
                    GameObject bulletTwo = Instantiate(bulletPrefab, transform.GetChild(1).transform.position - new Vector3(0.06f,0,0), Quaternion.identity);
                    bulletOne.GetComponent<Renderer>().material = bulletMaterial;
                    bulletTwo.GetComponent<Renderer>().material = bulletMaterial;
                    Rigidbody _rbOne = bulletOne.GetComponent<Rigidbody>();
                    Rigidbody _rbTwo = bulletTwo.GetComponent<Rigidbody>();
                    //_rbOne.useGravity = false;
                    //_rbTwo.useGravity = false;
                    _rbOne.AddForce(_camera.transform.forward * g.shootingSpeed, ForceMode.Impulse);
                    _rbTwo.AddForce(_camera.transform.forward * g.shootingSpeed, ForceMode.Impulse);
                }
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.Projectile)
            {
                if (bulletPrefab != null)
                {
                    StartCoroutine(ProjectileBuller());
                }
            }
            else if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.DragonFire)
            {
                if (bulletPrefab != null)
                {
                    StartCoroutine(DrageonFireAction());
                }
            }
        }
    }

    private IEnumerator ProjectileBuller()
    {
        foreach (var g in ammoToFire.ammoManager)
        {
            if (g.areaOfEffect == CustomizeableAmmo.AreaOfEffect.Projectile)
            {
                Material bulletMaterial = GetColorForElementalType(g.elementalType);
                
                GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(1).transform.position + new Vector3(0,0.3f,0), _camera.transform.rotation);
                bullet.GetComponent<Renderer>().material = bulletMaterial;
                Rigidbody _rb = bullet.GetComponent<Rigidbody>();
                _rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
                _rb.AddForce(_camera.transform.forward * 3, ForceMode.VelocityChange);
                yield return new WaitForSeconds(0.1f);
                _rb.AddForce(Vector3.down * 3, ForceMode.Impulse);
                yield return new WaitForSeconds(0.2f);
                _rb.AddForce(Vector3.down * 4, ForceMode.Impulse);

            }
        }
    }

    private IEnumerator DrageonFireAction()
    {
        foreach (var g in ammoToFire.ammoManager)
        {
            Material bulletMaterial = GetColorForElementalType(g.elementalType);
        
            for (int i = 0; i < 4; i++) 
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(1).position, _camera.transform.rotation);
                Rigidbody _rb = bullet.GetComponent<Rigidbody>();
                bullet.GetComponent<Renderer>().material = bulletMaterial;

                
                Vector3 direction = Quaternion.Euler(0, 0, i * 90) * _camera.transform.forward;

                _rb.AddForce(direction * g.shootingSpeed, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(0.2f); 
        }
    }

    public Material GetColorForElementalType(CustomizeableAmmo.ElementalType type)
    {
        switch (type)
        {
            case CustomizeableAmmo.ElementalType.Fire:
                return bulletMaterials[0];
            case CustomizeableAmmo.ElementalType.Ice:
                return bulletMaterials[1];
            case CustomizeableAmmo.ElementalType.Poison:
                return bulletMaterials[2];
            case CustomizeableAmmo.ElementalType.Electric:
                return bulletMaterials[3];
            case CustomizeableAmmo.ElementalType.Plasma:
                return bulletMaterials[4];
            case CustomizeableAmmo.ElementalType.Light:
                return bulletMaterials[5];
            case CustomizeableAmmo.ElementalType.DarkPlasma:
                return bulletMaterials[6];
            default:
                return null; // Default color
        }
    }
}
