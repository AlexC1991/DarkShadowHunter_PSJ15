using UnityEngine;
namespace DarkShadowHunter
{
    [CreateAssetMenu(fileName = "InventoryDataContainer", menuName = "InventoryDataContainer")]
    public class InventoryDataContainer : ScriptableObject
    {
        [System.Serializable]
        public struct InventoryData
        {
            public string inventoryItemName; 
            [HideInInspector] public int inventoryItemCounter;
            public Sprite inventoryItemSprite;
        }

        public InventoryData[] inventoryData;
    }
}