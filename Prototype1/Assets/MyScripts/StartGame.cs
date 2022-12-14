using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public AudioClip swapAudio;
    public Button startButton;
    public Button nextButton;
    public bool gameStarted = false;
    public bool setFirstPlayer = false;
    public bool gameEnds=false;
    public int currentLevel;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        // If any player is hit, declares the winner
        if ((GameObject.Find("BustedTank(Clone)")!=null) && (gameStarted)){
            if (GameObject.Find("BustedTank(Clone)").transform.position.x == -23f){
            FinishRound("Blue");
            }               
            else if (GameObject.Find("BustedTank(Clone)").transform.position.x == 23f){
                            FinishRound("Red");
            }
        }
        
        // Set the first random player
        if ((gameStarted) && (!setFirstPlayer)){
            SetFirstRandomPlayer();
        }
        // change turns betwen players
        if (setFirstPlayer){
            if (player1Shooting.isTurn){
                // Wait for the shoot to finish and for the player to get ready for another shoot before changing turns
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
    // Method to clean variables and objects, finish round and declare the winner
    void FinishRound(string winner){
        gameStarted=false;
        setFirstPlayer=false;
        if (winner == "Blue"){
            player2Shooting.gameObject.SetActive(false);
            setTurn.color = Color.blue;
        }
        else{
            player1Shooting.gameObject.SetActive(false);
            setTurn.color = Color.red;
        }
        setTurn.text = winner + " Wins!!!";
        GetComponent<AudioSource>().Stop();
        AudioSwap();
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 1.0f;
        nextButton.gameObject.SetActive(true);
    }
    
    // method for setting the next scene
    public void NextScene(){
        currentLevel = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length-1));
        currentLevel++;
        nextLevel = currentLevel.ToString();
        nextLevel = "Level - " + nextLevel;
        if (currentLevel <= 3){
            SceneManager.LoadScene(nextLevel);
        }
        
    }
        

    // Method for swap the audio betwen the engine and background music
    void AudioSwap(){
        swapAudio = GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().clip = otherAudio;
        otherAudio = swapAudio;
    }
    // Method for change the wind direction and strengh
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
    // Method for setting the first random player
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
    // Method for setting the game on button Start is pressed
    public void SetGame(){
        gameStarted = true;
        startButton.gameObject.SetActive(false);
        GetComponent<AudioSource>().Stop();
        AudioSwap();
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.3f;
    }
    // Method for setting player 1 turn
    void SetPlayer1(){
            setTurn.text = "Blue Turn";
            setTurn.color = Color.blue;
            player1Slider.gameObject.SetActive(true);
            player2Slider.gameObject.SetActive(false);
            player1Shooting.isTurn = true;
            player2Shooting.isTurn = false;
            player1Control.GetComponent<PlayerController>().enabled = true;
            player1Shooting.GetComponent<PlayerShooting>().enabled = true;
            player2Control.GetComponent<PlayerController>().enabled = false;
            player2Shooting.GetComponent<PlayerShooting>().enabled = false;
            
    }
    // Method for setting player 2 turn
    void SetPlayer2(){
            setTurn.text = "Red Turn";
            setTurn.color = Color.red;
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
