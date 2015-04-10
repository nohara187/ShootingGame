using UnityEngine;
using System.Collections;

public class SceneChenge : MonoBehaviour {

	public string nextSceneName;

	void Update () {
		if(Input.GetButtonDown("Submit")) {
			Application.LoadLevel(nextSceneName);
		}
	}
}
