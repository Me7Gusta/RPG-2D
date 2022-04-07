using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable object base dos items usaveis, equipamentos, consumiveis...

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";    //nome do item
    public Sprite icon = null;              //Icone-sprite do item
    public bool isDefaultItem = false;      //Se o item é default ou não; 

    public virtual void Use()
    {
        //usar o item 

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
