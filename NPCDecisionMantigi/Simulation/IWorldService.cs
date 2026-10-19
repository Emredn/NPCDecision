using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.ValueObjects;

namespace NPCDecisionSystem.Simulation
{
    // Dünya simülasyonu işlemlerinin uyması gereken servis sözleşmesi (Dependency Inversion).
    public interface IWorldService
    {
        // NPC konumuna uzak güvenli rastgele yeni bir koordinat üretir.
        Vector2Int GetRandomSafePosition(Vector2Int npcPosition);

        // Zamanla açlığı artırır ve rastgele düşman olaylarını yönetir.
        void UpdateWorld(NPCContext context, int tickCount);
    }
}