using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Player != null)
		{
			transform.LookAt(Player);
		}
	}
}
