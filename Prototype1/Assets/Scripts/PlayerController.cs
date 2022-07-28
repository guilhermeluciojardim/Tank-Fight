using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public Rigidbody playerRbLeft;   
 public Rigidbody playerRbRight; 
    // Start is called before the first frame update
    void Start()
    {
        playerRbLeft = GetComponent<Rigidbody>();
        playerRbRight = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Vertical")){
            playerRbLeft.AddForce(Vector3.forward * Time.deltaTime);
            playerRbRight.AddForce(Vector3.forward * Time.deltaTime);
        }
    }
}
