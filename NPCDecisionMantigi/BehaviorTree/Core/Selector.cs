using System.Collections.Generic;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Domain.Enums;

namespace NPCDecisionSystem.BehaviorTree.Core
{
    // Alt düğümlerini sırayla deneyen ve içlerinden biri başarılı (Success) veya çalışıyor (Running) 
    // döndüğünde duran kompozit düğüm (VEYA / OR mantığı).
    public class Selector : BTNode
    {
        protected List<BTNode> children = new List<BTNode>();

        // Seçici düğümün altına yeni bir dal (koşul, dizi veya eylem) ekler.
        public void AddChild(BTNode child) => children.Add(child);

        // Alt düğümleri öncelik sırasına göre çalıştırır; ilk geçerli dalda karar kılıp diğerlerini atlar.
        public override NodeState Evaluate(NPCContext context)
        {
            foreach (var child in children)
            {
                switch (child.Evaluate(context))
                {
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Success:
                        return NodeState.Success;
                    case NodeState.Failure:
                        continue;
                }
            }
            return NodeState.Failure;
        }
    }
}