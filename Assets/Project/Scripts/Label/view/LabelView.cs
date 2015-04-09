using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class LabelView : View {
		
		[Inject]
		public IEventDispatcher dispatcher{get;set;}
		
		internal void init() {
		}
		
		private void UpdateTimer() {
			dispatcher.Dispatch(ApplicationEvent.REQUEST_LABEL_UPDATE_TIMER);
		}
		
		internal void DisplayLabels(ILabelData data) {
			DisplaySpeedMeter(data);
			DisplayTimer(data);
			DisplayCheckPoint(data);
		}

		private void DisplaySpeedMeter(ILabelData data) {
			Text speedMeter = GameObject.FindGameObjectWithTag("SpeedMeter").GetComponent<Text>();
			int speed = data.speed;
			if (speed < 0) speed = speed * -1;
			speedMeter.text = "SPEED : " + System.String.Format("{0:000}", speed ) + "km";
		}

		private void DisplayTimer(ILabelData data) {
			System.DateTime now = System.DateTime.Now;
			System.TimeSpan deltaTime = now - data.startTime;
			string hh = deltaTime.Hours.ToString("D2");
			string mm = deltaTime.Minutes.ToString("D2");
			string ss = deltaTime.Seconds.ToString("D2");

			Text timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
			timer.text = "TIME : " + hh + " : " + mm + " : " + ss;
		}

		private void DisplayCheckPoint(ILabelData data) {
			Text checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Text>();
			checkPoint.text = "残り : " + System.String.Format("{0:D2}", data.checkPoint);
		}

	}
}