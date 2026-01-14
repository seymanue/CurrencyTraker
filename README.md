# CurrencyTracker – Döviz Takip Konsol Uygulaması

## Öğrenci Bilgileri
Ad Soyad:Şeymanur Şirin  
Öğrenci Numarası:20220108088
---

## Proje Açıklaması
Bu proje, C# dili kullanılarak geliştirilmiş bir konsol uygulamasıdır.  
Uygulama, Frankfurter FREE API üzerinden **güncel döviz kurlarını** çekerek Türk Lirası (TRY) bazlı döviz bilgilerini kullanıcıya sunar.

Veriler uygulama çalışırken hafızada tutulur ve **LINQ** kullanılarak çeşitli sorgulamalar yapılır.  
Projede **hard-coded veri kullanılmamış**, tüm veriler API üzerinden dinamik olarak alınmıştır.

---

## Kullanılan Teknolojiler
- C#
- .NET Console Application
- HttpClient
- async / await
- LINQ
- Frankfurter API

---

## Kullanılan API
https://api.frankfurter.app/latest?from=TRY

---

## Model Sınıfları

### CurrencyResponse
- Base
- Rates (Dictionary)

### Currency
- Code
- Rate

---

## Konsol Menü Seçenekleri
1. Tüm dövizleri listele  
2. Koda göre döviz ara  
3. Belirli bir değerden büyük dövizleri listele  
4. Dövizleri değere göre sırala  
5. İstatistiksel özet göster  
0. Çıkış  

---

## LINQ Kullanımı
- Select
- Where
- OrderBy / OrderByDescending
- Count
- Max
- Min
- Average

---


