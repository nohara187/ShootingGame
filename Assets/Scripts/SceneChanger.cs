using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour 
{
	public string nextSceneName;

	public void Update() 
	{
		if (Input.GetButtonDown("Submit")) {
			Application.LoadLevel(nextSceneName);
		}
	}
}
