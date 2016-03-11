
namespace ThreeAmigosStoreServices.Models
{
    public class CategoryModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }
    }
}
