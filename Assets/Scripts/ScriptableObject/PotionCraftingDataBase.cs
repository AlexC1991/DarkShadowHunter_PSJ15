using System;
using UnityEngine;

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
