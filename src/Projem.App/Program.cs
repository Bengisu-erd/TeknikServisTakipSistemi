
using System;
using System.IO;

string DosyaAdi="servis_kayitlari.txt";
int[] kayit_numaralari = new int[100];
string[] musteri_isimleri = new string[100];
string[] telefonlar = new string[100];
string[] cihazlar=new string[100];
string[] arizalar=new string[100];
DateTime[] tarihler=new DateTime[100];
decimal[] ucretler=new decimal[100];
string[] durum=new string[100];
int kayit_sayisi=0;



if(File.Exists(DosyaAdi))
{
  
   string[] satirlar=File.ReadAllLines(DosyaAdi);
   for(int i=0; i<satirlar.Length; i++)
    {
        if (satirlar[i] != "")
        {
            string[] bilgiler = satirlar[i].Split("|");
            if(bilgiler.Length==8 && kayit_sayisi < 100)
            {
                kayit_numaralari[kayit_sayisi]=int.Parse((bilgiler[0]));
                musteri_isimleri[kayit_sayisi]=bilgiler[1];
                telefonlar[kayit_sayisi]=bilgiler[2];
                cihazlar[kayit_sayisi]=bilgiler[3];
                arizalar[kayit_sayisi]=bilgiler[4];
                tarihler[kayit_sayisi]=DateTime.Parse(bilgiler[5]);
                ucretler[kayit_sayisi]=decimal.Parse(bilgiler[6]);
                durum[kayit_sayisi]=bilgiler[7];
                kayit_sayisi++;
                

            }
        }
       

    }
    for(int i=0; i<kayit_sayisi; i++)
    {
        Console.WriteLine(satirlar[i]);
    }
 
}

bool calismaDurumu=true;
while(calismaDurumu){
Console.WriteLine("========================================================");
Console.WriteLine("                   TEKNIK SERVIS SISTEMI                ");
Console.WriteLine("========================================================");

Console.WriteLine("1 - Yeni Servis Kaydi"        );
Console.WriteLine("2 - Tum Kayitlari Listele    ");
Console.WriteLine("3 - Musteri Ara              ");
Console.WriteLine("4 - Kayit Numarasiyla Ara    ");
Console.WriteLine("5 - Servis Durumunu Güncelle ");
Console.WriteLine("6 - Servis İstatistikleri    ");
Console.WriteLine("7 - Cikis                    ");

Console.Write("Seciminiz:  ");
string secim=(Console.ReadLine() ?? "").Trim();

if(secim == "1")
    {
        if (kayit_sayisi >= 100)
        {
            Console.WriteLine("Tum kayitlar dolu.Kayit yapilamaz");
        }else{
        Console.WriteLine("1 -> Yeni Servis Kaydi");
        Console.Write("Musteri Adi:");
        musteri_isimleri[kayit_sayisi]=Console.ReadLine() ?? "";
        Console.Write("Telefon:");
        telefonlar[kayit_sayisi]=Console.ReadLine() ?? "";
        Console.Write("Cihaz turu:");
        cihazlar[kayit_sayisi]=Console.ReadLine() ?? "";
        Console.Write("Ariza Aciklamasi:");
        arizalar[kayit_sayisi]=Console.ReadLine() ?? "";
        Console.Write("Tahmini Ucret:");
        ucretler[kayit_sayisi]=Decimal.Parse(Console.ReadLine()?? "");
        tarihler[kayit_sayisi]=DateTime.Now;
        durum[kayit_sayisi]="Bekliyor";
        if(kayit_sayisi>0){
           int yeniKayitNo=kayit_numaralari[kayit_sayisi-1]+1;
           kayit_numaralari[kayit_sayisi]=yeniKayitNo;
            }
            else
            {
                kayit_numaralari[kayit_sayisi]=1001;
            }
            string yeniSatir= kayit_numaralari[kayit_sayisi] + "|" +
                              musteri_isimleri[kayit_sayisi]+ "|" +
                              telefonlar[kayit_sayisi] + "|" +
                              cihazlar[kayit_sayisi]+ "|" +
                              arizalar[kayit_sayisi] +"|" +
                              tarihler[kayit_sayisi].ToString("dd.MM.yyyy") +"|"+
                              ucretler[kayit_sayisi]+"|"+
                              durum[kayit_sayisi];
            File.AppendAllText(DosyaAdi,yeniSatir + Environment.NewLine);

        Console.WriteLine("\nServis kaydi basarili bir sekilde olusturuldu.");
        Console.WriteLine($"Kayit numaraniz:{kayit_numaralari[kayit_sayisi]}" );
        Console.WriteLine($"Teslim tarihi :{tarihler[kayit_sayisi].ToString("dd.MM.yyyy")}");
        Console.WriteLine($"Durum: {durum[kayit_sayisi]}");

                         
        kayit_sayisi++;
        }

    }

else if(secim == "2")
    {
        Console.WriteLine("2 -> Tum Kayitlari Listele\n");

        if (kayit_sayisi == 0)
        {
            Console.WriteLine("Henuz kayit yapilmadi.");
        }else{
        Console.WriteLine("=======================================\n");

        for(int i=0; i<kayit_sayisi; i++)
        {
            Console.WriteLine($"Kayit No: {kayit_numaralari[i]}");
            Console.WriteLine($"Musteri: {musteri_isimleri[i]}");
            Console.WriteLine($"Telefon: {telefonlar[i]}");
            Console.WriteLine($"Cihaz: {cihazlar[i]} ");
            Console.WriteLine($"Ariza: {arizalar[i]}");
            Console.WriteLine($"Tarih: {tarihler[i].ToString("dd.MM.yyyy")}");
            Console.WriteLine($"Ucret: {ucretler[i]}");
            Console.WriteLine($"Durum: {durum[i]}\n");
            Console.WriteLine("=======================================");
            

        }
        }

        Console.WriteLine("\nAna menuye donmek icin herhangi bir tusa basin...");
        Console.ReadKey();
    }
else if (secim == "3")
    {
        Console.WriteLine("3 -> Musteri Ara"       );
        Console.Write("Aramak istediginiz ismi girin:");
        string aranan_isim=Console.ReadLine() ?? "";
        for(int i=0; i<kayit_sayisi; i++)
        {
        bool isim_bulundu=musteri_isimleri[i].ToLower().Trim().Contains(aranan_isim.ToLower().Trim());

            if (isim_bulundu)
            {
                
                Console.WriteLine($"Musteri adi: {musteri_isimleri[i]}");
                Console.WriteLine($"Kayit No   : {kayit_numaralari[i]}");
                Console.WriteLine($"Ariza      : {arizalar[i]}");
                Console.WriteLine($"Durum      : {durum[i]}");

            }
            else
            {
                Console.WriteLine("Aradiginiz isimde bir kayit bulunamadi.");
            }
        }
    }

else if (secim == "4")
    {
        Console.WriteLine("4 -> Kayit Numarasiyla Ara");
        Console.Write("Aranacak kayit numarasini girin:");
        int aranan_no=int.Parse(Console.ReadLine()?? "");
        
        for(int i=0; i<kayit_sayisi; i++)
        {
            if (kayit_numaralari[i] == aranan_no)
            {
                Console.WriteLine($"Musteri adi: {musteri_isimleri[i]}");
                Console.WriteLine($"Kayit No   : {kayit_numaralari[i]}");
                Console.WriteLine($"Ariza      : {arizalar[i]}");
                Console.WriteLine($"Durum      : {durum[i]}");

            }
            else
            {
                Console.WriteLine("Servis kaydi bulunamadi");
            }
        }
    }
else if (secim == "5")
    {
        Console.WriteLine("5 -> Servis Durumunu Guncelle");
        Console.Write("Guncellemek istediginiz kayit numarasini girin:");
      if (!int.TryParse(Console.ReadLine(), out int guncellenecek_no))
          {
        Console.WriteLine("Lutfen gecerli bir sayi giriniz.");
        continue;
          }

          bool kayit_bulundu=false;
        for(int i=0; i<kayit_sayisi; i++)
        {
            if (kayit_numaralari[i] == guncellenecek_no)
            {
                 kayit_bulundu=true;
                Console.WriteLine($"Mevcut durum: {durum[i]}");
                Console.WriteLine("\nDurumu ne yapmak istediginizi seciniz:");
                Console.WriteLine("1 - Bekliyor");
                Console.WriteLine("2-  İslemde  ");
                Console.WriteLine("3-  Tamamlandi");
                Console.WriteLine("4-  Teslim Edildi ");
                Console.Write("Secenek: ");

                string secenek=(Console.ReadLine() ?? "").Trim();
                bool guncenlendi=true;
                if (secenek.Trim() == "1")
                {
                    durum[i]="Bekliyor";
                } else if (secenek.Trim() == "2")
                {
                    durum[i]="İslemde";
                    
                }else if (secenek.Trim() == "3"){
                    durum[i]="Tamamlandi";
                
                    
                }else if (secenek.Trim() == "4")
                {
                    durum[i]="Teslim Edildi";

                }
                else
                {
                    Console.WriteLine("Gecersiz secim yaptiniz.");
                    guncenlendi=false;
                }

                if (guncenlendi)
                {
                    string[] yeniSatirlar= new string[kayit_sayisi];
                    for(int j=0; j < kayit_sayisi; j++)
                    {
                        yeniSatirlar[j]=kayit_numaralari[j] + "|" +
                              musteri_isimleri[j]+ "|" +
                              telefonlar[j] + "|" +
                              cihazlar[j]+ "|" +
                              arizalar[j] +"|" +
                              tarihler[j].ToString("dd.MM.yyyy") +"|"+
                              ucretler[j]+"|"+
                              durum[j];
                    }
                    File.WriteAllLines(DosyaAdi,yeniSatirlar);
                    Console.WriteLine("\nServis durumu basariyla guncellendi.");
                }
              break;

            }
        }
        if (!kayit_bulundu)
        {
            Console.WriteLine($"{guncellenecek_no} numarali kayit bulunamadi.");
        }
    }
else if (secim == "6")
    {
        Console.WriteLine("6 -> Servis Istatistikleri ");
        int bekliyor_count=0;
        int islemde_count=0;
        int tamamlandi_count=0;
        int teslimedildi_count=0;
        decimal total_ucret=0;

        for(int i=0; i < kayit_sayisi; i++)
        {
            if (string.Equals(durum[i].Trim(), "Bekliyor", StringComparison.OrdinalIgnoreCase))
                bekliyor_count++;
            else if (string.Equals(durum[i].Trim(), "İslemde", StringComparison.OrdinalIgnoreCase) || string.Equals(durum[i].Trim(), "Islemde", StringComparison.OrdinalIgnoreCase))
                islemde_count++;
            else if (string.Equals(durum[i].Trim(), "Tamamlandi", StringComparison.OrdinalIgnoreCase))
                tamamlandi_count++;
            else if (string.Equals(durum[i].Trim(), "Teslim Edildi", StringComparison.OrdinalIgnoreCase))
                teslimedildi_count++;
        }
        for(int i=0; i<kayit_sayisi; i++)
        {
            total_ucret+=ucretler[i];
        }

        Console.WriteLine($"Toplam Kayit: {kayit_sayisi}");
        Console.WriteLine($"Bekliyor:     {bekliyor_count}");
        Console.WriteLine($"Islemde:      {islemde_count}");
        Console.WriteLine($"Tamamlandi:   { tamamlandi_count}");
        Console.WriteLine($"Teslim Edildi:{teslimedildi_count}");
        Console.WriteLine($"Toplam servis bedeli: {total_ucret}");

        Console.WriteLine("\nAna menuye donmek icin herhangi bir tusa basin...");
        Console.ReadKey();
        
    }
else if(secim=="7")
    {
        calismaDurumu=false;
        Console.WriteLine("Program kapatiliyor.");
    }
    else
    {
        Console.WriteLine("Gecersiz islem.");
    }
}







