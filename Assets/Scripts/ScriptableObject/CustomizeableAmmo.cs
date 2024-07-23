using System;
using UnityEngine;

namespace DarkShadowHunter
{
    [CreateAssetMenu(fileName = "New Ammo", menuName = "Ammo")]
    public class CustomizeableAmmo : ScriptableObject
    {
        [Serializable]
        public struct ammoTypes
        {
            public ElementalType elementalType;
            public int damage;
            public AreaOfEffect areaOfEffect;
            public float shootingSpeed;
            public PlayerBuff playerBuff;
            public Capacity litersOfCapacity;
        }

        public enum ElementalType
        {
            Fire,
            Ice,
            Poison,
            Electric,
            Plasma,
            Light,
            DarkPlasma,
            None
        }

        public enum AreaOfEffect
        {
            SingleTarget,
            SplitShot,
            Projectile,
            DragonFire,
            None
        }

        public enum PlayerBuff
        {
            Health,
            Armor,
            MovementSpeed,
            DoubleMeleeDamage,
            DeadlyTouch,
            None
        }

        public enum Capacity
        {
            small,
            medium,
            large,
            huge,
        }

        public ammoTypes[] ammoTypesArray;
    }
}
