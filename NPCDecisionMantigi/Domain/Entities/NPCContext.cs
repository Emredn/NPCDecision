using System;
using NPCDecisionSystem.Domain.Enums;
using NPCDecisionSystem.Domain.ValueObjects;
using NPCDecisionSystem.Strategies.Implementations;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.Domain.Entities
{
    // NPC'nin açlık, konum, yetenek ve strateji gibi tüm anlık verilerini saklayan hafıza (Context) sınıfı.
    public class NPCContext
    {
        private int _hungerLevel = 20;
        public int HungerLevel
        {
            get => _hungerLevel;
            set
            {
                WasHungryBefore = _hungerLevel >= 70;
                _hungerLevel = Math.Clamp(value, 0, 100);
            }
        }

        public bool WasHungryBefore { get; private set; } = false;
        public Target VisibleTarget { get; set; } = null;
        public string Name { get; set; }

        public SkillTree PlayerSkillTree { get; set; } = new SkillTree();
        public IMovementStrategy MovementStrategy { get; set; } = new NormalMovementStrategy();

        public Vector2Int Position { get; set; } = new Vector2Int(5, 5);
        public Vector2Int FoodSourcePosition { get; set; } = new Vector2Int(1, 1);
        public string LastActionMessage { get; set; } = "Sakin bir şekilde etrafta geziniyor.";

        public NPCContext(string name) => Name = name;

        public bool IsEnemyVisible => VisibleTarget != null && VisibleTarget.Type == TargetType.Enemy;
    }
}