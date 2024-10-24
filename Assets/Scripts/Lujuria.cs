using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lujuria : MonoBehaviour
{
    // Variables 
    public float floatingSpeed = 1.5f;
    public float minHeight = .5f;
    public float maxHeight = 3f;

    private bool movingUp = true; // Dirección actual (subiendo o bajando)

    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D del enemigo
        rb = GetComponent<Rigidbody2D>();

        // Desactivar la gravedad para que el enemigo flote
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // Verificar si el enemigo está subiendo o bajando
        if (movingUp)
        {
            // Si está subiendo, agregar una velocidad positiva hacia arriba
            rb.velocity = new Vector2(rb.velocity.x, floatingSpeed);

            // Si alcanza la altura máxima, cambiar dirección
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            // Si está bajando, agregar una velocidad negativa hacia abajo
            rb.velocity = new Vector2(rb.velocity.x, -floatingSpeed);

            // Si alcanza la altura mínima, cambiar dirección
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }
        }
    }
}

