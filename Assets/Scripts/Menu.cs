using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuOpciones;
    public void EntrarJuego()
    {
        SceneManager.LoadScene("EscenaFall");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void EntrarOpciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void SalirOpciones()
    {
        menuInicio.SetActive(true);
        menuOpciones.SetActive(false);
    }
}
