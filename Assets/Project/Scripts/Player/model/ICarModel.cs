using System;
using UnityEngine;

namespace nohara.samplegame
{
	public interface ICarModel
	{
		float speed {get; set;}
		float direction {get; set;}
	}
}