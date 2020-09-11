using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;

    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();

    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize()
    {
        //Clears dictionary so we don't duplicate anything.
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            //Generate an ID number for everything in the dictionary.
            //Add item to the Dictionary. So when you check unity dictionary it updates to whatever scriptable object we're using
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }

        public void OnBeforeSerialize()
    {
    }

}
