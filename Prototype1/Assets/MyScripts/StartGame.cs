using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public WindArea wind;
    private float maxWindStrength = 8f;
    private float minWindStrength = 3f;
    public int firstPlayerNumber;
    public TextMeshPro setTurn;
    public TextMeshPro WindTitle;
    public Scrollbar displayWind;
    public Slider player1Slider;
    public Slider player2Slider;
    public PlayerController player1Control;
    public PlayerController player2Control;
    public PlayerShooting player1Shooting;
    public PlayerShooting player2Shooting;
    public AudioClip otherAudio;
    private AudioClip swapAudio;
    public Button startButton;
    public bool gameStarted = false;
    public bool setFirstPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Set the first random player
        if ((gameStarted) && (!setFirstPlayer)){
            SetFirstRandomPlayer();
        }
        if (setFirstPlayer){
            if (player1Shooting.isTurn){
                if (player1Shooting.finishShoot){
                    if (player1Shooting.ready){
                        player1Shooting.finishShoot = false;
                        SetPlayer2();
                        ChangeWind();
                    }
                }
            }
            else{
                if (player2Shooting.finishShoot){
                    if (player2Shooting.ready){
                        player2Shooting.finishShoot = false;
                        SetPlayer1();
                        ChangeWind();
                    }
                }
            }
        }
    }
    void ChangeWind(){
        wind.strength = Random.Range(minWindStrength,maxWindStrength);
        wind.direction = new Vector3(Random.Range(-1,2),0,0);
        Vector3 left = new Vector3(1,0,0);
        Vector3 mid = new Vector3(0,0,0);
        Vector3 right = new Vector3(-1,0,0);
        if (wind.direction == left){
            displayWind.value = (0.5f / wind.strength);
        }
        else if (wind.direction == right){
            displayWind.value = 1f - (0.5f / wind.strength) ;
        }
        else{
            displayWind.value = 0.5f;
        }
    }

    void SetFirstRandomPlayer(){
        ChangeWind();
        firstPlayerNumber = Random.Range(1,3);
        if (firstPlayerNumber == 1){
            SetPlayer1();
        }
        else{
            SetPlayer2();
        }
        setFirstPlayer = true;
    }
    public void SetGame(){
        gameStarted = true;
        startButton.gameObject.SetActive(false);
        swapAudio = GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().clip = otherAudio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.3f;
    }
    void SetPlayer1(){
            setTurn.text = "Blue Turn";
            player1Slider.gameObject.SetActive(true);
            player2Slider.gameObject.SetActive(false);
            player1Shooting.isTurn = true;
            player2Shooting.isTurn = false;
            player1Control.GetComponent<PlayerController>().enabled = true;
            player1Shooting.GetComponent<PlayerShooting>().enabled = true;
            player2Control.GetComponent<PlayerController>().enabled = false;
            player2Shooting.GetComponent<PlayerShooting>().enabled = false;
            
    }
    void SetPlayer2(){
            setTurn.text = "Red Turn";
            player2Slider.gameObject.SetActive(true);
            player1Slider.gameObject.SetActive(false);
            player2Shooting.isTurn = true;
            player1Shooting.isTurn = false;
            player1Control.GetComponent<PlayerController>().enabled = false; 
            player1Shooting.GetComponent<PlayerShooting>().enabled = false;
            player2Control.GetComponent<PlayerController>().enabled = true;
            player2Shooting.GetComponent<PlayerShooting>().enabled = true;
           
    }
}
