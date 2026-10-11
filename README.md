# Teknik Servis Takip Sistemi (Console Application)

Bu proje, bir teknik servisteki cihaz kayıtlarını, müşteri bilgilerini ve işlem durumlarını yönetmek için **C#** ile geliştirilmiş bir konsol uygulamasıdır. Veriler harici bir metin dosyasında (`servis_kayitlari.txt`) saklanarak kalıcı hale getirilir.

---

##  Özellikler

- **Yeni Kayıt Oluşturma:** Müşteri adı, iletişim bilgisi, cihaz türü, arıza tanımı ve tahmini ücret bilgilerini alarak otomatik artan kayıt numarasıyla yeni servis kaydı açar.
- **Tüm Kayıtları Listeleme:** Sistemde kayıtlı olan tüm servis işlemlerini detaylı bir şekilde ekrana döker.
- **Arama Fonksiyonları:**
  - Müşteri adına göre filtreleme / arama
  - Kayıt numarasına göre doğrudan sorgulama
- **Durum Güncelleme:** Kaydın servis durumunu (*Bekliyor*, *İşlemde*, *Tamamlandı*, *Teslim Edildi*) günceller ve değişiklikleri anında dosya üzerine yazar.
- **İstatistik & Raporlama:** Durum bazlı iş sayılarını ve toplam servis kazancını/bedelini hesaplar.
- **Veri Kalıcılığı (File I/O):** Program başladığında `servis_kayitlari.txt` dosyasındaki verileri otomatik okur, yeni kayıt ve güncellemeleri dosyaya kaydeder.

---

##  Teknolojiler

- **Dil:** C# (.NET)
- **Tür:** Console Application
- **Veri Depolama:** Flat-file (`System.IO.File` - Pipe `|` delimited text)

---

##  Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için:

1. Depoyu klonlayın:
   ```bash
   git clone [https://github.com/KULLANICI_ADINIZ/REPO_ADINIZ.git](https://github.com/KULLANICI_ADINIZ/REPO_ADINIZ.git)
   cd REPO_ADINIZ
   ```

2. Projeyi derleyin ve çalıştırın:
   ```bash
   dotnet build
   dotnet run
   ```

---

##  Dosya Yapısı (Veri Formatı)

Kayıtlar `servis_kayitlari.txt` dosyasında şu biçimde tutulur:
```text
KayitNo|MusteriAdi|Telefon|CihazTuru|Ariza|Tarih|Ucret|Durum
1001|Ahmet Yılmaz|05551112233|Laptop|Ekran kırık|11.10.2026|2500|Bekliyor
```
