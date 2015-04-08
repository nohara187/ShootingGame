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
			inputs.dispatcher.AddListener(InputDetector.MOVE, onMoveRequest);
		}

		internal void onMoveRequest(IEvent evt) {
			UnityEngine.Debug.Log("call StageView.onMoveRequest()");

			float[] addPosition = (float[])evt.data;
			dispatcher.Dispatch(StageEvent.REQUEST_PLAYER_MOVE, addPosition);
		}

		internal void updatePlayerPosition(ICarModel model) {
			UnityEngine.Debug.Log("call StageView.updatePlayerPosition()");

			GameObject player = GameObject.FindGameObjectWithTag("Player");

			player.transform.localRotation = Quaternion.Euler(0, model.addRotationY, 0);

			Vector3 addPosition = Vector3.zero;
			addPosition.z = model.addPositionZ;
			player.transform.localPosition += player.transform.localRotation * addPosition;

		}
	}
}

