using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;

    public GameObject Platform;

    private void OnTriggerEnter(Collider collid)
    {
        if (collid.gameObject.tag == "Player")
        {
            collid.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider collid)
    {
        if (collid.gameObject.tag == "Player")
        {
            collid.transform.parent = null;
        }
    }
}
