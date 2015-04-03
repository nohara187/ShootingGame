using UnityEngine;
using System.Collections;

public class Player : Spaceship 
{

	public IEnumerator Start () 
	{
		while (true) {
			if (transform.position.y >= -2.0f) {
				yield break;
			}
			Move(transform.up);
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void Update () 
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector2 direction = new Vector2 (x, y).normalized;
		Move (direction);

		if (Input.GetButtonDown("Submit")) {
			Shot (transform);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}
	}

	public void Move(Vector2 direction) 
	{

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		transform.position = pos;
	}

	public void OnTriggerEnter2D(Collider2D c) 
	{

		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		if (layerName == "Bullet(Enemy)") {
			Destroy(c.gameObject);
		}

		if(layerName == "Bullet(Enemy)" || layerName == "Enemy") {
			Exprose();
			Destroy(gameObject);
			Destroy(EnemyManager.instance.gameObject);
			Application.LoadLevelAdditive("GameOver");
		}
	}
}
