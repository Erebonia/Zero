using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class HealObject : ItemObject
{
    public int restoreHealthValue;

    // Start is called before the first frame update
    void Start()
    {
        type = ItemType.Food;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
