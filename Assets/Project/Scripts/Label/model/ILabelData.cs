using System;
using UnityEngine;

namespace nohara.samplegame
{
	public interface ILabelData
	{
		DateTime startTime {get; set;}
		int speed {get; set;}
		int checkPoint {get; set;}
	}
}