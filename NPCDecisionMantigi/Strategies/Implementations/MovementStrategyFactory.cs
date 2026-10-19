using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.Strategies.Implementations
{
    // Strateji nesnelerini bellekte tek birer kez oluşturup (önbellekleyerek) sunan fabrika sınıfı.
    public class MovementStrategyFactory : IMovementStrategyFactory
    {
        private readonly IMovementStrategy _normalStrategy = new NormalMovementStrategy();
        private readonly IMovementStrategy _doubleStepStrategy = new DoubleStepMovementStrategy();

        // Yemek arama gibi standart durumlar için normal yürüyüş stratejisini verir.
        public IMovementStrategy GetNormalStrategy() => _normalStrategy;

        // Çift adım yeteneği açıksa 2x hız stratejisini, kilitliyse normal stratejiyi verir.
        public IMovementStrategy GetFleeStrategy(bool isDoubleStepUnlocked)
        {
            return isDoubleStepUnlocked ? _doubleStepStrategy : _normalStrategy;
        }
    }
}