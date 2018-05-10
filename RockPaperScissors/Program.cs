using Autofac;
using RockPaperScissors.Business;
using RockPaperScissors.Business.DataProvider;

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
            
            return builder.Build();
        }
    }
}
