using Test.Core.EntityPointer;

namespace Test.Core.Entities
{ 
    public class SubTestModel : IEntity
    {
        
        public int SubTestModelId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public bool isDeleted { get; set; }

        //[ForeignKey("Id")]
        public int TestModelId { get; set; }
        public virtual TestModel TestModel { get; set; }
    }
}
