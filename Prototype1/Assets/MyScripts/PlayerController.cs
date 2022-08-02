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
    public AudioClip moveAudio;
    private bool pressed = false;
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {   
        Aim();
    }

    
    //Function for aim the Turret
    private void Aim(){
        verticalAxis = Input.GetAxis("Vertical1");
        turret.transform.Rotate(Vector3.left, verticalAxis * turretSpeed * Time.deltaTime);
        if ((Input.GetAxis("Vertical1")!=0) && (!pressed)){
            GetComponent<AudioSource>().clip = moveAudio;
            GetComponent<AudioSource>().volume = 0.35f;
            GetComponent<AudioSource>().Play();
            pressed=true;
        }
        if (Input.GetAxis("Vertical1")==0){
            GetComponent<AudioSource>().Stop();
            pressed=false;
        }
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