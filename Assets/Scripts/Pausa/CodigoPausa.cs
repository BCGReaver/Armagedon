using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CodigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa; 
    private bool pausa = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resumir(); 
            }
            else
            {
                Pausar(); 
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true); 
        Time.timeScale = 0; 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
        pausa = true; 
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false); 
        Time.timeScale = 1; 
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
        pausa = false; 
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(NombreMenu); 
    }
}