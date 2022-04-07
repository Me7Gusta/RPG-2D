using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable object dos equipamentos usando o script Item como base

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;       //Definir em qual slot o equip entra

    public int armorModifier;   //modificador de defesa
    public int damegeModifier;  //modificador de ataque

    public override void Use()
    {
        base.Use();

        //Equipar o item
        EquipmentManager.instance.Equip(this);

        //Remover do inventario
        RemoveFromInventory();

    }
}

public enum EquipmentSlot { Head, Chest, Legs, Feet, Weapon, Shield }
