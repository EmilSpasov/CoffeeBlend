namespace CoffeeBlend.Data.Models
{

    using CoffeeBlend.Data.Common.Models;

    public class Gallery : BaseDeletableModel<int>
    {
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
