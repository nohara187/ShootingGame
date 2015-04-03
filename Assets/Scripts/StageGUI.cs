using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageGUI : MonoBehaviour 
{
	private Text stageLabel;
	
	public void Start() 
	{
		stageLabel = GetComponent<Text>();
	}
	
	public void Update() 
	{
		int stage = Stage.instance.stage;
		stageLabel.text = "Stege " + stage;
	}

	public void Reset() 
	{
		Destroy(gameObject);
	}
}
