using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour 
{
	private static EnemyManager _instantce;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public float interval;
	public bool isStart = false;

	public int deadCnt 
	{
		get;
		private set;
	}

	public static EnemyManager instance 
	{
		get {
			if(_instantce == null) {
				_instantce = FindObjectOfType<EnemyManager>();
			}
			return _instantce;
		}
	}

	public IEnumerator Start () 
	{
		if (this != instance) {
			Destroy(this);
		}

		while (true) {

			if (!isStart) {
				yield return new WaitForSeconds(interval);
			}

			int pettern = Random.Range(1, 4);
			GameObject enemy = enemy1;
			if(pettern == 2) enemy = enemy2;
			if(pettern == 3) enemy = enemy3;

			transform.position = new Vector3(Random.Range(-3.5f, 3.6f), transform.position.y, transform.position.z);
			Instantiate (enemy, transform.position, transform.rotation);
			yield return new WaitForSeconds(interval);
		}
	}

	public void Add() 
	{
		deadCnt++;
	}

	public void Reset() 
	{
		isStart = false;

		GameObject[] clones = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in clones) {
			Destroy (enemy);
		}

		clones = GameObject.FindGameObjectsWithTag("Bullet(Enemy)");
		foreach (GameObject bullet in clones) {
			Destroy (bullet);
		}

		deadCnt = 0;
	}
}
