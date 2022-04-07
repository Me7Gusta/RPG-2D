using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script para itens pegaveis no cenario
//Comtem o item Scriptable que ficara no inventario
//vai no game object do item no mapa

public class ItemPickup : Interactable
{
    public Item item;                   //Object com informações do item
    private SpriteRenderer sprtRender;  //Sprite renderer do objeto;

    private void Start()
    {
        sprtRender = GetComponent<SpriteRenderer>();
        sprtRender.sprite = item.icon;      //mostrar o sprite do item
    }

    public override void Interact()
    {
        //sobreescrever o Interact adicionando linhas caso necessario

        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        //Checar se há espaço no Inventario
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp) // se sim tirar o item de Cena
        {
            Debug.Log("Voce pegou " + item.name);
            Destroy(gameObject);
        }
    }
}
