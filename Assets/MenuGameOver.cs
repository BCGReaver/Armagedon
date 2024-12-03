using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver; // Panel de Game Over
    [SerializeField] private ArcangelHealt arcangelHealt; // Referencia al Arc�ngel

    private void Start()
    {
        arcangelHealt = FindObjectOfType<ArcangelHealt>(); // Buscar autom�ticamente el componente en la escena

        if (arcangelHealt != null)
        {
            arcangelHealt.MuerteJugador += ActivarMenuGameOver;
        }
        else
        {
            Debug.LogError("No se encontr� el componente ArcangelHealt en la escena.");
        }
    }

    private void ActivarMenuGameOver(object sender, EventArgs e)
    {
        // Mostrar el men� de Game Over
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

