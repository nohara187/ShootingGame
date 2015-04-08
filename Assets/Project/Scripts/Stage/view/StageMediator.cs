using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class StageMediator : EventMediator {
		
		[Inject]
		public StageView view{ get; set; }

		// イベントの登録
		public override void OnRegister() {
			UnityEngine.Debug.Log("call StageMediator.OnRegister()");

			// Mediator -> command
			view.dispatcher.AddListener(StageEvent.REQUEST_PLAYER_MOVE, onRequestMove);

			// Mediator -> View
			dispatcher.AddListener(StageEvent.PLAYER_MOVE, onPlayerMove);

			view.init();
		}
		
		// 登録したイベントの削除
		public override void OnRemove()
		{
			UnityEngine.Debug.Log("call StageMediator.OnRemove()");
		}

		// Mediator -> Command
		private void onRequestMove(IEvent evt)
		{
			UnityEngine.Debug.Log("call StageMediator.onRequestMove()");
			dispatcher.Dispatch(StageEvent.REQUEST_PLAYER_MOVE, evt.data);
		}

		// Mediator -> View
		private void onPlayerMove(IEvent evt)
		{
			UnityEngine.Debug.Log("call StageMediator.onPlayerMove()");
			ICarModel model = (ICarModel)evt.data;
			view.updatePlayerPosition(model);
		}
	}
}

