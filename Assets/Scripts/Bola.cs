using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Bola : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int velocidad;
    [SerializeField] private int fuerzaSalto;
    [SerializeField] private int fuerzaMovimiento;
    private float h, v;

    [SerializeField] private int vidaActual;
    [SerializeField] private int vidaMaxima = 100;
    [SerializeField] private TMP_Text textoVida;

    [SerializeField] private int monedasActuales;
    [SerializeField] private TMP_Text textoMonedas;

    [SerializeField] private bool youLost;
    [SerializeField] private GameObject derrotaMenuUI;

    [SerializeField] private GameObject victoriaMenuUI;
    [SerializeField] private bool youWin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vidaActual = vidaMaxima;
        monedasActuales = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Salto();
        MenuDerrota();

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.AddForce (new Vector3(h, 0, v).normalized * velocidad, ForceMode.Force);
        

       

    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Moneda"))
        {
            Destroy(other.gameObject);
            monedasActuales = monedasActuales + 1;
            textoMonedas.SetText(monedasActuales.ToString());
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trampa")
        {
            vidaActual -= collision.gameObject.GetComponent<Trampa>().Daño;
            textoVida.SetText(vidaActual.ToString());
           
        }

        if (collision.gameObject.tag == "Victoria")
        {
            youWin = !youWin;
            MenuVictoria();
        }
    }

    void MenuDerrota()
    {
        if (vidaActual <= 0)
        {
            youLost = !youLost;
        }

        if (youLost)
        {
            ActivateMenu();
        }

    }

    public void ActivateMenu()
    {
        derrotaMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MenuVictoria()
    {
        if (youWin)
        {
            ActivateVictoria();
        }
    }

    public void ActivateVictoria()
    {
        victoriaMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }





}
