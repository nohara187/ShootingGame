using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour 
{
	public float speed;
	public float shotDelay;
	public GameObject bullet;
	public GameObject explosion;

	public void Shot(Transform origin) 
	{
		Instantiate(bullet, origin.position, origin.rotation);
	}
	
	public void Exprose() 
	{
		Instantiate(explosion, transform.position, transform.rotation);
	}
}