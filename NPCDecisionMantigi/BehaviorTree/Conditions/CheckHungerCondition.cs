using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Conditions
{
    // NPC'nin açlık seviyesinin kritik eşiğe (70 ve üzeri) ulaşıp ulaşmadığını kontrol eden koşul düğümü.
    public class CheckHungerCondition : BTNode
    {
        // Açlık 70 veya üzerindeyse Success (Yemek arama eylemine geç), değilse Failure döner.
        public override NodeState Evaluate(NPCContext context)
        {
            return context.HungerLevel >= 70 ? NodeState.Success : NodeState.Failure;
        }
    }
}