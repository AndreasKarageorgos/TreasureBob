using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreasureBobMovements : MonoBehaviour
{

    public float speed = 5f; // Ταχύτητα κίνησης του Bob
    private Transform transform;
    private DeathHandler deathHandler;
    void Start()
    {
        transform = this.GetComponent<Transform>();
        deathHandler = this.GetComponent<DeathHandler>();
        
    }

    void Update()
    {
        
        //===============================================================================================
        if(!deathHandler.isDead()){ // Αν ο Bob είναι ζωντανός, ενεργοποιούμε τον έλεγχο της κίνησης
            if(Input.GetKey(KeyCode.L)){transform.Translate(0,0, speed * Time.deltaTime);} // Δεξιά κίνηση.
            if(Input.GetKey(KeyCode.J)){transform.Translate(0,0, -speed * Time.deltaTime);} // Αριστερή κίνηση.
            if(Input.GetKey(KeyCode.I)){transform.Translate(-speed * Time.deltaTime,0,0);} // Πάνο κίνηση.
            if(Input.GetKey(KeyCode.K)){transform.Translate(speed * Time.deltaTime,0,0);} // Κάτο κίνηση.
        }
        //===============================================================================================
        
        //=================================
        if(Input.GetKeyDown(KeyCode.Z)){ // Αυξάνουμε την ταχύτητα
            if(speed<10){speed+=1f;}}
        if(Input.GetKeyDown(KeyCode.X)){ // Μειώνουμε την ταχύτητα
            if(speed>5){speed-=1f;}
        }
        //=================================
        
    }
}
