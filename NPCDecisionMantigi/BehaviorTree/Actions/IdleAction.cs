using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Actions
{
    // Etrafta tehlike yoksa ve NPC tok ise çalışan varsayılan (en düşük öncelikli) bekleme eylemi.
    public class IdleAction : BTNode
    {
        // NPC'nin durum mesajını günceller ve eylemin devam ettiğini (Running) döner.
        public override NodeState Evaluate(NPCContext context)
        {
            context.LastActionMessage = "Sakin bir şekilde etrafta geziniyor.";
            return NodeState.Running;
        }
    }
}