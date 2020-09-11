using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;

    public ItemDatabaseObject database;

    public Inventory Container;

    public void AddItem(Item _item, int _amount)
    {

        if (_item.buffs.Length > 0)
        {
            Container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
            return;
        }

        if(Container.Items.Count == 0)
        {
            Container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
            return;
        }

        //Loop through inventory! Going through the Container List's count and checking all the items. Update the quantity and break out if item is found.
        //This repeats for every slot of existing inventory! Then it will break out and attempt the if statement.
        for (int i = 0; i < Container.Items.Count; i++)
        {
             if(Container.Items[i].item.Id == _item.Id)
             {
                Container.Items[i].AddAmount(_amount);
                return;
             }
        }
        Container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
    }

    [ContextMenu("Save")]
    public void Save()
    {
/*         string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close(); */

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();

        Debug.Log("Saved Inventory");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
/*             BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close(); */

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Loaded Inventory");
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }

}

[System.Serializable]
public class Inventory{
    //Makes list of the InventorySlot class
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
