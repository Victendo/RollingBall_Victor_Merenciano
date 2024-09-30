using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour
{

    [SerializeField] float velocidad;
    [SerializeField] Vector3 rotacionA;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotacionA * velocidad * Time.deltaTime);
            
    }
}
