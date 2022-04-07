using UnityEngine;

//Interagivel com o jogador
//Script base para usar em diferentes scripts
public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interagiu com " + gameObject.name);
    }

}
