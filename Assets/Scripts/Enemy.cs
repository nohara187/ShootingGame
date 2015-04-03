using UnityEngine;
using System.Collections;

public class Enemy : Spaceship 
{
	public int score;

	public IEnumerator Start() 
	{

		Move(transform.up * -1);

		while (true) {
			for(int i=0; i < transform.childCount; i++) 
			{
				Transform shotPosition = transform.GetChild(i);
				Shot(shotPosition);
			}

			float wait = shotDelay / Stage.instance.stage;
			yield return new WaitForSeconds(wait);
		}
	}

	public void Move(Vector2 direction) 
	{
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	public void OnTriggerEnter2D(Collider2D c) 
	{
		
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		if (layerName == "Bullet(Player)") 
		{
			Destroy(c.gameObject);
			Destroy(gameObject);
			Exprose();
			EnemyManager.instance.Add();
			Score.instance.Add(score * Stage.instance.stage);
		}
	}
}
