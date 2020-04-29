using System;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Core.EntityPointer;

namespace Test.Core.Entities
{
    public class TestModel : IEntity
    {
        //public TestModel()
        //{
        //    SubTestModels = new SubTestModel();
        //}

        public int Id { get; set; }
        public long IdentityNo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool isDeleted { get; set; }
        public virtual SubTestModel SubTestModels { get; set; }

        [NotMapped]
        public string EncryptedId { get; set; }
       
    }
}
