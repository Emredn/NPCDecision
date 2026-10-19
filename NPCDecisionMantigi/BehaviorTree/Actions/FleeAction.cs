using System;
using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;
using NPCDecisionSystem.Domain.ValueObjects;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.BehaviorTree.Actions
{
    // Görüş alanında düşman olduğunda NPC'nin ters yöne doğru kaçmasını sağlayan eylem düğümü.
    public class FleeAction : BTNode
    {
        private readonly IMovementStrategyFactory _strategyFactory;

        // Hareket stratejisini (1x veya 2x hız) belirleyecek fabrikayı Dependency Injection ile alır.
        public FleeAction(IMovementStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        // Düşmanın tersi yönünde hedef koordinat hesaplar ve aktif hareket stratejisiyle NPC'yi yürütür.
        public override NodeState Evaluate(NPCContext context)
        {
            if (context.VisibleTarget != null)
            {
                int targetX = context.Position.X - Math.Sign(context.VisibleTarget.Position.X - context.Position.X);
                int targetY = context.Position.Y - Math.Sign(context.VisibleTarget.Position.Y - context.Position.Y);
                Vector2Int targetPos = new Vector2Int(targetX, targetY);

                context.MovementStrategy = _strategyFactory.GetFleeStrategy(context.PlayerSkillTree.IsDoubleStepUnlocked);

                Vector2Int nextPos = context.MovementStrategy.CalculateNextPosition(context.Position, targetPos);

                nextPos.X = Math.Clamp(nextPos.X, 0, 9);
                nextPos.Y = Math.Clamp(nextPos.Y, 0, 9);
                context.Position = nextPos;

                string speedType = context.PlayerSkillTree.IsDoubleStepUnlocked ? " [ÇİFT ADIM YETENEĞİ AKTİF]" : "";
                context.LastActionMessage = $"TEHLİKE! {context.VisibleTarget.Name} yüzünden kaçıyor!{speedType}";
            }
            return NodeState.Running;
        }
    }
}