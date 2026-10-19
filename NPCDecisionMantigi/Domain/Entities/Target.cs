using NPCDecisionSystem.Domain.Enums;
using NPCDecisionSystem.Domain.ValueObjects;

namespace NPCDecisionSystem.Domain.Entities
{
    // NPC'nin görüş açısına giren varlıkların (düşman, dost vb.) kimlik ve konum bilgilerini tutan sınıf.
    public class Target
    {
        public string Name { get; set; }
        public TargetType Type { get; set; }
        public Vector2Int Position { get; set; }

        public Target(string name, TargetType type, Vector2Int position)
        {
            Name = name;
            Type = type;
            Position = position;
        }
    }
}