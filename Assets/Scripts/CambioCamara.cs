using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{

    [SerializeField] private GameObject camaraFollow;
    [SerializeField] private GameObject camaraSegunda;
    [SerializeField] private bool estadoCamaraFollow = true;
    [SerializeField] private bool estadoCamaraSegunda = false;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            camaraFollow.SetActive(!estadoCamaraFollow);
            camaraSegunda.SetActive(!estadoCamaraSegunda);
        }
    }
}
