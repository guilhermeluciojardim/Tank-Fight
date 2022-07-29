using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public GameObject com;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = com.transform.position;
    }
    
}
