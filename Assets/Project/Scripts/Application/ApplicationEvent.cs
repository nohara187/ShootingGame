using UnityEngine;
using System.Collections;

namespace nohara.samplegame
{
	public class ApplicationEvent {
		public const string REQUEST_PLAYER_MOVE = "REQUEST_PLAYER_MOVE";
		public const string REQUEST_LABEL_INIT = "REQUEST_LABEL_INIT";
		public const string REQUEST_UPDATE_SPEED = "REQUEST_UPDATE_SPEED";
		public const string REQUEST_UPDATE_TIMER = "REQUEST_UPDATE_TIMER";
		public const string REQUEST_UPDATE_POINT = "REQUEST_UPDATE_POINT";

		public const string PLAYER_MOVE = "PLAYER_MOVE";
		public const string LABEL_DISPLAY = "LABEL_DISPLAY";
	}
}
