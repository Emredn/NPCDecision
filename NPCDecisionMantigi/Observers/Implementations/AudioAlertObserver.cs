using System;
using System.Collections.Generic;
using System.Text;
using NPCDecisionSystem.Observers.Interfaces;

namespace NPCDecisionSystem.Observers.Implementations
{
    // Single Responsibility (SRP): Sadece ses çalmaktan sorumlu gözlemci sınıf.
    // Yeni bir yetenek açıldığında konsol üzerinden sesli uyarı veren gözlemci sınıf (Single Responsibility).
    public class AudioAlertObserver : ISkillObserver
    {
        public void OnSkillUnlocked(string skillName)
        {
            Console.Beep();
        }
    }
}
