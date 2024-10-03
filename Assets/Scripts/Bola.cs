using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bola : MonoBehaviour
{
    [SerializeField] Vector3 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Rigidbody>().AddForce(movimiento * 1, ForceMode.Impulse);
        }
    }
}
