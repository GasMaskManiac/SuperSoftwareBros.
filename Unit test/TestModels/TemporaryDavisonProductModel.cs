namespace Three_Amigos.Models
{
    public class TemporaryDavisonProductModel
    {
        public virtual int Id { get; set; }
        public virtual string Ean { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual int BrandId { get; set; }
        public virtual string BrandName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
    }
}