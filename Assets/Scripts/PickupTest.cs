using System.Collections;
using DarkShadowHunter;
using UnityEngine;

public class PickupTest : MonoBehaviour
{
    [SerializeField] CustomizeableAmmo ammo;
    [SerializeField] private GunAmmoToFire ammoM;
    [TagSelector] [SerializeField] private string tagSelector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagSelector))
        {
            StartCoroutine(GivePlayerPowerUp());
        }
    }
    
    private IEnumerator GivePlayerPowerUp()
    {
        int randomPowerChoice = Random.Range(0, ammo.ammoTypesArray.Length);
        
        ammoM.ammoManager.Add(ammo.ammoTypesArray[randomPowerChoice]);
        
        ammoM.AddedElementalToGun();
        
        yield return new WaitForSeconds(1);
        
        Destroy(this.gameObject);
    }
}
