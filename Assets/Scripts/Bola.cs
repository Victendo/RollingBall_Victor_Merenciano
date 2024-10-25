using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trampa")
        {
            vidaActual -= collision.gameObject.GetComponent<Trampa>().Daño;
            textoVida.SetText(vidaActual.ToString());
           
        }
    }





}
