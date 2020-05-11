using System;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Core.EntityPointer;

namespace Test.Core.Entities
{
    public class UpTest : IEntity
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
        public bool IsDeleted { get; set; }
        public virtual SubTest SubTest { get; set; }

        [NotMapped]
        public string EncryptedId { get; set; }
       
    }
}
