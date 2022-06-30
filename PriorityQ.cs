using System.Collections.Generic;

namespace YeniProje
{
    //İnt tipinde değerleri kendinde tutan Öncelikli Kuyruk sınıfı yazılmıştır.
    //PriorityQueue sınfında farkı Silme işleminin artan sırada yapılmasıdır.
    public class PriorityQ
    {
        
        public int maxSize;
        public List<int> array;
        public int nItems;

        public PriorityQ(int s)
        {
            maxSize = s;
            array = new List<int>(maxSize);
            nItems = 0;
        }


        public void Ekle(int item)
        {
            array.Add(item);
            nItems++;

        }

        public int Sil()//verilen dizide en az değere sahip elemanı döndürüryor.
        {
            
            int temp =array[0];
            int minUrun = temp;
            foreach (int urun in array)
            {

                if (urun<=minUrun )
                {
                    minUrun = urun;
                    temp = urun;
                }
            }
            array.Remove(temp);
            nItems--;               
            return temp;            

        }

        
        public bool BosMu()

        { return (nItems==0); }
        
        
    }


       
        
       
 }

       
  
