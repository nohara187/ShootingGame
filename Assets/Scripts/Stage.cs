using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour 
{
	private static Stage _instantce;

	public int stage 
	{
		get;
		private set;
	}

	public static Stage instance 
	{
		get {
			if(_instantce == null) {
				_instantce = FindObjectOfType<Stage>();
			}
			return _instantce;
		}
	}
	
	public void Start() 
	{
		if (this != instance) {
			Destroy(this);
		}
	}
	
	public void Add() 
	{
		stage += 1;
	}
	
	public void Reset() 
	{
		stage = 0;
	}
}