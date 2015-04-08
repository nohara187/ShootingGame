using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class StageView : View {

		[Inject]
		public IEventDispatcher dispatcher{get;set;}
	
		internal void init() {
			UnityEngine.Debug.Log("call StageView.init()");

			GameObject player = GameObject.FindGameObjectWithTag("Player");
			
			InputDetector inputs = player.GetComponent<InputDetector>() as InputDetector;
			inputs.dispatcher.AddListener(InputDetector.MOVE, OnMoveRequest);
		}

		internal void OnMoveRequest(IEvent evt) {
			UnityEngine.Debug.Log("call StageView.OnMoveRequest()");

			float[] addPosition = (float[])evt.data;
			dispatcher.Dispatch(StageEvent.REQUEST_PLAYER_MOVE, addPosition);
		}

		internal void UpdatePlayerPosition(ICarModel model) {
			UnityEngine.Debug.Log("call StageView.UpdatePlayerPosition()");

			GameObject player = GameObject.FindGameObjectWithTag("Player");

			player.transform.localRotation = Quaternion.Euler(0, model.direction, 0);

			Vector3 addPosition = Vector3.zero;
			addPosition.z = model.speed;
			player.transform.localPosition += player.transform.localRotation * addPosition;

		}
	}
}

