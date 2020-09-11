using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item)
        {
            //Accesses the inventory class and tells it to add this item. Then destroys the game object.
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            inventory.Load();
        }

    }

    private void OnApplicationQuit()
    {
        //Clear inventory when application is quit.
        inventory.Container.Clear();
    }
}
