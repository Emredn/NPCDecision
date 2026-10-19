using System;
using NPCDecisionSystem.Domain.ValueObjects;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.Strategies.Implementations
{
    // Yetenek ağacından "Çift Adım" açıldığında NPC'nin 2'şer birim atlayarak kaçmasını sağlayan strateji.
    public class DoubleStepMovementStrategy : IMovementStrategy
    {
        // Mevcut koordinatları hedefe doğru X ve Y ekseninde 2 birim birden yaklaştırır.
        public Vector2Int CalculateNextPosition(Vector2Int current, Vector2Int target)
        {
            int stepX = current.X + (Math.Sign(target.X - current.X) * 2);
            int stepY = current.Y + (Math.Sign(target.Y - current.Y) * 2);
            return new Vector2Int(stepX, stepY);
        }
    }
}