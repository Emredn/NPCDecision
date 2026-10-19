using NPCDecisionSystem.BehaviorTree.Actions;
using NPCDecisionSystem.BehaviorTree.Conditions;
using NPCDecisionSystem.BehaviorTree.Core;
using NPCDecisionSystem.Domain.Entities;
using NPCDecisionSystem.Observers.Interfaces;
using NPCDecisionSystem.Presentation;
using NPCDecisionSystem.Simulation;
using NPCDecisionSystem.Strategies.Interfaces;

namespace NPCDecisionSystem.Application
{
    /// NPC'nin karar ağacını (Behavior Tree), dünya simülasyonunu ve görsel sunumunu 
    /// koordine eden ana kontrolcü sınıfı.
    public class NPCController
    {
        private readonly NPCContext _context;
        private readonly ConsoleRenderer _renderer;
        private readonly IWorldService _worldService;
        private readonly IMovementStrategyFactory _strategyFactory;
        private BTNode _behaviorTreeRoot;
        private int _tickCounter = 0;

        /// Gerekli servis bağımlılıklarını (DI) alarak NPC kontrolcüsünü ve davranış ağacını başlatır.
        public NPCController(
            string name,
            ConsoleRenderer renderer,
            IWorldService worldService,
            IMovementStrategyFactory strategyFactory)
        {
            _context = new NPCContext(name);
            _renderer = renderer;
            _worldService = worldService;
            _strategyFactory = strategyFactory;

            BuildBehaviorTree();
        }

        /// Yetenek açılma olaylarını (SkillUnlocked) dinleyecek gözlemcileri (Observer) sisteme abone eder.
        public void SubscribeSkillObserver(ISkillObserver observer)
        {
            _context.PlayerSkillTree.SkillUnlocked += observer.OnSkillUnlocked;
        }

        /// NPC'nin öncelik sırasına göre (Kaçma -> Yemek Arama -> Boşta Durma) karar verme ağacını inşa eder.
        private void BuildBehaviorTree()
        {
            Selector rootSelector = new Selector();

            Sequence fleeSequence = new Sequence();
            fleeSequence.AddChild(new CheckEnemyCondition());
            fleeSequence.AddChild(new FleeAction(_strategyFactory));

            Sequence foodSequence = new Sequence();
            foodSequence.AddChild(new CheckHungerCondition());
            foodSequence.AddChild(new SearchFoodAction(_strategyFactory, _worldService));

            IdleAction idleAction = new IdleAction();

            rootSelector.AddChild(fleeSequence);
            rootSelector.AddChild(foodSequence);
            rootSelector.AddChild(idleAction);

            _behaviorTreeRoot = rootSelector;
        }

        /// Simülasyonun her adımında (frame/tick) dünyayı günceller, davranış ağacını çalıştırır ve ekranı çizer.
        public void Tick()
        {
            _tickCounter++;
            _worldService.UpdateWorld(_context, _tickCounter);
            _behaviorTreeRoot.Evaluate(_context);
            _renderer.Render(_context);
        }
    }
}