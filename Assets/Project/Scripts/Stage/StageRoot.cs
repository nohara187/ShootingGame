using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace nohara.samplegame
{
	public class StageRoot : ContextView
	{
		void Awake()
		{
			//Instantiate the context, passing it this instance.
			context = new StageContext(this);
		}
	}
}
