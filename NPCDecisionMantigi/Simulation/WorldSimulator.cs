using System;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;
using NPCDecisionSystem.Domain.ValueObjects;

namespace NPCDecisionSystem.Simulation
{
    // Oyun dünyasındaki zaman akışını, açlık artışını ve rastgele düşman doğma/kaçma olaylarını yöneten servis.
    public class WorldSimulator : IWorldService
    {
        private readonly Random _rng = new Random();

        // Verilen konumun haricinde rastgele güvenli bir 2D koordinat üretir.
        public Vector2Int GetRandomSafePosition(Vector2Int npcPosition)
        {
            Vector2Int newPos;
            do
            {
                newPos = new Vector2Int(_rng.Next(0, 10), _rng.Next(0, 10));
            } while (newPos.X == npcPosition.X && newPos.Y == npcPosition.Y);
            return newPos;
        }

        // Adım sayısına göre NPC'nin açlığını artırır veya rastgele düşman simülasyonunu tetikler.
        public void UpdateWorld(NPCContext context, int tickCount)
        {
            if (tickCount % 3 == 0 && context.HungerLevel < 100)
            {
                context.HungerLevel += 10;
            }

            if (tickCount % 12 == 0)
            {
                if (context.VisibleTarget == null)
                {
                    Vector2Int enemyPos = GetRandomSafePosition(context.Position);
                    string[] enemyNames = { "Ork Askeri", "Vahşi Kurt", "Yağmacı Goblin" };
                    string chosenName = enemyNames[_rng.Next(enemyNames.Length)];

                    context.VisibleTarget = new Target(chosenName, TargetType.Enemy, enemyPos);
                }
                else
                {
                    context.PlayerSkillTree.RegisterSuccessfulEscape();
                    context.VisibleTarget = null;
                }
            }
        }
    }
}