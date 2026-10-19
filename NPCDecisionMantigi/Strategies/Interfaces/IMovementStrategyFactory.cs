namespace NPCDecisionSystem.Strategies.Interfaces
{
    // İhtiyaç duyulan hareket stratejisini sağlayan fabrika arayüzü (Dependency Inversion uyumu).
    public interface IMovementStrategyFactory
    {
        // Standart 1 birimlik yürüme stratejisini döner.
        IMovementStrategy GetNormalStrategy();

        // Yetenek durumuna göre uygun kaçış stratejisini (1x veya 2x hız) döner.
        IMovementStrategy GetFleeStrategy(bool isDoubleStepUnlocked);
    }
}