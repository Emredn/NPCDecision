using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Core
{
    // Davranış ağacındaki tüm düğümlerin (Selector, Sequence, Condition, Action) miras aldığı soyut temel sınıf.
    public abstract class BTNode
    {
        // Düğümün mantığını çalıştırır ve sonucunu (Running, Success, Failure) döner.
        public abstract NodeState Evaluate(NPCContext context);
    }
}