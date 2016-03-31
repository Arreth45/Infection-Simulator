using UnityEngine;

public class person : MonoBehaviour {
    private bool isInfected,isAlive,isDead;
    private float runspeed;

	// Use this for initialization
	void Start () {
        
        
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isAlive){
            //code to run from "zombies"
        }
        
        if(isInfected){
            //code to chase alive people
           //after some time the zombies will die off
        }
        
        if(isDead){
            Destroy(gameObject);         
        }     	
	}
}
