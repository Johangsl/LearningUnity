using UnityEngine;
using System.Collections;

public class EnemyMine : MonoBehaviour {

	private bool hasSpawn;
	private HealthScript healthScript;
	private PlayerHealth pHP;
	
	private Animator animator;

	public float distanceFromPlayer;
	private Vector2 distancePlayer;
	private Vector2 distanceMine;
	private CircleCollider2D circuleCollider;
	private float curCircileCollider;
	private float circuleColliderBlow;

	private GameDirector gameDirector;

	private

	void Awake()
	{
		healthScript = GetComponent<HealthScript>();
		animator = GetComponent<Animator>();
		pHP = GetComponent<PlayerHealth> ();

		GameObject gameDirectorObject = GameObject.FindWithTag ("GameController");

		if (gameDirectorObject != null) 
		{
			gameDirector = gameDirectorObject.GetComponent<GameDirector>();
		}
		else 
		{
			Debug.Log("Cannot find 'Game Director Script' ");
		}

		gameDirector = GetComponent<GameDirector> ();

		circuleCollider = gameObject.collider2D as CircleCollider2D;
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		DisableEnemy();
	}
	
	private void DisableEnemy()
	{
		collider2D.enabled = false;
		
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			// 4 - Out of the camera ? Destroy the game object.
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}

		if(GameObject.Find("Player") != null)
		{
			distanceMine = transform.position;
			distancePlayer =  GameObject.FindGameObjectWithTag("Player").transform.position;

			distanceFromPlayer = Vector2.Distance(distanceMine, distancePlayer);
		}



		//blow mine up when player is near
		if (distanceFromPlayer < 2) 
		{
			curCircileCollider = circuleCollider.radius;
			circuleColliderBlow = curCircileCollider+0.5f;

			//circuleCollider.radius = circuleColliderBlow;
		}

		//kill Mine
		if (healthScript.hp <= 0)
		{
			gameDirector.addScore(5);
			DisableEnemy();
			animator.SetBool("Death", true);

			//Object is dead
			Destroy(gameObject, 0.3f);


		}
	}

	private void OnTriggerEnter2D(Collider2D otherCollider){
		Debug.Log ("you just hit me");
		string player;
		player = otherCollider.name;

		if (player == "Player") 
		{
			otherCollider.GetComponent<PlayerHealth> ().playerDamage (5);
		}

	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		collider2D.enabled = true;
	}
}
