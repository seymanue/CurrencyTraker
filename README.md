# CurrencyTracker – Döviz Takip Konsol Uygulaması (C#)

> Türk Lirası (TRY) bazlı güncel döviz kurlarını Frankfurter FREE API üzerinden çekip,
> verileri hafızada tutan ve LINQ ile sorgulama/filtreleme/sıralama/istatistik sunan konsol uygulaması.

---

##  Teslim Bilgileri (Zorunlu)
- **Ad – Soyad:** Şeymanur Şirin
- **Öğrenci Numarası:** 20220108088
- **Bölüm:** Bilgisayar Programcılığı
- **GitHub Repository Linki:** https://github.com/seymanue/CurrencyTraker

---

##  Proje Amacı
Bir finans firmasının, TRY bazlı döviz kurlarını hızlıca görebileceği ve konsol üzerinden
çeşitli sorgular yapabileceği basit bir uygulama geliştirilmiştir.

Uygulama:
- Döviz verilerini **Frankfurter FREE API** üzerinden alır
- Gelen verileri **hafızada (List<Currency>)** tutar
- Kullanıcının seçimine göre **LINQ** ile sorgular yapar
- İstatistiksel özet (Count/Max/Min/Average) üretir

---

## 🔗 Kullanılan API (Zorunlu)
Frankfurter FREE API:
- `https://api.frankfurter.app/latest?from=TRY`

Bu endpoint, TRY bazlı güncel döviz kurlarını JSON olarak döndürür.

---

## ✅ Teknik Gereksinimler (Ödev Şartları)
- **C# Konsol Uygulaması**
- **HttpClient**
- **async / await**
- **List<Currency>** veri yapısı
- **LINQ** kullanımı:
  - `Where`
  - `Select`
  - `OrderBy` / `OrderByDescending`
  - `Count`
  - `Max`
  - `Min`
  - `Average`

### Yasaklar
- Hard-coded veri kullanılmaz (veri API’den çekilir)
- LINQ’siz çözüm yok
- GUI yok (sadece konsol)

---

## Zorunlu Model Sınıfları
Projede, API’den gelen JSON verisini karşılamak ve uygulama içinde kullanmak için
aşağıdaki model sınıfları kullanılmıştır:

```csharp
class CurrencyResponse
{
    public string Base { get; set; }
    public Dictionary<string, decimal> Rates { get; set; }
}

class Currency
{
    public string Code { get; set; }
    public decimal Rate { get; set; }
}
Veri Akışı (Nasıl Çalışır?)

Uygulama açıldığında HttpClient ile API’ye istek atılır (async/await).

Dönen JSON, CurrencyResponse modeline parse edilir.

Rates (Dictionary) içindeki veriler List<Currency> yapısına dönüştürülür.

Kullanıcı menüden seçim yapar.

Seçime göre ilgili LINQ işlemi uygulanır ve sonuç konsola yazdırılır.

 Konsol Menü (Zorunlu)

Uygulamada aşağıdaki menü bulunmaktadır:
===== CurrencyTracker =====
1. Tüm dövizleri listele
2. Koda göre döviz ara
3. Belirli bir değerden büyük dövizleri listele
4. Dövizleri değere göre sırala
5. İstatistiksel özet göster
0. Çıkış
Seçiminiz:
Menü İşlevleri (Detaylı)
1) Tüm Dövizleri Listele (LINQ Select)

Hafızadaki List<Currency> üzerinden tüm para birimleri listelenir.

LINQ Select kullanılır.

Örnek çıktı formatı:

USD : 0.0xxxx

EUR : 0.0xxxx

2) Koda Göre Döviz Ara (LINQ Where – Case Insensitive)

Kullanıcı bir döviz kodu girer (örn: usd, USD, Eur).

Arama büyük/küçük harf duyarsız yapılır.

LINQ Where kullanılır.

Bulunursa kur gösterilir, bulunamazsa bilgilendirme mesajı verilir.

3) Belirli Bir Değerden Büyük Dövizler (LINQ Where)

Kullanıcı bir değer girer (örn: 0.50).

Girilen değerden büyük olan kurlar filtrelenir.

LINQ Where kullanılır.

4) Dövizleri Değere Göre Sırala (LINQ OrderBy / OrderByDescending)

Dövizler kur değerine göre sıralanır.

Artan veya azalan sıralama yapılabilir (uygulama içindeki tercihe göre).

LINQ OrderBy veya OrderByDescending kullanılır.

5) İstatistiksel Özet (LINQ Count/Max/Min/Average)

Uygulama aşağıdaki istatistikleri gösterir:

Toplam döviz sayısı → Count

En yüksek kur → Max

En düşük kur → Min

Ortalama kur → Average

Not: Bu hesaplamalar List<Currency> içindeki Rate alanı üzerinden yapılır.

0) Çıkış

Kullanıcı 0 girince uygulama kapanır.
Kurulum ve Çalıştırma
1) Repoyu klonla
git clone https://github.com/seymanue/CurrencyTraker.git

2) Proje klasörüne gir
cd CurrencyTraker

3) Uygulamayı çalıştır
dotnet run

 Örnek Kullanım Senaryosu

Program açılır, API’den veriler çekilir.

Menü görüntülenir.

Kullanıcı 2 seçer ve usd yazar.

Program USD kurunu ekrana yazar.

Kullanıcı 5 seçer; toplam döviz sayısı, min/max/average değerleri gösterilir.

Kullanıcı 0 ile çıkar.

 Hata Yönetimi (Önerilen Davranış)

API bağlantısı yoksa veya endpoint hata verirse uygulama kullanıcıya bilgi mesajı verir.

Kullanıcı yanlış menü seçerse “Geçersiz seçim” mesajı gösterilir.

Sayısal değer istenirken hatalı giriş yapılırsa (örn: harf girilirse) kullanıcı tekrar yönlendirilir.

Ödev Şartlarının Karşılanması

 C# Konsol Uygulaması

 HttpClient ile API’den veri çekme

 async/await kullanımı

 List<Currency> ile veriyi hafızada tutma

 LINQ: Where/Select/OrderBy/Count/Average (ve Max/Min)

 Hard-coded veri yok

 GUI yok

 Not

Bu proje, ders kapsamındaki LINQ ve API kullanımını pekiştirmek amacıyla geliştirilmiştir.
