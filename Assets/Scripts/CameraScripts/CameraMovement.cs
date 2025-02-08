using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform transform;
    private float speed = 10f;
    public GameObject treasureBob; // O Bob
    
    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    void Update()
    {
        // Αν ο Bob είναι ζωντανός, μπορούμε να κουνήσουμε την κάμερα
        if(!treasureBob.GetComponent<DeathHandler>().isDead()){
            if(Input.GetKey(KeyCode.RightArrow)){transform.Translate(speed * Time.deltaTime,0,0);} // Δεξιά
            if(Input.GetKey(KeyCode.LeftArrow)){transform.Translate(-speed * Time.deltaTime,0,0);} // Αριστερά
            if(Input.GetKey(KeyCode.UpArrow)){transform.Translate(0,speed * Time.deltaTime,0);} // Πάνο
            if(Input.GetKey(KeyCode.DownArrow)){transform.Translate(0,-speed * Time.deltaTime,0);} // Κάτο
            if(Input.GetKey(KeyCode.KeypadPlus)){transform.Translate(0,0,speed * Time.deltaTime);} //  Zoom in
            if(Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus)){transform.Translate(0,0,-speed * Time.deltaTime);} // Zoom out
            if(Input.GetKey(KeyCode.R)){transform.Rotate(speed * Time.deltaTime,0,0);} // Rotate
        }
    }
}
