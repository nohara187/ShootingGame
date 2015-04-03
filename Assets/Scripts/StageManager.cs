using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageManager : MonoBehaviour 
{
	public GameObject stage;
	public GameObject stageLabel;
	public GameObject score;
	public GameObject scoreLabel;
	public GameObject player;
	public GameObject enemyManager;

	private bool isStart = false;
	private GameObject playerClone;
	private GameObject labelClone;

	public void Start() 
	{
		Instantiate(score, transform.position, transform.rotation);
		Instantiate(stage, transform.position, transform.rotation);
		Stage.instance.Add();
		StageInit();
	}

	public void Update() 
	{
		if (!isStart) {
			if (playerClone.transform.position.y >= -2.0f) {
				StageStart();
				isStart = true;
			}
		} else {

			if (playerClone == null) return;

			int clearCnt = Stage.instance.stage * 3;
			if (EnemyManager.instance.deadCnt >= clearCnt) {
				StageReset();
				Stage.instance.Add();
				StageInit();
			}
		}
	}

	private void StageInit() 
	{
		Instantiate(scoreLabel, transform.position, transform.rotation);

		playerClone = (GameObject)Instantiate(player, 
		             player.gameObject.transform.position, 
		             player.gameObject.transform.rotation);

		labelClone = (GameObject)Instantiate(stageLabel, 
		             stageLabel.gameObject.transform.position, 
		             stageLabel.gameObject.transform.rotation);
	}

	private void StageStart() 
	{
		isStart = true;
		Destroy(labelClone);
		Instantiate(enemyManager, 
		            enemyManager.gameObject.transform.position,
		            enemyManager.gameObject.transform.rotation);
		EnemyManager.instance.isStart = true;
	}

	private void StageReset() 
	{
		isStart = false;
		Destroy(playerClone);
		EnemyManager.instance.Reset();
	}
}
