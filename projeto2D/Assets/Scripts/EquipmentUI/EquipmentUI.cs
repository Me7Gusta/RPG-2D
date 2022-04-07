using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject equipmentUI;

    EquipmentManager equipment;    //Salvar o caminho do inventario no cache

    EquipSlots[] slots;

    private void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.onEquipmentChanged += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<EquipSlots>();
    }

    private void Update()
    {
        //Checar se o jogador apertou o botao do inventario
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Ativar ou desativar inventario
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
    }

    void UpdateUI(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i == (int)newItem.equipSlot)
                {
                    slots[i].AddItem(newItem);
                }
            }
        }
    }
}
