using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;
using NPCDecisionSystem.Domain.ValueObjects;
using NPCDecisionSystem.Simulation;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.BehaviorTree.Actions
{
    // NPC acıktığında haritadaki yemek kaynağına doğru yürümesini ve yemeği yemesini sağlayan eylem düğümü.
    public class SearchFoodAction : BTNode
    {
        private readonly IMovementStrategyFactory _strategyFactory;
        private readonly IWorldService _worldService;

        // Hareket fabrikasını ve yeni yemek konumu üretecek dünya servisini Dependency Injection ile alır.
        public SearchFoodAction(IMovementStrategyFactory strategyFactory, IWorldService worldService)
        {
            _strategyFactory = strategyFactory;
            _worldService = worldService;
        }

        // NPC'yi yemek konumuna ilerletir; hedefe ulaştığında açlığı sıfırlayıp haritada yeni bir yemek oluşturur.
        public override NodeState Evaluate(NPCContext context)
        {
            int dx = context.FoodSourcePosition.X - context.Position.X;
            int dy = context.FoodSourcePosition.Y - context.Position.Y;

            if (dx != 0 || dy != 0)
            {
                context.MovementStrategy = _strategyFactory.GetNormalStrategy();
                Vector2Int nextPos = context.MovementStrategy.CalculateNextPosition(context.Position, context.FoodSourcePosition);

                context.Position = nextPos;
                context.LastActionMessage = "Çevrede yemek arıyor ve yemeğe doğru yürüyor...";
            }

            if (context.Position.X == context.FoodSourcePosition.X && context.Position.Y == context.FoodSourcePosition.Y)
            {
                context.HungerLevel = 10;
                context.LastActionMessage = "DOYDUM! Karnı doydu, huzura erdi.";
                context.FoodSourcePosition = _worldService.GetRandomSafePosition(context.Position);
            }

            return NodeState.Running;
        }
    }
}