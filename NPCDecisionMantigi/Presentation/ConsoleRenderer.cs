using System;
using System.Collections.Generic;
using System.Text;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Observers.Interfaces;

namespace NPCDecisionSystem.Presentation
{
    public class ConsoleRenderer : ISkillObserver
    {
        // NPC'nin anlık durumunu, yeteneklerini ve 2D haritayı konsol ekranına çizen ve gözlemci olan sınıf.
        private string _notificationBanner = "";
        private int _notificationTimer = 0;

        // ISkillObserver arayüzünden gelen metot: Yetenek açıldığında otomatik tetiklenir
        public void OnSkillUnlocked(string skillName)
        {
            _notificationBanner = $"🎉 YENİ YETENEK AÇILDI: {skillName}! 🎉";
            _notificationTimer = 8; // Ekranda 8 tick (adım) boyunca kalacak
        }

        public void Render(NPCContext context)
        {
            Console.SetCursorPosition(0, 0);

            string stateDisplay = context.IsEnemyVisible
                ? "Flee (Kaçıyor!)"
                : (context.HungerLevel >= 70 ? "Search Food (Yemek Arıyor)" : "Idle (Boşta)");

            int filledBlocks = context.HungerLevel / 10;
            string hungerBar = new string('█', filledBlocks) + new string('░', 10 - filledBlocks);
            string hungerStatus = context.HungerLevel >= 70 ? "(Aç!)" : (context.HungerLevel <= 30 ? "(Tok)" : "(Normal)");
            string enemyText = context.IsEnemyVisible ? $"{context.VisibleTarget?.Name} (GÖRÜLDÜ!)" : "Yok";

            string skillStatus = context.PlayerSkillTree.IsDoubleStepUnlocked
                ? "[AKTİF: Çift Adım Hızı (2x)]"
                : $"[Kilitli: {context.PlayerSkillTree.EnemiesFledCount}/5 Kaçış]";

            Console.WriteLine("========================================");
            Console.WriteLine($" [ NPC KİMLİK KARTI: {context.Name} ]");
            Console.WriteLine("========================================");
            Console.WriteLine($" 🟢 Aktif Durum    : {stateDisplay.PadRight(25)}");
            Console.WriteLine($" 🍗 Açlık Seviyesi : [{hungerBar}] %{context.HungerLevel} {hungerStatus.PadRight(10)}");
            Console.WriteLine($" ⚔️ Yetenek Ağacı  : {skillStatus.PadRight(30)}");
            Console.WriteLine($" ⚠️ Görüş Alanı    : {enemyText.PadRight(30)}");
            Console.WriteLine("========================================");

            // Son eylem mesajının arkasında eski uzun metin kalıntısı kalmaması için sabit boyutta boşlukla doldurulur.
            string actionText = $"[ Son Eylem: {context.LastActionMessage} ]";
            Console.WriteLine($"{actionText.PadRight(68)}");

            // Observer bildirimi geldiyse ekranda göster, süresi bitince temizle
            if (_notificationTimer > 0)
            {
                Console.WriteLine($" 🔔 BİLDİRİM: {_notificationBanner.PadRight(50)}");
                _notificationTimer--;
            }
            else
            {
                Console.WriteLine("".PadRight(68)); // Eski bildirim satırını temizler
            }

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("\n[ CANLI 2D HARİTA (10x10) ]");
            Console.WriteLine(" N: NPC | F: Yemek | X: Düşman | . : Boş ");

            int size = 10;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (context.Position.X == x && context.Position.Y == y)
                        Console.Write(" N ");
                    else if (context.VisibleTarget != null && context.VisibleTarget.Position.X == x && context.VisibleTarget.Position.Y == y)
                        Console.Write(" X ");
                    else if (context.FoodSourcePosition.X == x && context.FoodSourcePosition.Y == y)
                        Console.Write(" F ");
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n(Durdurmak için Ctrl + C tuşlarına basabilirsiniz)");
        }
    }
}
