using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    [SerializeField] float velocidadRotacion;
    [SerializeField] Vector3 movimientoRotacion;
    [SerializeField] Vector3 movimientoPosicion;
    [SerializeField] float velocidadPosicion;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movimientoRotacion * velocidadRotacion * Time.deltaTime);
        transform.Translate(movimientoPosicion * velocidadPosicion * Time.deltaTime);
        timer += 1 * Time.deltaTime;
        if (timer >= 1)
        {
            movimientoPosicion = -movimientoPosicion;
            timer = 0;
        }
    }
}
