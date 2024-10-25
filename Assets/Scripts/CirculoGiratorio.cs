using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculoGiratorio : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] Vector3 movimiento;
    [SerializeField] float fuerza;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(movimiento * fuerza, ForceMode.Impulse);
    }
}
