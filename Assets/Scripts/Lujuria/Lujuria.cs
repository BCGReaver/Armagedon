using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lujuria : MonoBehaviour
{
    // Variables 
    public float floatingSpeed = 1.5f;
    public float minHeight = .5f;
    public float maxHeight = 3f;
    public float moveSpeed = -7f; // Velocidad de movimiento hacia la izquierda
    public float targetXPosition = -7f; // Posici�n objetivo en el eje X

    private bool movingUp = true; // Direcci�n actual (subiendo o bajando)
    private Rigidbody2D rb;
    private bool hasReachedTarget = false; // Indica si alcanz� la posici�n objetivo en X

    void Start()
    {
        // Rigidbody2D del enemigo
        rb = GetComponent<Rigidbody2D>();

        // Desactivar la gravedad para que el enemigo flote
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // Mover hacia la izquierda hasta alcanzar la posici�n objetivo
        if (!hasReachedTarget)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            // Verificar si alcanz� o pas� la posici�n objetivo en X
            if (transform.position.x <= targetXPosition)
            {
                hasReachedTarget = true;
                rb.velocity = new Vector2(0, rb.velocity.y); // Detener el movimiento horizontal
            }
        }

        // Verificar si el enemigo est� subiendo o bajando
        if (movingUp)
        {
            // Si est� subiendo, agregar una velocidad positiva hacia arriba
            rb.velocity = new Vector2(rb.velocity.x, floatingSpeed);

            // Si alcanza la altura m�xima, cambiar direcci�n
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            // Si est� bajando, agregar una velocidad negativa hacia abajo
            rb.velocity = new Vector2(rb.velocity.x, -floatingSpeed);

            // Si alcanza la altura m�nima, cambiar direcci�n
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }
        }
    }
}
