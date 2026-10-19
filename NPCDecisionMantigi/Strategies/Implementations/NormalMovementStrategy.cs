using System;
using NPCDecisionSystem.Domain.ValueObjects;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.Strategies.Implementations
{
    // NPC'nin hedefe doğru her adımda 1'er birim ilerlemesini sağlayan standart hareket stratejisi.
    public class NormalMovementStrategy : IMovementStrategy
    {
        // Mevcut koordinatları hedefe doğru X ve Y ekseninde 1 birim yaklaştırır.
        public Vector2Int CalculateNextPosition(Vector2Int current, Vector2Int target)
        {
            int stepX = current.X + Math.Sign(target.X - current.X);
            int stepY = current.Y + Math.Sign(target.Y - current.Y);
            return new Vector2Int(stepX, stepY);
        }
    }
}