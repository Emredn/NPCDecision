using System;
using System.Text;
using System.Threading;
using NPCDecisionSystem.Application;
using NPCDecisionSystem.Observers.Implementations;
using NPCDecisionSystem.Presentation;
using NPCDecisionSystem.Simulation;
using NPCDecisionSystem.Strategies.Implementations;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Clear();

            // --- COMPOSITION ROOT (Bağımlılıkların Oluşturulduğu Tek Merkez) ---
            ConsoleRenderer renderer = new ConsoleRenderer();
            AudioAlertObserver audioObserver = new AudioAlertObserver();
            IWorldService worldService = new WorldSimulator();
            IMovementStrategyFactory strategyFactory = new MovementStrategyFactory();

            // Tüm servisleri NPCController'a enjekte ediyoruz (Dependency Injection)
            NPCController npc = new NPCController("Köylü Muhtar", renderer, worldService, strategyFactory);

            // Observer abonelikleri
            npc.SubscribeSkillObserver(renderer);
            npc.SubscribeSkillObserver(audioObserver);

            while (true)
            {
                npc.Tick();
                Thread.Sleep(600);
            }
        }
    }
}