using System.Collections.Generic;
using UnityEngine;

namespace DarkShadowHunter
{
    public class GunAmmoToFire : MonoBehaviour
    {
        public List<CustomizeableAmmo.ammoTypes> ammoManager = new List<CustomizeableAmmo.ammoTypes>(5);

        public void AddedElementalToGun()
        {
            if (ammoManager.Count <= ammoManager.Capacity)
            {
                foreach (var ammo in ammoManager)
                {
                    switch (ammo.elementalType)
                    {
                        case CustomizeableAmmo.ElementalType.Fire:
                            Debug.Log("Firing Fire Ammo: " + ammo.damage + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.Ice:
                            Debug.Log("Firing Ice Ammo: " + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.Poison:
                            Debug.Log("Firing Poison Ammo: " + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.Electric:
                            Debug.Log("Firing Electric Ammo: " + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.Plasma:
                            Debug.Log("Firing Plasma Ammo" + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.Light:
                            Debug.Log("Firing Light Ammo" + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        case CustomizeableAmmo.ElementalType.DarkPlasma:
                            Debug.Log("Firing Light Ammo" + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        
                        case CustomizeableAmmo.ElementalType.None:
                            Debug.Log("Firing No Ammo" + " damage, Area of Effect: " + ammo.areaOfEffect 
                                      + " shooting speed: " + ammo.shootingSpeed + " player buff: " + ammo.playerBuff 
                                      + " capacity: " + ammo.litersOfCapacity);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Debug.Log("Gun is full of ammo");
            }
        }
    }
}
