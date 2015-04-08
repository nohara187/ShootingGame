using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace nohara.samplegame
{
	public class StageContext : MVCSContext
	{
		public StageContext (MonoBehaviour view) : base(view)
		{
		}
		
		public StageContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
		{
		}
		
		protected override void mapBindings()
		{
			// ModelInterface -> ModelImpl
			injectionBinder.Bind<ICarModel>().To<CarModel>().ToSingleton();

			// View -> Mediator
			mediationBinder.Bind<StageView>().To<StageMediator>();

			// Mediator -> Command
			commandBinder.Bind(StageEvent.REQUEST_PLAYER_MOVE).To<PlayerMoveCommand>();
			commandBinder.Bind(ContextEvent.START).To<StageStartCommand>().Once ();
		}
	}
}