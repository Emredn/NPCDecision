namespace NPCDecisionSystem.Domain.Enums
{
    // Davranış ağacı (Behavior Tree) düğümlerinin her turdaki çalışma sonuç durumları.
    public enum NodeState
    {
        Running,
        Success,
        Failure
    }
}