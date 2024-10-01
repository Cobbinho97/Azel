using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private LifeManager lifeSystem;

    void Start()
    {

        lifeSystem = FindObjectOfType<LifeManager>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            lifeSystem.TakeLife();
        }
    }
}
