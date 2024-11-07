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

    [SerializeField] private int monedasActuales = 0;
    [SerializeField] private TMP_Text textoMonedas;
    [SerializeField] private AudioSource musicaMonedas;

    [SerializeField] private bool youLost;
    [SerializeField] private GameObject derrotaMenuUI;

    [SerializeField] private GameObject victoriaMenuUI;
    [SerializeField] private bool youWin;

    [SerializeField] private GameObject sinMonedasMenuUI;
    [SerializeField] private bool noCoins;

    [SerializeField] private GameObject contadorMonedasMenuUI;
    [SerializeField] private TMP_Text contarMonedas;
    [SerializeField] private bool countCoins;

    [SerializeField] private GameObject todasLasMonedasMenuUI;
    [SerializeField] private bool allCoins;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vidaActual = vidaMaxima;
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
            musicaMonedas.Play();
            Destroy(other.gameObject);
            monedasActuales++; ;
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

            if (monedasActuales <= 0)
            {
                noCoins = !noCoins;
                SinMonedas();
            }

            if (monedasActuales > 0 && monedasActuales < 62)
            {
                countCoins = !countCoins;
                ContadorMonedas();
            }

            if (monedasActuales >= 62)
            {
                allCoins = !allCoins;
                TodasMonedas();
            }
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

    public void SinMonedas()
    {
        sinMonedasMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void ContadorMonedas()
    {
        contadorMonedasMenuUI.SetActive(true);
        contarMonedas.SetText("Has conseguido: " + monedasActuales.ToString() + " monedas");
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void TodasMonedas()
    {
        todasLasMonedasMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }





}
