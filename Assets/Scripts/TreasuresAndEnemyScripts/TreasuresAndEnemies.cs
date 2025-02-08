using System.Collections.Generic;
using UnityEngine;

public class TreasuresAndEnemies: MonoBehaviour
{
    public GameObject SpawnPoints; // Ο γονέας των spawn points
    public GameObject Treasures; // Ο γονέας των treasures
    public GameObject Enemies; // Ο γονέας των enemies
    public GameObject TreasureBob; // Ο Bobs

    private GameObject[] spawnPoints; // Πίνακας με τα spawn points
    private GameObject[] treasures; // Πίνακας με τους θησαυρούς
    private GameObject[] enemies; // Πίνακας με τους εχθρούς
    private float[,] occupiedPositions; // Οι θέσεις με τους θησαυβρούς και τους εχθρούς.

    void Start()
    {
        treasures = returnChildren(Treasures).ToArray();
        enemies = returnChildren(Enemies).ToArray();
        spawnPoints = returnChildren(SpawnPoints).ToArray();
        occupiedPositions = new float[6,2];
    }

    //===================================================================
    public void updateOccupiedPositions(){ // Ενημέρωση του πίνακα occupiedPositions
        int i,c;
        for(i=0; i<treasures.Length; i++){
            occupiedPositions[i,0] = treasures[i].transform.position.x;
            occupiedPositions[i,1] = treasures[i].transform.position.z;
        }
        for(c=0, i=treasures.Length; i<treasures.Length+enemies.Length; i++,c++){
            occupiedPositions[i,0] = enemies[c].transform.position.x;
            occupiedPositions[i,1] = enemies[c].transform.position.z;
        }
    }
    //===================================================================

    //===================================================================
    public bool isPositionFree(Vector3 position){ // Έλεγχος αν μια θέση είναι ελεύθερη
        for(int i=0; i<occupiedPositions.GetLength(0); i++){
            if(position.x==occupiedPositions[i,0] && position.z==occupiedPositions[i,1]){
                return false;
            }
        }
        return true;
    }
    //===================================================================
    //================================================
    private float bx;
    private float bz;
    private float px;
    private float pz;
    public bool isPlayerNotNear(Vector3 p){ // Έλεγχος αν ο παίκτης είναι κοντά σε μια θέση
        bx = abs(TreasureBob.transform.position.x);
        bz = abs(TreasureBob.transform.position.z);
        px = abs(p.x);
        pz = abs(p.z);
        return abs(px-bx)>=4f || abs(bz-pz)>=4f;
    }
    //================================================


     // Βοηθητική μέθοδος που επιστρέφει όλα τα παιδιά του γονέα.
    private List<GameObject> returnChildren(GameObject parent){
        List<GameObject> childObjects = new List<GameObject>();
        foreach(Transform child in parent.transform){
            childObjects.Add(child.gameObject);
        }
        return childObjects;
    }
    // Βοηθητική μέθοδο διότι υπάρχει πρόβλημα με την Math.Abs στο 'using System' με την Random
    public float abs(float number){
        return number < 0 ? -number : number;
    }
    
    public bool isBobDead(){ // Έλεγχος αν ο Bob είναι νεκρός
        return TreasureBob.GetComponent<DeathHandler>().isDead();
    }

    // Getters
    public GameObject getRandomSpawnPoint(){return spawnPoints[Random.Range(0,spawnPoints.Length)];}
    public GameObject[] getTreasures(){return treasures;}
    public GameObject[] getEnemies(){return enemies;}


}
