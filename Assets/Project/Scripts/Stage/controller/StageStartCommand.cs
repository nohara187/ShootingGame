using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.command.impl;


namespace nohara.samplegame
{
	public class StageStartCommand : EventCommand {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		[Inject]
		public ICarModel model{get;set;}

		public override void Execute() {
			UnityEngine.Debug.Log("call StageStartCommand.Execute()");
			InitializeModelData();
		}

		private void InitializeModelData() {
			model.speed = 0;
			model.direction = 4;
			dispatcher.Dispatch(StageEvent.PLAYER_MOVE, model);
		}
	}
}

