using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    //Makes list of the InventorySlot class
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount)
    {
        if(Container.Count == 0)
        {
            Container.Add(new InventorySlot(_item, _amount));
            return;
        }

        //Checks for duplicates
        bool hasItem = false;

        //Loop through inventory! Going through the Container List's count and checking all the items. Update the quantity and break out if item is found.
        //This repeats for every slot of existing inventory! Then it will break out and attempt the if statement.
        for (int i = 0; i < Container.Count; i++)
        {
             if(Container[i].item == _item)
             {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
             }
        }

        //If the item is not already found then create an inventory slot for it.
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
