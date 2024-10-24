using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcangelController : MonoBehaviour
{
    // Variables 
    public float airForce = 10f;
    public float gravityScale = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();

        // Ajustar la gravedad
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            // Aplicar una fuerza hacia arriba
            rb.AddForce(Vector2.up * airForce);
        }
    }
}
