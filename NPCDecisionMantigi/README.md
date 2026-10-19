```
```markdown
```

```
#  C# Modular NPC Decision System & AI Simulator
```

```
Bu proje, C# kullanarak geliştirilmiş; modüler, katmanlı bir mimariye sahip ve
endüstri standardı yazılım prensipleriyle tasarlanmış bir **NPC (Non-Player
Character) Karar Mekanizması ve Dünya Simülasyonu** sistemidir.
```

```
Açık kaynaklı bu konsol simülasyonu; yapay zeka karar ağaçları, strateji
yönetimi, olay tabanlı iletişim ve temiz mimari pratiklerini uygulamalı olarak
sergilemek amacıyla geliştirilmiştir.
```

```
##  Mimari ve Tasarım Yaklaşımı (Clean Architecture)
```

```
Proje, sıkı bağlılığı (tight coupling) önlemek ve sürdürülebilirliği artırmak
için **Domain-Driven Design (DDD)** ve **Clean Architecture** prensiplerine
sadık kalınarak katmanlara ayrılmıştır:
```

```
```text
```

```
NPCDecisionSystem/
│
├── Domain/               # Temel iş varlıkları (Entities, Enums, Value Objects)
├── Strategies/           # Hareket algoritmaları ve Strategy/Factory
implementasyonları
├── BehaviorTree/         # Yapay zeka karar ağacı (Core, Conditions, Actions)
├── Simulation/           # Dünya ve zaman akışı simülasyon servisi
├── Observers/            # Olay tabanlı gözlemci (Observer Pattern) bileşenleri
├── Presentation/         # Konsol arayüzü ve render işlemleri (SRP uyumu)
├── Application/          # Orkestrasyon ve NPC kontrolcüsü (NPCController)
└── Program.cs            # Composition Root (Bağımlılıkların yönetildiği
başlangıç noktası)
```

# `## Kullanılan Tasarım Desenleri (Design Patterns)` 

```
Projede kod tekrarını önlemek, esneklik kazandırmak ve modülerliği sağlamak
adına şu tasarım desenleri aktif olarak uygulanmıştır:
```

```
1. **Behavior Tree (Davranış Ağacı):** NPC'nin "Kaçma", "Yemek Arama" ve "Boşta
Durma" eylemlerini öncelik sırasına göre (`Selector` ve `Sequence` düğümleriyle)
mantıksal bir sırada yürütür.
```

```
2. **Strategy Pattern (Strateji Deseni):** NPC'nin hareket mantığını
soyutlayarak normal hız (`NormalMovementStrategy`) ile yetenek açıldığında
aktifleşen çift adım hızını (`DoubleStepMovementStrategy`) dinamik olarak
değiştirir.
```

```
3. **Factory Pattern (Fabrika Deseni):** Strateji nesnelerinin her adımda (`new`
ile) bellek israfı yaratmasını önlemek amacıyla önbellekleyen
(`MovementStrategyFactory`) bir yapı sunar.
```

```
4. **Observer Pattern (Gözlemci Deseni):** C# `event` altyapısı kullanılarak,
NPC başarılı kaçışlar yaptığında açılan yeteneklerin (`SkillTree`) konsol ses
sistemine (`AudioAlertObserver`) ve UI katmanına (`ConsoleRenderer`) bağımlı
olmadan haber vermesini sağlar.
```

# `## Uygulanan SOLID Prensipleri` 

```
* **S (Single Responsibility):** Her sınıf tek bir sorumluluğa sahiptir.
Örneğin; `ConsoleRenderer` sadece ekran çizimiyle ilgilenirken, `WorldSimulator`
sadece dünya zamanını ve istatistikleri yönetir.
```

```
* **O (Open/Closed):** Mevcut kodlara dokunmadan sisteme yeni bir hareket
stratejisi, yeni bir davranış düğümü veya yeni bir gözlemci (örneğin veritabanı
loglayıcısı) kolayca eklenebilir.
```

```
* **L (Liskov Substitution):** Tüm davranış düğümleri (`BTNode`) ve hareket
stratejileri (`IMovementStrategy`) kendi soyut sözleşmelerinin yerini sorunsuzca
alabilir.
```

```
* **I (Interface Segregation):** Geniş ve şişkin arayüzler yerine, işlevlerine
göre ayrılmış küçük arayüzler (`ISkillObserver`, `IMovementStrategy`,
`IWorldService`) tercih edilmiştir.
```

```
* **D (Dependency Inversion):** Üst seviye modüller alt seviye modüllere değil,
her iki taraf da soyutlamalara (`interface`) bağımlıdır. Sınıflار
bağımlılıklarını `Constructor Injection` yoluyla dışarıdan alır.
```

# `## Kurulum ve Çalıştırma` 

```
Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları
izleyebilirsiniz:
```

`1. Repoyu klonlayın: ```bash` 

```
git clone [https://github.com/KULLANICI_ADINIZ/NPCDecisionSystem.git](https://
github.com/KULLANICI_ADINIZ/NPCDecisionSystem.git)
```

```
2. Proje dizinine gidin:
```

- ````bash` 

```
cd NPCDecisionSystem
```

```
3. Uygulamayı derleyin ve çalıştırın:
```bash
```

```
dotnet run
```

```
## Projeden Öne Çıkan Teknik Detaylar
```

```
* **Memory Optimization:** Bellek sızıntılarını önlemek adına strateji nesneleri
fabrika içinde önbelleklenerek (cached) yönetilir.
* **Artifact-Free Rendering:** Konsol ekranı yenilenirken metin uzunluk
değişimlerinden kaynaklanan görsel kalıntıları engellemek için `PadRight`
tamponlama teknikleri uygulanmıştır.
```

```
* **Decoupled Architecture:** İş mantığı (Domain) hiçbir şekilde konsol
donanımına (`Console.WriteLine` veya `Console.Beep`) doğrudan bağımlı değildir.
```

```
<FollowUp label="GitHub'a yükleme aşamasında başka takıldığın bir yer olursa
buradayım!" query="Projeyi GitHub'a yüklerken terminal komutları veya başka bir
konuda desteğe ihtiyacın var mı?"/>
```

