using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que cuida da UI do inventario
//Fica em Canvas

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;    //Salvar o caminho do inventario no cache

    InventorySlot[] slots;

    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update() 
    {
        //Checar se o jogador apertou o botao do inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Ativar ou desativar inventario
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
