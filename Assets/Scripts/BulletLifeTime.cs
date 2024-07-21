using System.Collections;
using UnityEngine;
using DarkShadowHunter;

public class BulletLifeTime : MonoBehaviour
{
    private GunAmmoToFire gAmmo;
    private Camera _camera;
    [SerializeField] private Rigidbody _rb;
    
    private void Start()
    {
        gAmmo = FindObjectOfType<GunAmmoToFire>();
        _rb.useGravity = false;
        _camera = FindObjectOfType<Camera>();
        StartCoroutine(BulletLife());
    }

    private IEnumerator BulletLife()
    {
        foreach (var g in gAmmo.ammoManager)
        {
            
        }

        // Destroy the original bullet instance
        Destroy(gameObject);
        
        yield return null;
    }

   
    
    
}
