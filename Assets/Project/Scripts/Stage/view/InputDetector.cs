using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace nohara.samplegame
{
	public class InputDetector : EventView {

		public const string MOVE = "MOVE";

		public float speed = 2.0f;

		void Update() {

			float addPositionZ = Input.GetAxis("Vertical") * speed;

			float addRotationY = 0;
			if (Input.GetKey(KeyCode.RightArrow)) {
				addRotationY = 2;
			} else if(Input.GetKey(KeyCode.LeftArrow)) {
				addRotationY = -2;
			}

			if (addPositionZ != 0 || addRotationY != 0) {
				dispatcher.Dispatch(MOVE, new float[]{addPositionZ, addRotationY});
			}
		}
	}
}
