using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;

    //Dictionary that holds everything in the inventory slots.
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            
            if (itemsDisplayed.ContainsKey(slot))
            {
                //For loop checks every inventory slot and we set each of them to the real-time quantity.
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }else{
            GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            //Set text mesh pro in unity to display the quantity of the item. Also formatted it with n0 to make commas when numbers get too high.
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");

            //Add to dictionary
            itemsDisplayed.Add(slot, obj);
            }
        }
    }

    public void CreateDisplay()
    {
        //Go through every single inventory slot that currently exists.
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];

            GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);

            obj.transform.GetChild(0).GetComponent<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;

            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            //Set text mesh pro in unity to display the quantity of the item. Also formatted it with n0 to make commas when numbers get too high.
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            
            //Add to dictionary
            itemsDisplayed.Add(slot, obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START +(-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f);
    }
}
