using System;
using System.Collections.Generic;
using System.Text;

namespace NPCDecisionSystem.Observers.Interfaces
{
    // Open/Closed (OCP) ve Dependency Inversion (DIP) için soyut arayüzümüz.
    // Yetenek açıldığında haberdar olmak isteyen her sınıf bu arayüzü uygular.

    // Yetenek ağacında yeni bir yetenek açıldığında bildirim almak isteyen sınıfların uyguladığı arayüz.
    public interface ISkillObserver
    {
        void OnSkillUnlocked(string skillName);
    }
}
