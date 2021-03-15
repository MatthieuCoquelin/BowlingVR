using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInterraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider>().material.staticFriction = 0.0f;
        gameObject.GetComponent<Collider>().material.frictionCombine = 0.0f;
        gameObject.GetComponent<Collider>().material.dynamicFriction = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
