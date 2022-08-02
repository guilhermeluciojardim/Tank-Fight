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
    public bool isTurn = false;
    public bool finishShoot = false;
    public bool ready=true;
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
        // If charge slider is at MAX, Fire the Shell
        if ((currentCharge >= maxCharge) && (!fired) && (ready)){
            currentCharge = maxCharge;
            Fire();
        }
        // Else if Space key is Pressed, charge the slider
        else if ((Input.GetKeyDown(KeyCode.Space)) && (ready)){
            fired=false;
            currentCharge = minCharge;
            shootingAudio.clip = chargeClip;
            shootingAudio.volume = 1f;
            shootingAudio.Play();
        }
        // If the key is still pressed, keep charging
        else if ((Input.GetKey(KeyCode.Space)) && (!fired) && (ready)) {
            currentCharge += chargeSpeed * Time.deltaTime;
            chargeSlider.value = currentCharge;
        }
        // if the Space key is up, Fire
        else if ((Input.GetKeyUp(KeyCode.Space)) && (!fired) && (ready)){
            Fire();
        }
        // if the Shell explodes, ready the player for the next shoot
        if (GameObject.Find("Shell(Clone)")!=null){
            ready=false;
        }
        else{
            ready=true;
        }
        
    }
    //Method for instantianting the shell according to the shot charge
    void Fire(){
        shootingAudio.clip = fireClip;
        shootingAudio.volume = 1f;
        shootingAudio.Play();
        fired=true;
        finishShoot=true;
        Rigidbody shellInst =
                Instantiate (shellPrefab, shootTransform.position, shootTransform.rotation) as Rigidbody;
        shellInst.velocity = currentCharge * shootTransform.forward;
        currentCharge = minCharge;

    }
}
