using UnityEngine;
using System.Collections;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;
    private Animator animator;
	private string enemyName;
	private PlayerHealth playerHealth;

		//private Animation enemyHit;

    void Awake()
    {
        animator = GetComponent<Animator>();
		playerHealth = GetComponent<PlayerHealth>();
    }


	/// <summary>
	/// Flash enemes when hit.
	/// </summary>
	IEnumerator Flash( ShotScript shotFrom)
	{
//		if (!shotFrom.isEnemyShot) {
			gameObject.renderer.material.color = new Color (200f, 0f, 0f, 1f);
			yield return new WaitForSeconds (0.08f);
			gameObject.renderer.material.color = new Color (1f, 1f, 1f, 1f);
		//}
//		else {
//			gameObject.renderer.material.color = new Color (248f, 248f, 255f, 1f);
//			yield return new WaitForSeconds (0.08f);
//			gameObject.renderer.material.color = new Color (1f, 1f, 1f, 1f);
//		}
	}

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {

        hp -= damageCount;
        if (hp <= 0)
        {
            //SpecialEffectsHelper.Instance.Explosion(transform.position);
			//animator.SetBool("Death", true);
            SoundEffectsHelper.Instance.MakeExplosionSound();
        }
    }

	public void PlayerDamage(int DamageCount)
	{

		hp -= DamageCount;
		if (hp <= 0)
		{
			SoundEffectsHelper.Instance.MakeExplosionSound();
		}

	}


    void OnTriggerEnter2D(Collider2D otherCollider)
    {

		enemyName = otherCollider.gameObject.name;
        // Is this a shot?

		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {

                Damage(shot.damage);
				StartCoroutine (Flash (shot));

				// Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script);
			}
			else {
			}
        }

		switch (enemyName) {

		case "Mine":
				mineDamage();
			break;
		case "Player":
			PlayerDamage(1);
			break;
		default:
			break;
		}

    }

	private void mineDamage()
	{
//		if (GameObject.Find("Player")) {
//		}
	}
}