using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeVertexColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeColor", 1.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeColor(){
        GetComponent<TextMeshPro>().colorGradient = new TMPro.VertexGradient(new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
    }

}
