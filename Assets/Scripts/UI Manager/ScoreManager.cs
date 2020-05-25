using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static int score; //using static here as there will always be only 1 'score' value
    Text text;

	void Start () {
        text = GetComponent<Text>();
        score = 0;
	}
	

	void Update () {
        text.text = "Player Score : " + score;
	}
}
