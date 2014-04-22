using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {
	
	
	public GUIText scoreText;
	public int Score;
	// Use this for initialization
	void Start () {
		Score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void UpdateScore(){
		scoreText.text = Score.ToString();
	}
	
	public void addScore(int newScore){
		Score += newScore;
		UpdateScore ();
	}
}
