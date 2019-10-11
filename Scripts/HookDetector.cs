using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable")
        {
            player.GetComponent<GrapplingHook>().hooked = true;

            player.GetComponent<GrapplingHook>().hookedObj = other.gameObject;


        }

    }

}
