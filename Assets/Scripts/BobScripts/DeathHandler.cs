using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    private bool dead; // Δείκτης θανάτου του παίκτη
    public Texture deathTexture; // Υφή για την εμφάνιση του θανάτου
    public Text GameOverText; // Text για την εμφάνιση του μηνύματος "GAME OVER"
    
    void Start()
    {
        dead = false;
    }

    // Επιστρέφει αν ο παίκτης είναι νεκρός
    public bool isDead() { return dead; }

    public void kill(){// Μέθοδος για τον θάνατο του παίκτη
        dead = true;
        this.GetComponent<Renderer>().material.mainTexture = deathTexture;
        GameOverText.text = "GAME OVER !";
    }
}
