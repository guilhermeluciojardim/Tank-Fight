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
    public int firstPlayer;
    public TextMeshPro setTurn;
    public Scrollbar displayWind;
    public Slider player1Slider;
    public Slider player2Slider;
    public PlayerController player1Control;
    public PlayerController player2Control;
    public PlayerShooting player1Shooting;
    public PlayerShooting player2Shooting;

    // Start is called before the first frame update
    void Start()
    {
        wind.strength = Random.Range(minWindStrength,maxWindStrength);
        wind.direction = new Vector3(Random.Range(-1,2),0,0);
        firstPlayer = Random.Range(1,3);
        Vector3 left = new Vector3(1,0,0);
        Vector3 mid = new Vector3(0,0,0);
        Vector3 right = new Vector3(-1,0,0);
         

        if (wind.direction == left){
            displayWind.value = (0.5f / wind.strength);
        }
        else if (wind.direction == right){
            displayWind.value = (0.5f / wind.strength) + 0.5f ;
        }
        else{
            displayWind.value = 0.5f;
        }

        if (firstPlayer == 1){
            setTurn.text = "Blue Turn";
            player1Slider.gameObject.SetActive(true);
            player2Control.GetComponent<PlayerController>().enabled = !player2Control.GetComponent<PlayerController>().enabled;
            player2Shooting.GetComponent<PlayerShooting>().enabled = !player2Shooting.GetComponent<PlayerShooting>().enabled;
            
        }
        else{
            setTurn.text = "Red Turn";
            player2Slider.gameObject.SetActive(true);
            player1Control.GetComponent<PlayerController>().enabled = !player1Control.GetComponent<PlayerController>().enabled;
            player1Shooting.GetComponent<PlayerShooting>().enabled = !player1Shooting.GetComponent<PlayerShooting>().enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //wind.strength = Random.Range(minWindStrength,maxWindStrength);
        //wind.direction = new Vector3(Random.Range(-1,2),0,0);
    }
}
