using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class PlayerView : View {

		[Inject]
		public IEventDispatcher dispatcher{get;set;}

		internal void init() {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			InputDetector inputs = player.GetComponent<InputDetector>() as InputDetector;
			inputs.dispatcher.AddListener(InputDetector.MOVE, OnMoveRequest);
			inputs.dispatcher.AddListener(ApplicationEvent.REQUEST_LABEL_UPDATE_POINT, OnUpdatePointRequest);
		}

		internal void OnMoveRequest(IEvent evt) {
			float[] addPosition = (float[])evt.data;
			dispatcher.Dispatch(ApplicationEvent.REQUEST_PLAYER_MOVE, addPosition);
		}

		internal void OnUpdatePointRequest(IEvent evt) {
			UnityEngine.Debug.Log("call PlayerView.OnUpdatePointRequest()");
			dispatcher.Dispatch(ApplicationEvent.REQUEST_LABEL_UPDATE_POINT);
		}

		internal void UpdatePlayerPosition(ICarModel model) {

			GameObject player = GameObject.FindGameObjectWithTag("Player");

			player.transform.localRotation = Quaternion.Euler(0, model.direction, 0);

			Vector3 addPosition = Vector3.zero;
			addPosition.z = model.speed;
			player.transform.localPosition += player.transform.localRotation * addPosition;
		}
	}
}

