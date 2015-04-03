using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour 
{

	private Text scoreLabel;
	
	public void Start()
	{
		scoreLabel = GetComponent<Text>();
	}

	public void Update()
	{
		int score = Score.instance.score;
		string scorePadZero = score.ToString("000000");
		scoreLabel.text = "Score:" + scorePadZero;
	}
}
