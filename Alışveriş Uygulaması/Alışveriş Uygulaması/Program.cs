
using System.Reflection.Metadata.Ecma335;

// Ürünlerin Listesini oluşturup fiyatlarini yazıyoruz. 
var ürünListesi = new Dictionary<int, (string ürün, decimal fiyatı)>()
{  //1      2       3
    {1,("Gömlek",1000m) },                                                  // Decimal olduklarını belirtmek için fiyatın sonuna m koyuyoruz.
    {2,("Pantolon",990m)},                                                  // 1. değişkenimiz ürünün sırasını tutuyor
    {3,("Çorap",300m)},                                                     // 2. değişken ürün ismini
    {4,("Tshirt",649m)},                                                    // 3. değişkenimiz ise fiyatını decimal cinsinden tutuyor.
    {5,("Kazak",1779m)},
    {6,("Atkı",286m)}
};


// Kullanıcının seçtiği ürünleri tutabilmek için bir sepet oluşturuyoruz.
// Seçtiğimiz ürünün sadece ürünün ismini (string ürün) ve ürünün fiyatını (decimal fiyatı) listeye ekliyor


var sepet = new List<(string ürün, decimal fiyatı)>();
decimal toplamTutar = 0m;  // Sepetin başlangıç değeri





// 2) Geçerli bir seçim yapılana kadar döngüde kal
while (true)
{

    Console.WriteLine("=== Ürün Listesi ===");
    foreach (var kvp in ürünListesi) // 
    {  // Ürün listesindeki 1.değişken  2. değişken           3. değişken          bütün ürün listesini sırayla alt alta yazıyor.
        Console.WriteLine($"{kvp.Key}. {kvp.Value.ürün} - {kvp.Value.fiyatı:F2}"); // Kullanıcının ürün listesinden ürün seçmesi için seçti
    }
    Console.WriteLine("0. Alışverişi tamamla ve çık");                              // Kullanıcı alışverişini tamamladıysa 0' a basıp çıkabileceğini belirtiyoruz

    Console.Write("\nSeçiminiz (Ürün Numarası): ");
    if (!int.TryParse(Console.ReadLine(), out int secim))                           //Girilen değeri int'e çevirmeye çalışıyoruz; 
    {                                                                               //başarısızsa hata mesajı verip döngü başına dönüyoruz
        Console.WriteLine("Geçersiz giriş! Enter’a basıp tekrar deneyin.");
        Console.ReadKey(true);
        continue;
    }

    if (secim == 0)
        break;

    if (!ürünListesi.ContainsKey(secim))                                           // Girilen numara ürünListesi'nde yoksa uyarı verip yeniden sorma için döngü başına dönüyoruz
    {                                                                              // 1-6 arasında ürünlerimiz var farklı bir tuşlama yapılırsa hata verir
        Console.WriteLine("Listede böyle bir ürün yok! Enter’a basıp tekrar deneyin.");
        Console.ReadKey(true);                                                     // Kullanıcı bir tuşa basana kadar bekler. (true) olmasının sebebi kullanıcı bir tuşa bastığında onu consola yazmaz ve devam eder
        continue;                                                                  // eğer (false) yaparsanız kullanıcı bir tuşa bastığında consolda oda gözükücek
    }



    var secilenUrun = ürünListesi[secim];                                         // Kullanıcının yapmış olduğu ürün seçimlerini 
    sepet.Add(secilenUrun);                                                       // seçilen ürün olarak sepetimize ekliyoruz.

    // Sepet toplamını her ürün eklendiğinde güncellemek için bu işlemi yapıyoruz.
    toplamTutar = SepeteEkle(toplamTutar, secilenUrun.fiyatı);

    Console.WriteLine($"\n\"{secilenUrun.ürün}\" sepete eklendi.");  // seçilen ürünün ismini belirtip sepete eklendiğini belirtiyoruz
    Console.WriteLine($"Ödemeniz gereken toplam tutar: {toplamTutar:F2}"); // F2 burda Kesirli rakamlarda virgülden sonra kaç hane belirtmemiz gerektiğini gösteriyor
    Console.WriteLine("Devam etmek için Enter’a basın.");
    Console.ReadKey(true);

    static decimal SepeteEkle(decimal oncekiToplam, decimal yeniFiyat)  //Burda öncekitoplam tutarla sepete eklenen yeni ürünün fiyatını toplayan bir metot kullanıyoruz.
    {
        return oncekiToplam + yeniFiyat;
    }


    // Burda sadece kullanıcının sepete hangi ürünü eklediğini yazıyoruz.
    switch (secim)
    {
        case 1:

            Console.WriteLine("Gömlek Sepetinize Eklendi.  ");
            break;


        case 2:

            Console.WriteLine("Pantolon Sepetinize Eklendi.  ");

            break;
        case 3:

            Console.WriteLine("Çorap Sepetinize Eklendi.  ");


            break;
        case 4:

            Console.WriteLine("Tshirt Sepetinize Eklendi.  ");

            break;
        case 5:

            Console.WriteLine("Kazak Sepetinize Eklendi.  ");

            break;
        case 6:

            Console.WriteLine("Atkı Sepetinize Eklendi. ");

            break;

        default:
            Console.WriteLine("Seçmiş Olduğunuz Ürün Mağazamızda bulunmamaktadır. Başka bir yerle karıştırıyorsun!! ");
            break;
    }



}







// Alışveriş bitince özet gösterimi
Console.Clear(); // Konsolu temizleyip sadece sepeti ve toplam tutarı göstermek için kullanıyoruz.
if (sepet.Count == 0) // Sepette ürün yoksa boş uyarısı veriyor
{
    Console.WriteLine("Sepetiniz boş. Hoşça kalın!");
}
else // Sepet boş değilse alışveriş özetini gösteriyoruz.
{
    Console.WriteLine("=== Alışveriş Özeti ===\n");
    Console.WriteLine("Sepetinizdeki ürünler:");

    foreach (var item in sepet)  // Kullanıcını sepete eklediği ürünlerin hepsini yazdırmak için foreach yapısını kullanıyoruz.
    {
        Console.WriteLine($"- {item.ürün} ({item.fiyatı:F2})");
    }
    Console.WriteLine("\n---------------------------");

}


// toplam tutar'a uygulamak istediğimiz indirimleri if else yapılarıyla yazıyoruz

if (toplamTutar > 4000)
{   // Toplam Harcanan tutar 4000TL üzerindeyse %30 indirim uyguluyoruz.
    Console.WriteLine("Sepet tutarı 4000 Tl'yi Geçtiği için %30 indirim uygulandı.");
    Console.WriteLine("İndirimsiz Sepet Tutarı: " + toplamTutar);
    decimal sepetToplamTutar = toplamTutar * 0.70m;
    Console.WriteLine($"Sepet Tutarı: {sepetToplamTutar:F2} TL "); // F2 burda Kesirli rakamlarda virgülden sonra kaç hane belirtmemiz gerektiğini gösteriyor
}


else if (toplamTutar > 3000)
{   // Toplam Harcanan tutar 3000TL üzerindeyse %40 indirim uyguluyoruz.
    Console.WriteLine("Sepet tutarı 3000 Tl'yi Geçtiği için %20 indirim uygulandı.");
    Console.WriteLine("İndirimsiz Sepet Tutarı: " + toplamTutar);
    decimal sepetToplamTutar = toplamTutar * 0.80m;
    Console.WriteLine($"İndirimli Sepet Tutarı: {sepetToplamTutar:F2} TL");
}


else if (toplamTutar > 2000)
{   // Toplam Harcanan tutar 2000TL üzerindeyse %10 indirim uyguluyoruz.
    Console.WriteLine("Sepet tutarı 2000 Tl'yi Geçtiği için %10 indirim uygulandı.");
    Console.WriteLine("İndirimsiz Sepet Tutarı: " + toplamTutar);
    decimal sepetToplamTutar = toplamTutar * 0.90m;
    Console.WriteLine($"Sepet Tutarı: {sepetToplamTutar:F2} TL ");
}


else
{   // Eğer indirim uygulanmıyorsa
    Console.WriteLine("Alışverişiniz tamamlandı.");
    Console.WriteLine($"Sepet Tutarı: {toplamTutar:F2}");
}


Console.WriteLine("Çıkmak için bir tuşa basın.");
Console.ReadKey();

