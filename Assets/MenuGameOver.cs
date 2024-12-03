using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver; // Panel de Game Over
    [SerializeField] private ArcangelHealt arcangelHealt; // Referencia al Arcángel

    private void Start()
    {
        arcangelHealt = FindObjectOfType<ArcangelHealt>(); // Buscar automáticamente el componente en la escena

        if (arcangelHealt != null)
        {
            arcangelHealt.MuerteJugador += ActivarMenuGameOver;
        }
        else
        {
            Debug.LogError("No se encontró el componente ArcangelHealt en la escena.");
        }
    }

    private void ActivarMenuGameOver(object sender, EventArgs e)
    {
        // Mostrar el menú de Game Over
        menuGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

