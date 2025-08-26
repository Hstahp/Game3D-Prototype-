using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "ScriptableObjects/ItemProfileSO", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode;
    public string itemName; 
    public bool isStackable = false;
}