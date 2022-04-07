using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script do Inventory principal
//salvar os items que tem no inventario
//esta  em GameManager

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            //Checar se ainda tem espaço no inventario
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false; // Se não tiver espaço sair
            }

            //Adicionar item no inventario
            items.Add(item);

            //Chamar delegate de troca de item
            if(onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
