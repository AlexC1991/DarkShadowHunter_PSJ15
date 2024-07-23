using System.Collections;
using UnityEngine;
using DarkShadowHunter;

public class BulletLifeTime : MonoBehaviour
{
    private GunAmmoToFire gAmmo;
    private Camera _camera;
    private ParticleSystem _particleSystem;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Material[] bulletMaterials;
    
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
                StartCoroutine(CheckingBulletColor());
        }
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject,0.02f);
    }

    private IEnumerator CheckingBulletColor()
    {
        TrailRenderer trailRenderer = this.gameObject.GetComponent<TrailRenderer>();

        if (trailRenderer != null)
        {
            Renderer renderer = this.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material objectMaterial = renderer.material;
                
                trailRenderer.material = objectMaterial;
            }
        }
        yield break;
    }
}
