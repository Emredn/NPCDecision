using System.Collections.Generic;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Core
{
    // Alt düğümlerinin tamamını sırayla çalıştıran, biri bile başarısız (Failure) olursa 
    // anında durup Failure dönen kompozit düğüm (VE / AND mantığı).
    public class Sequence : BTNode
    {
        protected List<BTNode> children = new List<BTNode>();

        // Sıralı diziye yeni bir adım (koşul veya eylem) ekler.
        public void AddChild(BTNode child) => children.Add(child);

        // Tüm alt adımları sırasıyla değerlendirir; koşullar sağlandığı sürece zinciri devam ettirir.
        public override NodeState Evaluate(NPCContext context)
        {
            foreach (var child in children)
            {
                switch (child.Evaluate(context))
                {
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Failure:
                        return NodeState.Failure;
                    case NodeState.Success:
                        continue;
                }
            }
            return NodeState.Success;
        }
    }
}