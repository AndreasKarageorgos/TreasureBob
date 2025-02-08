using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreasureHandler : MonoBehaviour
{

    
    public GameObject Enemies; //Η ομάδα με τους εχθρούς.
    public float treasureInterval; // Διάστημα σε δευτερόλεπτα για να καλεστεί η μέθοδος
    private float treasureTimer; // Χρονοδιακόπτης για την παρακολούθηση του χρόνου που έχει παρέλθει
    private GameObject[] treasures; // Οι θησαυροί.
    
    private TreasuresAndEnemies treasuresAndEnemies;

    

    void Start()
    {
        treasureTimer = treasureInterval;
        treasuresAndEnemies = transform.parent.GetComponent<TreasuresAndEnemies>();
        treasures = treasuresAndEnemies.getTreasures();
        
        
    }
    void Update()
    {
        //======================================
        if(!treasuresAndEnemies.isBobDead()){
            treasureTimer += Time.deltaTime;
            if (treasureTimer >= treasureInterval)
            {
                // Reset τον χρόνο
                treasureTimer = 0f;
                // Παύση της κίνησης των εχθρών.
                Enemies.GetComponent<EnemyHandler>().setCanMove(false);
                placeTreasuresInRandomPosition();
                // Εκκίνηση της κίνησης των εχθρών.
                Enemies.GetComponent<EnemyHandler>().setCanMove(true);
            }
        }
        //======================================
    }

    //===================================================================
    // Μέθοδος για την τοποθέτηση των θησαυρών σε τυχαίες θέσεις
    private GameObject spawnPoint;
    private bool placed;
    private void placeTreasuresInRandomPosition(){
        foreach(GameObject treasure in treasures){
            placed = false;
            while(!placed){
                treasuresAndEnemies.updateOccupiedPositions();
                spawnPoint = treasuresAndEnemies.getRandomSpawnPoint();
                // Εάν η θέση είναι ελεύθερη και ο παίκτης δεν είναι κοντά, τοποθετούμε τον θησαυρό
                if(treasuresAndEnemies.isPositionFree(spawnPoint.transform.position) && treasuresAndEnemies.isPlayerNotNear(spawnPoint.transform.position)){
                    treasure.transform.position = spawnPoint.transform.position;
                    // Ενεργοποίηση του Collider και το Renderer του θησαυρού
                    if(!treasure.GetComponent<BoxCollider>().enabled){
                        treasure.GetComponent<BoxCollider>().enabled = true;
                        treasure.GetComponent<MeshRenderer>().enabled = true;
                        treasure.transform.localScale *= 2f;
                    }
                    
                    placed = true;
                }
            }
        } 
    }
}
