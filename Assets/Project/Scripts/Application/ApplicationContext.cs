using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace nohara.samplegame
{
	public class ApplicationContext : MVCSContext
	{
		public ApplicationContext (MonoBehaviour view) : base(view)
		{
		}
		
		public ApplicationContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
		{
		}
		
		protected override void mapBindings()
		{
			// ModelInterface -> ModelImpl
			injectionBinder.Bind<ICarModel>().To<CarModel>().ToSingleton();
			injectionBinder.Bind<ILabelData>().To<LabelData>().ToSingleton();

			// View -> Mediator
			mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
			mediationBinder.Bind<LabelView>().To<LabelMediator>();

			// Mediator -> Command
			commandBinder.Bind(ApplicationEvent.REQUEST_PLAYER_MOVE).To<PlayerMoveCommand>();
			commandBinder.Bind(ApplicationEvent.REQUEST_UPDATE_SPEED).To<SpeedMeterUpdateCommand>();
			commandBinder.Bind(ApplicationEvent.REQUEST_UPDATE_TIMER).To<TimerUpdateCommand>();
			commandBinder.Bind(ApplicationEvent.REQUEST_UPDATE_POINT).To<CheckPointUpdateCommand>();
			commandBinder.Bind(ContextEvent.START).To<ApplicationStartCommand>().Once ();
		}
	}
}