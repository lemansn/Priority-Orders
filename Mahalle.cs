using System.Collections.Generic;

namespace YeniProje
{
    //Mahalle sınıfı ve yapılandırırcı metotu yazılıyor. Parametre olarak mahalle ismi ve Teslimat nesneleri tutmak için generic liste kullanılmıştır.
    public class Mahalle
    {
        public string MahalleAdi;
        public List<Teslimat> GenericListe { get; }


        public Mahalle(string MahalleAdi,List<Teslimat> GenericListe)
        {
            this.MahalleAdi = MahalleAdi;
            this.GenericListe = GenericListe;

        }
        
        
    }
    
    
}