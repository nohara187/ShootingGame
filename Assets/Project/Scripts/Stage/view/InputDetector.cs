using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class InputDetector : EventView {

		public const string MOVE = "MOVE";

		public float addSpeed = 0.01f;

		void Update() {

			float speed = 0;
			float direction = 0;

			if (Input.GetKey(KeyCode.RightArrow)) {
				direction = 2;
			} else if(Input.GetKey(KeyCode.LeftArrow)) {
				direction = -2;
			} else if(Input.GetKey(KeyCode.UpArrow)) {
				speed = addSpeed;
			} else if(Input.GetKey(KeyCode.DownArrow)) {
				speed = -addSpeed;
			}

			dispatcher.Dispatch(MOVE, new float[]{speed, direction});
		}
	}
}
