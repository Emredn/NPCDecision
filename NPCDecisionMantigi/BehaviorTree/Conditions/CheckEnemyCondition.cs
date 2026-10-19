using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Conditions
{
    // NPC'nin görüş alanında aktif bir düşman olup olmadığını kontrol eden koşul düğümü.
    public class CheckEnemyCondition : BTNode
    {
        // Düşman görünüyorsa Success (Kaçma eylemine geç), görünmüyorsa Failure döner.
        public override NodeState Evaluate(NPCContext context)
        {
            return context.IsEnemyVisible ? NodeState.Success : NodeState.Failure;
        }
    }
}