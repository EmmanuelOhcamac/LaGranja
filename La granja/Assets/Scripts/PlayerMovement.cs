using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;

    public GameObject preFabTrigo;
    public GameObject preFabJitomate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener entrada del usuario
        float moveX = Input.GetAxisRaw("Horizontal"); // A,D o teclas de flecha izquierda/derecha
        float moveY = Input.GetAxisRaw("Vertical"); ;   // W,S o teclas de flecha arriba/abajo
        moveInput = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveInput.magnitude);

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(preFabTrigo, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(preFabJitomate, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        // Mover el personaje
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

   
}
