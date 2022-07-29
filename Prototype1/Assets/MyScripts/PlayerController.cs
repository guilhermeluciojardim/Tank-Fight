using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    public GameObject turret;
    private float verticalAxis;
    private float turretSpeed = 10f;
    private float minRotation = -50f;
    private float maxRotation = 10f;

    // Start is called before the first frame update
    void Start()
    {
       StartAim();
    }
    // Update is called once per frame
    void Update()
    {   
        Aim();

    }

    void StartAim(){
        Vector3 resetAngles = new Vector3 (0,-90,0);
        turret.transform.rotation = Quaternion.Euler(resetAngles);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }
    //Function for aim the Turret
    private void Aim(){
        verticalAxis = Input.GetAxis("Vertical");
        turret.transform.Rotate(Vector3.left, verticalAxis * turretSpeed * Time.deltaTime);
        LimitRot();
    }
    //Function for limiting the rotation of the turret
    private void LimitRot(){
        Vector3 playerAngles = turret.transform.rotation.eulerAngles;

        playerAngles.x = (playerAngles.x > 180) ? playerAngles.x - 360 : playerAngles.x;
        playerAngles.x = Mathf.Clamp(playerAngles.x,minRotation,maxRotation);

        turret.transform.rotation = Quaternion.Euler(playerAngles);
    }
}