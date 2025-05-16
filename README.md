Konsol Alışveriş Uygulaması

Açıklama

Bu C# konsol uygulaması, kullanıcıya önceden tanımlı bir ürün listesi sunar, seçilen ürünleri sepete ekler, toplam tutarı dinamik olarak günceller ve belirlenen indirim kurallarına göre nihai tutarı hesaplar.

Özellikler

Ürün listesinin ekranda gösterimi

Kullanıcının ürün seçerek sepete ekleme işlemi

Sepet içeriğinin ve toplam tutarın anlık güncellenmesi

Alışveriş bitiminde sepetteki ürünlerin listelenmesi ve toplam tutarın gösterilmesi

İndirim kuralları (if-else bloklarıyla uygulanır):

4000 TL ve üzeri alışverişlerde %30 indirim

3000 TL ve üzeri alışverişlerde %20 indirim

2000 TL ve üzeri alışverişlerde %10 indirim

Gereksinimler

.NET 6.0 veya üzeri

C# 10.0

Kurulum ve Çalıştırma

Projeyi kendi makinenize klonlayın veya indirin:

git clone <repo-url>

Proje klasörüne gidin:

cd <proje-dizini>

Projeyi derleyip çalıştırın:

dotnet run --project <ProjeAdi>.csproj

Uygulama açıldığında ürün numarasını girerek seçim yapın. 0 girerek alışverişi tamamlayabilirsiniz.

Kullanılan Metotlar

SepeteEkle(decimal oncekiToplam, decimal yeniFiyat): İki decimal değeri toplar ve güncel toplam tutarı döner.

İndirimin Matematiği

Yüzde bazlı indirim için kullanılan formül:

// Yüzde indirim uygulamak için
decimal indirimOrani = yüzde / 100m;
decimal indirimliFiyat = toplamTutar * (1 - indirimOrani);
