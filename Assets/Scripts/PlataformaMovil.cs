using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] Vector3 movimiento;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movimiento * velocidad * Time.deltaTime);
        timer += 1 * Time.deltaTime;
        if (timer >= 5 )
        {
            movimiento = -movimiento;
            timer = 0;

        }

    }
}
