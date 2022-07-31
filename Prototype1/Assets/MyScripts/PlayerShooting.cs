using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private bool fired = false;
    private float minCharge = 5f;
    private float maxCharge = 30f;
    private float chargeTime = 2.0f;
    private float chargeSpeed;
    private float currentCharge;
    public AudioSource shootingAudio;         
    public AudioClip chargeClip;            
    public AudioClip fireClip;  
    public Slider chargeSlider;

    public Transform shootTransform;

    public Rigidbody shellPrefab; 
    public bool isTurn;
    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = (maxCharge - minCharge) / chargeTime;
        chargeSlider.value = minCharge;
    }

    // Update is called once per frame
    void Update()
    {
        chargeSlider.value = minCharge;

        if ((currentCharge >= maxCharge) && (!fired)){
            currentCharge = maxCharge;
            Fire();
        }
        else if (Input.GetKeyDown(KeyCode.Space)){
            fired=false;
            currentCharge = minCharge;
            shootingAudio.clip = chargeClip;
            shootingAudio.Play();
        }
        else if ((Input.GetKey(KeyCode.Space)) && (!fired)){
            currentCharge += chargeSpeed * Time.deltaTime;
            chargeSlider.value = currentCharge;
        }
        else if ((Input.GetKeyUp(KeyCode.Space)) && (!fired)){
            Fire();
        }
    }
    void Fire(){
        shootingAudio.clip = fireClip;
        shootingAudio.Play();
        fired=true;

        Rigidbody shellInst =
                Instantiate (shellPrefab, shootTransform.position, shootTransform.rotation) as Rigidbody;
        shellInst.velocity = currentCharge * shootTransform.forward;
        

        currentCharge = minCharge;
    }
    
}
