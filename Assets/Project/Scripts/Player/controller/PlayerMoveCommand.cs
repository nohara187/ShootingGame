using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace nohara.samplegame
{
	public class PlayerMoveCommand : EventCommand {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		[Inject]
		public ICarModel model{get;set;}
		
		public override void Execute() {
			SetModelData();
		}
		
		private void SetModelData() {
			float[] addMove = (float[])evt.data;
			model.speed += addMove[0];
			model.direction += addMove[1];
			dispatcher.Dispatch(ApplicationEvent.PLAYER_MOVE, model);
		}
	}
}
