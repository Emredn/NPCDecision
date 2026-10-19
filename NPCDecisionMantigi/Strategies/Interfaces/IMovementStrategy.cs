using NPCDecisionSystem.Domain.ValueObjects;

namespace NPCDecisionSystem.Strategies.Interfaces
{
    // Farklı hareket algoritmalarının (1x normal yürüyüş, 2x çift adım vb.) uyması gereken strateji sözleşmesi.
    public interface IMovementStrategy
    {
        // Mevcut konumdan hedef konuma doğru atılacak bir sonraki adımı hesaplar.
        Vector2Int CalculateNextPosition(Vector2Int current, Vector2Int target);
    }
}