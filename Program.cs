using System;
using System.Collections;
using System.Collections.Generic;

namespace YeniProje
{
    
    internal class Program
    {
        static Random random = new Random();

        public static void Main(string[] args)
        {
            //Ekranın arkaplanını beyaz ve yazı rengini siyaha çevrilmesi
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            
            //gerekli mahalle, teslimat sayı ve yemek listeleri tanımlanıyor.
            string[] MahalleAdi =
                {"Özkanlar", "Evka 3", "Atatürk", "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene"};
            
            int[] teslimatSayısı = {5, 2, 7, 2, 7, 3, 0, 1};
            
            string[] Yemekler = {"Doner","Pizza","Kebap","Karniyarik","Pilav","Corba","Lahmacun","Makarna",
                "Manti","Pide","Turlu","Kofte","Hamburger"};
            
            //ArrayList oluşturalarak yazmış olduğum Ekle metotu ile listeye ekleme yapılıyor.
            ArrayList array = new ArrayList();
            ElemanEkle(array,MahalleAdi,teslimatSayısı,Yemekler);

            //Yığıt, Kuyruk ve Öncelikli Kuyruk oluşturuluyor.
            Stack  stack = new Stack(MahalleAdi.Length);
            Queue<Mahalle> queue = new Queue<Mahalle>(MahalleAdi.Length);
            PriorityQueue q = new PriorityQueue(MahalleAdi.Length);
            
            //Yığıt, Kuyruk ve Öncelikli Kuyruka mahalle sınfının nesneleri ekleniyor.

            foreach (Mahalle mahalle in array)
            {
                stack.push(mahalle);
                queue.insert(mahalle);
                q.Ekle(mahalle);
            }

            Console.WriteLine("\nYığıt:\n");
            //Son giren ilk çıkacak biçimde yığıttaki elemanlar silinerek ekrana yazdırılıyor.

            while (!stack.isEmpty())
            {
                Mahalle mahalle = stack.pop();
                Yazdir(mahalle);

            }
            
            Console.WriteLine("\nKuyruk:\n");
            //İlk giren ilk çıkar biçimde kuyruktakı elemanlar silinerek ekrana yazdırılıyor.

            while (!queue.isEmpty())
            {
                Mahalle temp = queue.remove();
                Yazdir(temp);

            }
            
           Console.WriteLine("\nÖncelikli Kuyruk:\n");
            //Teslimat sayısı çoktan aza doğru elemanlar silinerek ekrana yazdırılıyor.
           
           while (!q.BosMu())
           {
               Mahalle temp1 = q.Sil();
               Console.Write("{0,10}",temp1.MahalleAdi);
               Console.WriteLine( " / Teslimat Sayisi: "+ temp1.GenericListe.Count);
               

           }

           Console.WriteLine("\nİşlem Tamamlama Sürelerinin Bulunması:\n");

           int[] kasa = {6, 7, 2, 1, 12, 5, 3, 7, 4, 2};
           //İnt tipindeki Kuyruk ve Öncelik Kuyrugu nesneleri oluşturuluyor
           Queue<int> kuyruk = new Queue<int>(kasa.Length);
           PriorityQ oncelikliKuyruk = new PriorityQ(kasa.Length);
           
           //yukarda yazmış olduğumuz dizideki elemanlar kuyruklara ekleniyor.
           foreach (int urun in kasa)
           {
               kuyruk.insert(urun);
               oncelikliKuyruk.Ekle(urun);
           }
           
           //her kuyruk icin islem sureleri ve toplam ortalama sure bulunuyor.
           int musteriSay = 1;
           double toplam = 0;
           int islemSuresi = 0;

           while (!kuyruk.isEmpty())
           {
               int temp = kuyruk.remove();
               islemSuresi += temp*3;
               Console.WriteLine(musteriSay+ ".müşterinin işlem tamamlama süresi: " +islemSuresi + " saniye");               
               toplam += islemSuresi;
               musteriSay++;

           }
           Console.WriteLine("\n-Kasa için ortalama işlem tamamlanma süresi: "+toplam/kasa.Length +"\n" +
                             "-------------------------------------------------------");
           int sure = 0;
           int say = 1;
           double topSure = 0;
           while (!oncelikliKuyruk.BosMu())
           {
              int temp = oncelikliKuyruk.Sil();
              sure += temp*3;
              Console.WriteLine(say+ ".müşterinin işlem tamamlama süresi: " +sure + " saniye");              
              topSure += sure;
              say++;

           }
           Console.WriteLine("\n-Kasa için ortalama işlem tamamlanma süresi: "+topSure/kasa.Length);

          
        }

        //kod tekrarını azaltmak için Yığıt ve Kuyruk elemanlarını sildikten sonra mahalle bilgilerini ekrana yazdıran metot yazdım. 
        public static void Yazdir(Mahalle eleman)
        {
            Console.WriteLine(eleman.MahalleAdi + " / Teslimat Sayisi: " +eleman.GenericListe.Count);
            foreach (Teslimat liste in eleman.GenericListe)
            {
                Console.WriteLine(liste.YemekAdi +"," +liste.yemekAdeti);
            }
            Console.WriteLine("------------------------");
        }
        
      
       //ArrayListe eleman ekleme için metot
        public static void ElemanEkle(ArrayList array,string[] mahalleAdi,int[] teslimatSayisi,string[] yemekler)
        {
            int elemanSayi = 0;
            int teslimatSayi = 0;
            //Mahalle sayısı kadar generic listeye oluşturuluyor.
            for (int i = 0; i < mahalleAdi.Length; i++)
            {
                elemanSayi++;//mahalle sayı hesablanıyor. (Dizideki eleman sayı)
                List<Teslimat> generic = new List<Teslimat>();
                //her mahalledeki teslimat sayısına uygun olarak teslimat nesneleri oluşturularak genericlisteye ekleniyor.
                for (int j = 0; j < teslimatSayisi[i]; j++)
                {   
                    Teslimat teslimat = new Teslimat(yemekler[random.Next(0,yemekler.Length)],random.Next(1,101));
                    generic.Add(teslimat);
                    teslimatSayi++; //toplam teslimat sayııs hesablanıyor.

                }
                //her mahalle için mahalle nesnesi oluşturularak ArrayListe ekleniyor.
                Mahalle mahalle = new Mahalle(mahalleAdi[i],generic);
                array.Add(mahalle);
            }
            //her mahalle için bilgiler ekrana yazdırılıyor
            Console.WriteLine("Mahalle Bilgileri:\n");
            foreach (Mahalle mahalle in array)
            {
                Yazdir(mahalle);
            }
            //Veri yapısındakı toplam eleman ve teslimat sayısı ekrana yazdırılıyor.
            Console.WriteLine("\nDinamik Dizide eleman sayi: " + elemanSayi);
            Console.WriteLine("\nBileşik Veri Yapısındaki toplam teslimat sayısı: " + teslimatSayi);
        }
    }
}