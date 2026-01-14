# CurrencyTracker – Döviz Takip Konsol Uygulaması

## Öğrenci Bilgileri
- Ad Soyad:Şeymanur Şirin  
- Öğrenci Numarası: 20220108088  
- Bölüm: Bilgisayar Programcılığı  

---

## Proje Açıklaması
Bu proje, **C#** dili kullanılarak geliştirilmiş bir **konsol tabanlı döviz takip uygulamasıdır**.  
Uygulama, **Frankfurter API** üzerinden **güncel döviz kurlarını** çekerek Türk Lirası (TRY) bazlı döviz bilgilerini kullanıcıya sunar.

Proje kapsamında:
- Harici bir API kullanılmıştır
- **Hard-coded (sabit) veri kullanılmamıştır**
- Veriler uygulama çalışırken **dinamik olarak** alınmaktadır
- LINQ sorguları ile veriler üzerinde işlemler yapılmaktadır

---

## Kullanılan Teknolojiler
- C#
- .NET 7
- Console Application
- LINQ
- HTTP Client
- JSON Serialization
- Frankfurter Exchange Rates API

---

## Uygulama Özellikleri
Uygulama çalıştırıldığında kullanıcıya menü sunulur:

1. **Tüm dövizleri listeleme**  
2. **Döviz koduna göre arama** (ör: USD, EUR)  
3. **Belirli bir değerin üzerindeki dövizleri listeleme**  
4. **Dövizleri kura göre sıralama** (artan / azalan)  
5. **İstatistiksel özet gösterimi**
   - Toplam döviz sayısı
   - En yüksek kur
   - En düşük kur
   - Ortalama kur
0. **Programdan çıkış**

---

## LINQ Kullanımı
Projede aşağıdaki LINQ metotları aktif olarak kullanılmıştır:

- `Select`
- `Where`
- `OrderBy`
- `OrderByDescending`
- `Count`
- `Max`
- `Min`
- `Average`

---

## Veri Kaynağı
- Frankfurter API  
- API adresi:  
  `https://api.frankfurter.app/latest?from=TRY`

---

## Çalıştırma
1. Projeyi klonlayın veya indirin  
2. Terminalde proje klasörüne girin  
3. Aşağıdaki komutu çalıştırın:

```bash
dotnet run
