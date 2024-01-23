using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit Gravity;
    private Rigidbody rigidbody;

    public float RotationSpeed = 20; 

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Gravity)
        {
            Vector3 gravityUp = Vector3.zero;

            gravityUp = (transform.position - Gravity.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetrotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

            transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);

           // rigidbody.AddForce(-gravityUp * Gravity.Gravity) * rigidbody.mass; <--- FIX!!

        }
    }
}
