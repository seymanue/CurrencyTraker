using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class CurrencyResponse
{
    [JsonPropertyName("base")]
    public string Base { get; set; } = "";

    [JsonPropertyName("rates")]
    public Dictionary<string, decimal> Rates { get; set; } = new();
}

class Currency
{
    public string Code { get; set; } = "";
    public decimal Rate { get; set; }
}

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Verileri hafızada tut (tek sefer çek)
        var currencies = await GetCurrenciesAsync();

        while (true)
        {
            Console.WriteLine("\n===== CurrencyTracker =====");
            Console.WriteLine("1. Tüm dövizleri listele");
            Console.WriteLine("2. Koda göre döviz ara");
            Console.WriteLine("3. Belirli bir değerden büyük dövizleri listele");
            Console.WriteLine("4. Dövizleri değere göre sırala");
            Console.WriteLine("5. İstatistiksel özet göster");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");

            var choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "0")
                break;

            switch (choice)
            {
                case "1":
                    // LINQ Select
                    currencies
                        .Select(c => $"{c.Code,-5} : {c.Rate}")
                        .ToList()
                        .ForEach(Console.WriteLine);
                    break;

                case "2":
                    Console.Write("Döviz kodu (örn: USD): ");
                    var code = (Console.ReadLine() ?? "").Trim();

                    // LINQ Where (case-insensitive)
                    var found = currencies
                        .Where(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (found.Count == 0) Console.WriteLine("Bulunamadı.");
                    else found.ForEach(c => Console.WriteLine($"{c.Code,-5} : {c.Rate}"));
                    break;

                case "3":
                    Console.Write("Alt limit (örn: 1.5): ");
                    var raw = (Console.ReadLine() ?? "").Trim().Replace(",", ".");
                    if (!decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out var limit))
                    {
                        Console.WriteLine("Geçersiz değer!");
                        break;
                    }

                    // LINQ Where
                    var bigger = currencies
                        .Where(c => c.Rate > limit)
                        .ToList();

                    if (bigger.Count == 0) Console.WriteLine("Bu değerden büyük döviz yok.");
                    else bigger.ForEach(c => Console.WriteLine($"{c.Code,-5} : {c.Rate}"));
                    break;

                case "4":
                    Console.Write("Sıralama (1=Artan, 2=Azalan): ");
                    var s = (Console.ReadLine() ?? "").Trim();

                    // LINQ OrderBy / OrderByDescending
                    var sorted = (s == "2")
                        ? currencies.OrderByDescending(c => c.Rate).ToList()
                        : currencies.OrderBy(c => c.Rate).ToList();

                    sorted.ForEach(c => Console.WriteLine($"{c.Code,-5} : {c.Rate}"));
                    break;

                case "5":
                    // LINQ Count, Max, Min, Average
                    var count = currencies.Count;
                    var maxRate = currencies.Max(c => c.Rate);
                    var minRate = currencies.Min(c => c.Rate);
                    var avgRate = currencies.Average(c => c.Rate);

                    var maxCur = currencies.First(c => c.Rate == maxRate);
                    var minCur = currencies.First(c => c.Rate == minRate);

                    Console.WriteLine($"Toplam döviz sayısı : {count}");
                    Console.WriteLine($"En yüksek kur       : {maxCur.Code} = {maxRate}");
                    Console.WriteLine($"En düşük kur        : {minCur.Code} = {minRate}");
                    Console.WriteLine($"Ortalama kur        : {avgRate}");
                    break;

                default:
                    Console.WriteLine("Hatalı seçim.");
                    break;
            }

            Console.WriteLine("\nDevam etmek için Enter...");
            Console.ReadLine();
        }

        Console.WriteLine("Program kapandı.");
    }

    static async Task<List<Currency>> GetCurrenciesAsync()
    {
        using var client = new HttpClient();
        var json = await client.GetStringAsync("https://api.frankfurter.app/latest?from=TRY");

        var data = JsonSerializer.Deserialize<CurrencyResponse>(json)
                   ?? throw new Exception("API verisi okunamadı.");

        // LINQ Select -> List<Currency>
        var list = data.Rates
            .Select(r => new Currency { Code = r.Key, Rate = r.Value })
            .ToList();

        // TRY baz (from=TRY) -> TRY'yi ekleyelim
        list.Add(new Currency { Code = "TRY", Rate = 1m });

        return list;
    }
}

