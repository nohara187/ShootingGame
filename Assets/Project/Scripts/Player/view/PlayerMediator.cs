using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class PlayerMediator : EventMediator {
		
		[Inject]
		public PlayerView view{ get; set; }

		public override void OnRegister() {
			view.dispatcher.AddListener(ApplicationEvent.REQUEST_PLAYER_MOVE, OnRequestMove);
			view.dispatcher.AddListener(ApplicationEvent.REQUEST_UPDATE_POINT, OnRequestUpdatePoint);
			dispatcher.AddListener(ApplicationEvent.PLAYER_MOVE, OnPlayerMove);
			view.init();
		}

		public override void OnRemove()
		{
		}

		private void OnRequestMove(IEvent evt)
		{
			dispatcher.Dispatch(ApplicationEvent.REQUEST_PLAYER_MOVE, evt.data);
			dispatcher.Dispatch(ApplicationEvent.REQUEST_UPDATE_SPEED);
		}

		private void OnRequestUpdatePoint(IEvent evt)
		{
			dispatcher.Dispatch(ApplicationEvent.REQUEST_UPDATE_POINT);
		}

		private void OnPlayerMove(IEvent evt)
		{
			ICarModel model = (ICarModel)evt.data;
			view.UpdatePlayerPosition(model);
		}
	}
}

