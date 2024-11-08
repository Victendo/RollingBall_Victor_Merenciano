using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
     public void EntrarJuego()
    {
        SceneManager.LoadScene("EscenaFall");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
