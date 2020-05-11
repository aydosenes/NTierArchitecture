using Test.Core.EntityPointer;

namespace Test.Core.Entities
{ 
    public class SubTest : IEntity
    {
        
        public int SubTestId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public bool IsDeleted { get; set; }

        //[ForeignKey("Id")]
        public int UpTestId { get; set; }
        public virtual UpTest UpTest { get; set; }
    }
}
