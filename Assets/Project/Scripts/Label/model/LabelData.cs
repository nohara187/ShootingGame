using UnityEngine;
using System;

namespace nohara.samplegame
{
	public class LabelData : ILabelData {
		public DateTime startTime {get; set;}
		public int speed {get; set;}
		public int checkPoint {get; set;}
	}
}