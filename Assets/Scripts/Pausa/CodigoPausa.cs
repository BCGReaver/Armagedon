using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir este espacio de nombres

public class CodigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa; // El menú de pausa
    private bool pausa = false; // Estado de pausa

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resumir(); // Resumir si está pausado
            }
            else
            {
                Pausar(); // Pausar si no lo está
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true); // Mostrar menú de pausa
        Time.timeScale = 0; // Pausar el tiempo
        Cursor.visible = true; // Hacer visible el cursor
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
        pausa = true; // Actualizar estado de pausa
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false); // Ocultar menú de pausa
        Time.timeScale = 1; // Reanudar el tiempo
        Cursor.visible = false; // Ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
        pausa = false; // Actualizar estado de pausa
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1; // Asegurarse de reanudar el tiempo antes de cambiar de escena
        SceneManager.LoadScene(NombreMenu); // Cambiar a la escena del menú
    }
}