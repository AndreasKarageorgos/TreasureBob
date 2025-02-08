using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{

    private GameObject[] enemies; // Πίνακας με όλους τους εχθρούς
    private float enemyInterval;
    private float enemyTimer; // Χρονομετρητής για τον υπολογισμό του χρόνου που έχει περάσει
    private bool canMove; // Έλεγχος αν μπορούν να τοποθετηθούν οι εχθροί
    private TreasuresAndEnemies treasuresAndEnemies; // Αντικείμενο γονέας
    void Start()
    {
        // Αρχικοποίηση πεδίων
        treasuresAndEnemies = transform.parent.GetComponent<TreasuresAndEnemies>();
        enemyInterval = (float) Random.Range(0,11);
        enemyTimer = enemyInterval;
        enemies = treasuresAndEnemies.getEnemies();
        canMove = false;
    }

    private int enemyPosition;
    private bool placed;
    private GameObject spawnPoint;
    void Update()
    {
        if(!treasuresAndEnemies.isBobDead()){ // Όσο ο bob είναι ζωντανός το παιχνίδι συνεχίζει.
            placed = false;
            enemyTimer += Time.deltaTime;
            if(enemyTimer>=enemyInterval && canMove){
                // Εύρεση τυχαίου εχθρού
                enemyPosition = Random.Range(0,enemies.Length);
                // Επαναλαμβάνουμε μέχρι να βρούμε μια ελεύθερη θέση
                while(!placed){
                    // Ενημέρωση των κατειλημμένων θέσεων
                    treasuresAndEnemies.updateOccupiedPositions();
                    // Εύρεση τυχαίας θέσης για να μπεί ο εχθρός
                    spawnPoint = treasuresAndEnemies.getRandomSpawnPoint();
                    // Αν η θέση είναι ελεύθερη και ο παίκτης δεν είναι κοντά
                    if(treasuresAndEnemies.isPositionFree(spawnPoint.transform.position) && treasuresAndEnemies.isPlayerNotNear(spawnPoint.transform.position)){
                        // Τοποθέτηση του εχθρού στη νέα θέση
                        enemies[enemyPosition].transform.position = spawnPoint.transform.position;
                        placed = true;
                        enemyTimer = 0f;
                        // Εύρεση τυχαίας χρονικής στσιγμής για τη νέα επανατοποθέτηση
                        enemyInterval = (float) Random.Range(0,11);
                    }
                }
            }
        }
    }
    // Setter
    public void setCanMove(bool canMove){this.canMove = canMove;}
    

}
