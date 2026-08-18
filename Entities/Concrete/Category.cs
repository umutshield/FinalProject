using Core.Entities;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın standartı: eğerki bir class herhangi bir inheritance veya interface implementasyonu almıyorsa 
    //ileride bir sıkıntı yaşayacaksın demektir. işte biz bu varlıkları gruplamaya çalışırız. 
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
