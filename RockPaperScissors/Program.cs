using System;
using Autofac;
using RockPaperScissors.Business.Calculators;
using RockPaperScissors.Business.Calculators.Interfaces;
using RockPaperScissors.Business.Data;
using RockPaperScissors.Business.Data.Interfaces;
using RockPaperScissors.Business.Model;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Business.MoveGenerators;
using RockPaperScissors.Business.MoveGenerators.Interfaces;
using RockPaperScissors.Configuration;
using RockPaperScissors.Configuration.Interfaces;
using RockPaperScissors.Game;
using RockPaperScissors.Game.Interfaces;
using RockPaperScissors.Helpers;
using RockPaperScissors.Helpers.Interfaces;
using RockPaperScissors.Wrappers;
using RockPaperScissors.Wrappers.Interfaces;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildDiContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGameRunner>();
                game.StartGame();
            }
        }

        private static IContainer BuildDiContainer()
        {
            var builder = new ContainerBuilder();

            // Main game
            builder.RegisterType<Game.GameRunner>().As<IGameRunner>();
            builder.RegisterType<Round>().As<IRound>();
            builder.RegisterType<Configuration.Configuration>().As<IConfiguration>();
            builder.RegisterType<InputOutputWrapper>().As<IInputOutputWrapper>();
            builder.RegisterType<GameMoveViewModelHelper>().As<IGameMoveViewModelHelper>();
            builder.RegisterType<ComputerPlayerViewModelHelper>().As<IComputerPlayerViewModelHelper>();

            // Business
            builder.RegisterType<OverallScoreCalculator>().As<IOverallScoreCalculator>();
            builder.RegisterType<RoundCalculator>().As<IRoundCalculator>();
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
