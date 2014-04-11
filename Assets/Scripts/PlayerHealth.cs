using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int playerHP = 5;
	private Animator animator;
	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

	public void playerDamage(int dmg){
		playerHP -= dmg;

		if (playerHP <= 0)
		{
			animator.SetBool("Death", true);
			Destroy(gameObject, 0.2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
