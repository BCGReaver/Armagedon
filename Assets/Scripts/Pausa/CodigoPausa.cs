using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Aseg�rate de incluir este espacio de nombres

public class CodigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa; // El men� de pausa
    private bool pausa = false; // Estado de pausa

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resumir(); // Resumir si est� pausado
            }
            else
            {
                Pausar(); // Pausar si no lo est�
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true); // Mostrar men� de pausa
        Time.timeScale = 0; // Pausar el tiempo
        Cursor.visible = true; // Hacer visible el cursor
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
        pausa = true; // Actualizar estado de pausa
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false); // Ocultar men� de pausa
        Time.timeScale = 1; // Reanudar el tiempo
        Cursor.visible = false; // Ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
        pausa = false; // Actualizar estado de pausa
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1; // Asegurarse de reanudar el tiempo antes de cambiar de escena
        SceneManager.LoadScene(NombreMenu); // Cambiar a la escena del men�
    }
}