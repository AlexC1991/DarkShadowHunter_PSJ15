using System;
using UnityEngine;
using UnityEngine.UI;

namespace DarkShadowHunter
{
    [CreateAssetMenu(fileName = "PotionCraftingDataBase", menuName = "PotionCraftingDataBase")]
    public class PotionCraftingDataBase : ScriptableObject
    {
        [Serializable]
        
        public struct potionCraftingData
        {
            public string nameOfPotion;
            public PotionIngredients potionIngredients;
            public PotionExpLevel expLevelOfPotion;
            public Sprite potionIcon;
            public int potionCount;
        }
        
        public enum PotionIngredients
        {
            BlackAsh,
            DarkBead,
            GloomResidue,
            TaintedFlesh,
            BlackAshDarkBead,
            BlackAshGloomResidue,
            BlackAshTaintedFlesh,
            DarkBeadGloomResidue,
            DarkBeadTaintedFlesh,
            GloomResidueTaintedFlesh,
            BlackAshDarkBeadGloomResidue,
            BlackAshDarkBeadTaintedFlesh,
            BlackAshGloomResidueTaintedFlesh,
            DarkBeadGloomResidueTaintedFlesh,
            BlackAshDarkBeadGloomResidueTaintedFlesh
        }
        
        public enum PotionExpLevel
        {
            Novice,
            Apprentice,
            Adept,
            Expert,
            Master
        }
        
        public potionCraftingData[] potionsToCraft;

    }
}
