using System;

namespace NPCDecisionSystem.Domain.Entities
{
    // NPC'nin başarılı kaçışlarını sayan ve belirli eşikte yetenek açılmasını tetikleyen sınıf.
    public class SkillTree
    {
        public int EnemiesFledCount { get; private set; } = 0;
        public bool IsDoubleStepUnlocked => EnemiesFledCount >= 5;

        // Yetenek açıldığında dinleyicilere haber veren olay (Event).
        public event Action<string> SkillUnlocked;

        // Düşmandan başarılı kaçış sayısını artırır; sınır aşılırsa olayı tetikler.
        public void RegisterSuccessfulEscape()
        {
            EnemiesFledCount++;
            if (EnemiesFledCount == 5)
            {
                SkillUnlocked?.Invoke("Çift Adım (2x Hız)");
            }
        }
    }
}