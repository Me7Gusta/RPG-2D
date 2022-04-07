using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlots : MonoBehaviour
{
    public Image icon;
    public Sprite defaultSprite;

    Equipment item;

    public void AddItem(Equipment newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        if (item != null)
        {
            EquipmentManager.instance.Unequip((int)item.equipSlot);
            item = null;
            icon.sprite = defaultSprite;
        }
    }
}
