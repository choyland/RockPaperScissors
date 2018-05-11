using System;
using Autofac;
using RockPaperScissors.Business;
using RockPaperScissors.Business.DataProvider;
using RockPaperScissors.Business.Model.Implementation;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildDiContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGame>();
                game.StartGame();
            }
        }

        private static IContainer BuildDiContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Game>().As<IGame>();
            builder.RegisterType<OverallScoreCalculator>().As<IOverallScoreCalculator>();
            builder.RegisterType<ResultCalculator>().As<IResultCalculator>();
            builder.RegisterType<GameMoveOutcomeDataProvider>().As<IGameMoveOutcomeDataProvider>();
            builder.RegisterType<TacticalMoveGenerator>().As<ITacticalMoveGenerator>();
            builder.RegisterType<RandomMoveGenerator>().As<IRandomMoveGenerator>();

            // computer players with named parameters
            builder.RegisterType<RandomComputerPlayer>().As<IComputerPlayer>().Named<IComputerPlayer>("r");
            builder.RegisterType<TacticalComputerPlayer>().As<IComputerPlayer>().Named<IComputerPlayer>("t");

            builder.Register<Func<string, IComputerPlayer>>(delegate (IComponentContext context)
            {
                var cc = context.Resolve<IComponentContext>();

                return cc.ResolveNamed<IComputerPlayer>;
            });

            return builder.Build();
        }
    }
}
