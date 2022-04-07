using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    //Components
    private Animator animator;
    private Rigidbody2D rb;
    //private CapsuleCollider2D capsule;      //Var para referenciar o colisor do personagem

    private Interactable item;

    //Player
    [SerializeField] private float MoveSpeed = 5f;  //velocidade do jogador

    private Vector2 movement;       //Vetor para movimentar o jogador salvando o seu input
    private Vector2 lookSide;       //Vetor para salvar o input e deixar o jogador olhando para o lado em que andou

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //capsule = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Inputs();
        LookingSide();
        SetAnimations();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement.normalized * MoveSpeed * Time.fixedDeltaTime));
    }

    private void Inputs() //Controles do Player
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Action"))
        {
            if (item != null)
            {
                item.Interact();
            }
        }
    }

    private void SetAnimations() //setar as variaveis das animações
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("LookX", lookSide.x);
        animator.SetFloat("LookY", lookSide.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void LookingSide() //fazer o player olhar para a direção q esta indo
    {
        if (movement.x > 0)
        {
            lookSide.x = 1f;
            lookSide.y = 0f;
        }
        else if (movement.x < 0)
        {
            lookSide.x = -1f;
            lookSide.y = 0f;
        }

        if (movement.y > 0)
        {
            lookSide.x = 0f;
            lookSide.y = 1f;
        }
        else if (movement.y < 0)
        {
            lookSide.x = 0f;
            lookSide.y = -1f;
        }

        //caso estega andando em diagonal dar preferencia a movimentação em y
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            item = collision.GetComponent<Interactable>();
            Debug.Log("Esta perto da " + item.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            item = null;
            //Debug.Log("Esta longe do item");
        }
    }
}
