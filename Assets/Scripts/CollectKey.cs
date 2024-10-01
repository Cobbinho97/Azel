using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectKey : MonoBehaviour
{
    public GameObject Key;

    [SerializeField]
    GameObject door;

    public GameObject KeyCollectedText;

    public AudioSource collectSound;

    void Start()
    {
        KeyCollectedText.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectSound.Play();
            KeyCollectedText.SetActive(true);
            door.transform.position += new Vector3(0, 5, 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(Key);
        KeyCollectedText.SetActive(false);
    }
}
