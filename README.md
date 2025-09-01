# Pusula Fullstack Case – Bircan Yılmaz

Bu repository, **Pusula Talent Academy Programı** için hazırladığım **Full Stack Case Study** çalışmalarını içermektedir. Proje, C# ile kod soruları çözülmüş ve test sorularının cevapları PDF formatında sunulmuştur.  

---

## İçindekiler

1. [Proje Hakkında](#proje-hakkında)  
2. [Teslim Dosyaları](#teslim-dosyalari)  
3. [Kod Soruları](#kod-sorulari)  
4. [Test Soruları](#test-sorulari)  
5. [Kurulum ve Çalıştırma](#kurulum-ve-calistirma)  

---

## Proje Hakkında

Bu case çalışması ile aşağıdaki yetkinlikler değerlendirilmektedir:

- **C# Programlama** ve **Clean Code** prensiplerine uygun çözüm geliştirme  
- **LINQ** ve **XML/JSON** veri işleme  
- **Veri filtreleme ve analiz**  
- **Problem çözme ve algoritma geliştirme**

Case çalışması 4 kod sorusu ve 15 test sorusundan oluşmaktadır.

---

## Teslim Dosyaları

| Dosya | Açıklama |
|-------|----------|
| `MaxIncreasingSubArrayAsJson.cs` | En büyük artan alt diziyi JSON olarak döndürme |
| `LongestVowelSubsequenceAsJson.cs` | Kelime listesinde en uzun sesli harf alt dizisini ve uzunluğunu JSON olarak döndürme |
| `FilterPeopleFromXml.cs` | XML içerisindeki Person verilerini filtreleyip JSON formatında döndürme |
| `FilterEmployees.cs` | Statik tuple üzerinden çalışanları filtreleyip JSON olarak döndürme |
| `TestAnswers.pdf` | Tüm test sorularının cevapları PDF formatında |

---

## Kod Soruları

### 1. MaxIncreasingSubArrayAsJson.cs

- **Açıklama:** Bir tamsayı listesinde ardışık artış gösteren alt dizilerden toplamı en yüksek olanı bulup JSON formatında döndürür.  
- **Metot:** `public static string MaxIncreasingSubarrayAsJson(List<int> numbers)`  
- **Kullanılan:** `System.Linq`, `System.Text.Json`, `System.Collections.Generic`  

### 2. LongestVowelSubsequenceAsJson.cs

- **Açıklama:** Her kelimenin ardışık sesli harflerinden oluşan en uzun alt diziyi bulur ve kelime, alt dizi ve uzunluğunu JSON olarak döndürür.  
- **Metot:** `public static string LongestVowelSubsequenceAsJson(List<string> words)`  

### 3. FilterPeopleFromXml.cs

- **Açıklama:** XML verisi içerisinden belirli kriterlere uyan Person verilerini seçip JSON formatında döndürür.  
- **Metot:** `public static string FilterPeopleFromXml(string xmlData)`  

### 4. FilterEmployees.cs

- **Açıklama:** Statik tuple üzerinde filtreleme ve hesaplamalar yaparak JSON formatında döndürür.  
- **Metot:** `public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)`  

---

## Kurulum ve Çalıştırma

1. Repository’i klonlayın:  

```bash
git clone https://github.com/bircany/pusula-fullstack-case.git
Her bir .cs dosyasını Visual Studio veya dotnet CLI ile çalıştırabilirsiniz:

dotnet run
JSON çıktıları doğrudan metodlardan alınabilir. Test soruları PDF olarak inceleyebilirsiniz.

Notlar
Kodlar Clean Code prensiplerine uygun olarak yazılmıştır.
JSON dönüşleri System.Text.Json kullanılarak sağlanmıştır.
Test soruları, SQL ve LINQ mantığı ile ilgili teorik bilgiler içermektedir.


