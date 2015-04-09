using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace nohara.samplegame
{
	public class CheckPointUpdateCommand : EventCommand {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		[Inject]
		public ILabelData label{get;set;}
		
		public override void Execute() {
			SetCheckPoint();
			dispatcher.Dispatch(ApplicationEvent.LABEL_DISPLAY, label);
		}
		
		private void SetCheckPoint() {
			label.checkPoint -= 1;
		}
	}
}

