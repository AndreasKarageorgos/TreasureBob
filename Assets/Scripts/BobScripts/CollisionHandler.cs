using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private ScoreHandler scoreHandler;
    private DeathHandler deathHandler;
    private AudioSource sound;
    private float timer; // Χρονομετρητής για την εξαφάνιση του θησαυρού
    private float timeInterval; // Χρονικό διάστημα για την εξαφάνιση του θησαυρού

    private bool treasureFound; // Αναγνωρίζει αν βρέθηκε θησαυρός
    private GameObject collidedTreasure; // Αναφορά στο αντικείμενο του συγκρουόμενου θησαυρού
    void Start()
    {
        timer = 0f;
        treasureFound = false;
        timeInterval = 1f;
        scoreHandler = this.GetComponent<ScoreHandler>();
        deathHandler = this.GetComponent<DeathHandler>();
        sound = this.GetComponent<AudioSource>();
    }

    void Update(){
        if(treasureFound){ // Αν βρέθηκε θησαυρός, ξεκινάει ο χρονομετρητής για την εξαφάνισή του
            timer += Time.deltaTime;
            if(timer>=timeInterval){
                collidedTreasure.gameObject.GetComponent<MeshRenderer>().enabled = false;
                treasureFound = false;
            }
        }else{
            timer = 0; // Επαναφορά χρονομετρητή
        }
    }

    private void OnCollisionEnter(Collision collision){
        // Συγκρουση με θησαυρό
        if(collision.transform.tag.Contains("treasure")){
            collidedTreasure = collision.gameObject;
            collision.collider.enabled = false;
            sound.Play();
            collision.transform.localScale *= 0.5f;
            treasureFound = true;
        }
        // Προσδιορισμός τύπου θησαυρού και αύξηση σκορ ανάλογα
        if(collision.transform.tag == "treasureLemon"){
            Debug.Log("A treasure lemon has been found !");
            scoreHandler.setScore(scoreHandler.getScore()+1); // Αυξάνουμε το score κατά ένα.
        }
        else if(collision.transform.tag == "treasureOrange"){
            Debug.Log("A treasure orange has been found !");
            scoreHandler.setScore(scoreHandler.getScore()+2); // Αυξάνουμε το score κατά δύο.
        }
        else if(collision.transform.tag == "treasureCherry"){
            Debug.Log("A treasure cherry has been found !");
            scoreHandler.setScore(scoreHandler.getScore()+3); // Αυξάνουμε το score κατά τρία.
        }else if(collision.transform.tag == "enemy"){ // Συγκρουση με εχθρό
            deathHandler.kill();
            Debug.Log("You died.");
        }
    }

}
