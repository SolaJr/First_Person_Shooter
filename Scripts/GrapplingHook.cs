using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;

    private bool grounded;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fired == false)
            fired = true;

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }

        if (hooked == true)
        {
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 2)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * 2f);
                this.transform.Translate(Vector3.up * Time.deltaTime * 10f);
              
            }
        }
        else
        {
            hook.transform.parent = hookHolder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;

        }


    }

    void ReturnHook()
    {
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;

    }
    void CheckGround()
    {
        RaycastHit hit;
        float distance = 1f;

        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }
        else { grounded = false; }
    }
}
