using UnityEngine;
using System.Collections;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;
    private Transform myTransform; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false; 
        myTransform = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(myTransform);
    }
}
