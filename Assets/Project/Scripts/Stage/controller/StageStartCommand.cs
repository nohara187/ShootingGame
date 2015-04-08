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
			InitializeModel();
		}

		private void InitializeModel() {
			model.addPositionZ = 0;
			model.addRotationY = 0;
			dispatcher.Dispatch(StageEvent.PLAYER_MOVE, model);
		}
	}
}

