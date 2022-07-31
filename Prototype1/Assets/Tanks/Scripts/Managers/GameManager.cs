using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStart : MonoBehaviour
{
     public WindArea wind;
    private float maxWindStrength = 5f;
    private float minWindStrength = 0f;
    public int firstPlayer;
    public TextMeshPro setTurn;
    // Start is called before the first frame update
    void Start()
    {
        wind.strength = Random.Range(minWindStrength,maxWindStrength);
        wind.direction = new Vector3(Random.Range(-1,2),0,0);
        firstPlayer = Random.Range(1,3);
        if (firstPlayer == 1){

        }
    }

    // Update is called once per frame
    void Update()
    {
        wind.strength = Random.Range(minWindStrength,maxWindStrength);
        wind.direction = new Vector3(Random.Range(-1,2),0,0);
    }
}