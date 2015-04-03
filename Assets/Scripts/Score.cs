using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	private static Score _instantce;

	public int score 
	{
		get;
		private set;
	}

	public static Score instance 
	{
		get {
			if(_instantce == null) {
				_instantce = FindObjectOfType<Score>();
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

	public void Add(int _score)
	{
		score += _score;
	}

	public void Reset()
	{
		score = 0;
	}
}
