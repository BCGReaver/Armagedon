using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcangelController : MonoBehaviour
{
    // Variables 
    public float airForce = 5f;
    public float gravityScale = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();

        // Ajustar la gravedad
        rb.gravityScale = gravityScale;
    }

    /*private void Start()
    {
        InvokeRepeating(nameof(SpeedUpGame), 1f, 1f);
    }

    void SpeedUpGame()
    {
        Time.timeScale = Mathf.Min(Time.timeScale + 0.1f, 1.8f);
    }*/
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            // Aplicar una fuerza hacia arriba
            rb.AddForce(Vector2.up * airForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Proyectil"))  // Si el objeto que golpea es un proyectil
        {
            Debug.Log("Personaje golpeado, cambiando a la pantalla de Game Over.");
            TerminarJuego();  // Llamar la función para cambiar de escena
        }
    }

    // Método para cambiar a la escena de Game Over
    void TerminarJuego()
    {
        SceneManager.LoadScene("GameOver");  // Carga la escena de Game Over
    }
}
