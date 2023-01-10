using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFalling : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have passes the border");
        player.transform.position = respawnPoint.transform.position;
    }
}
