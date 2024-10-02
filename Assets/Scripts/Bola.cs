using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bola : MonoBehaviour
{
    [SerializeField] float velocidadHorizontal = 2;
    [SerializeField] float velocidadVertical = 2;
    [SerializeField] Vector3 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = velocidadHorizontal * Input.GetAxis("Horizontal");
        float v = velocidadVertical * Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, h, v) * Time.deltaTime);

    }
}
