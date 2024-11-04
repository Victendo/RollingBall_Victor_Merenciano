using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject camaraFollow;
    [SerializeField] private GameObject camaraSegunda;
    [SerializeField] private bool estadoCamaraFollow  = true;
    [SerializeField] private bool estadoCamaraSegunda = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            camaraFollow.SetActive(estadoCamaraFollow);
            camaraSegunda.SetActive(estadoCamaraSegunda);
        }
    }
}
