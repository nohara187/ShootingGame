using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class LabelMediator : EventMediator {
		
		[Inject]
		public LabelView view{ get; set; }

		public override void OnRegister() {
			view.dispatcher.AddListener(ApplicationEvent.REQUEST_LABEL_INIT, OnUpdateLabelData);
			dispatcher.AddListener(ApplicationEvent.LABEL_DISPLAY, OnDisplayLabel);	
			view.init();
		}

		public override void OnRemove()
		{
		}

		private void OnUpdateLabelData()
		{
			dispatcher.Dispatch(ApplicationEvent.REQUEST_LABEL_INIT);
		}

		private void OnDisplayLabel(IEvent evt)
		{
			ILabelData labelData = (ILabelData)evt.data;
			view.DisplayLabels(labelData);
		}
	}
}