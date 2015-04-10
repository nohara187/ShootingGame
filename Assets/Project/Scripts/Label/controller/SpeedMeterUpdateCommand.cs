using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace nohara.samplegame
{
	public class SpeedMeterUpdateCommand : EventCommand {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		[Inject]
		public ICarModel model{get;set;}

		[Inject]
		public ILabelData label{get;set;}
		
		public override void Execute() {
			SetSpeedMeter();
			dispatcher.Dispatch(ApplicationEvent.LABEL_DISPLAY, label);
		}

		private void SetSpeedMeter() {
			label.speed = (int) (model.speed * 10);
		}
	}
}
