using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.command.impl;


namespace nohara.samplegame
{
	public class ApplicationStartCommand : EventCommand {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		[Inject]
		public ICarModel model{get;set;}

		[Inject]
		public ILabelData label{get;set;}

		public override void Execute() {
			UnityEngine.Debug.Log("call ApplilcationStartCommand.Execute()");
			InitializeModelData();
			InitializeLabelData();
		}

		private void InitializeModelData() {
			model.speed = 0;
			model.direction = 4;
			dispatcher.Dispatch(ApplicationEvent.PLAYER_MOVE, model);
		}

		private void InitializeLabelData() {
			label.startTime = System.DateTime.Now;
			label.speed = 0;
			label.checkPoint = 10;
			dispatcher.Dispatch(ApplicationEvent.LABEL_DISPLAY, label);
		}
	}
}

