using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseGO;

   public void ShowPause()
    {
        PauseGO.SetActive(true);
    }
}
