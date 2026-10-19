namespace NPCDecisionSystem.Domain.ValueObjects
{
    // 2D harita üzerindeki tam sayı koordinatlarını (X ve Y) tutan yapı.
    public struct Vector2Int
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}