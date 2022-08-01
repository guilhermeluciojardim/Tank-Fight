using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;
    public ParticleSystem shellExplosionPrefab;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate(){
        if (windZone){
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "WindArea"){
            windZone = coll.gameObject;
            inWindZone = true;
        }
         if (coll.gameObject.tag == "Obstacle"){
            Instantiate(shellExplosionPrefab,transform.position,transform.rotation);
            StartCoroutine(WaitForExplosion(2f));
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "WindArea"){
            inWindZone = false;
        }
    }
    IEnumerator WaitForExplosion(float time){
        yield return new WaitForSeconds(time); 
   }
  
}
