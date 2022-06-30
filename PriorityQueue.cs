using System;
using System.Collections.Generic;

namespace YeniProje
{
    //Mahalle sınıfında nesneleri kendinde tutan Öncelikli Kuyruk sınıfı yazılmıştır.
    //Silme işlemi azalan sırada teslimat sayısına göre silinmektedir.
    public class PriorityQueue
    {
        public int maxSize;
        public List<Mahalle> queArray;
        public int nItems;

        public PriorityQueue(int s)//yapılandırıcı metot
        {
            maxSize = s;
            queArray = new List<Mahalle>(maxSize);
            nItems = 0;
        }


        public void Ekle(Mahalle item)//eleman ekleme metotu. GenericListenin hazır metotou olan Add kullanılmıştır. 
        {
            queArray.Add(item);
            nItems++;
        }

        public Mahalle Sil()//Silme metotu. Elemanlar azalan sırada teslimat sayısına göre silinmektedir.
        {
            Mahalle temp =queArray[0];
            int maxTeslimat = 0;
            //her mahelle için teslimat sayıları belli edilib, en çok teslimat sayısı olan mahelle silinmektedir.
            foreach (Mahalle mahalle in queArray)
            {

                foreach (Teslimat genericList in mahalle.GenericListe)
                    
                if (mahalle.GenericListe.Count>=maxTeslimat )
                {
                    maxTeslimat = mahalle.GenericListe.Count;
                    
                    temp = mahalle;
                }
            }
            queArray.Remove(temp);
            nItems--;               
            return temp;

        }
        
        public bool BosMu()

        { return (nItems==0); }
        
        
    }

    
}