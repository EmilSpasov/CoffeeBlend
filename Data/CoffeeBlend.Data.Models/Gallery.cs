namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Common.Models;

    public class Gallery : BaseDeletableModel<int>
    {
        public Gallery()
        {
            this.Images = new HashSet<Image>();
        }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}
