using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    private int score; // Το σκορ του παίκτη

    public Text text; // Το αντικείμενο Text για την εμφάνιση του σκορ
    void Start()
    {
        score = 0;
    }

    void Update(){
        text.text = "Score: " + score; // Ενημέρωση του κειμένου του Text με το τρέχον σκορ
    }
    // Getter για το σκορ
    public int getScore() { return score; }
    // Setter για το σκορ
    public void setScore(int score) { this.score = score; }
}
