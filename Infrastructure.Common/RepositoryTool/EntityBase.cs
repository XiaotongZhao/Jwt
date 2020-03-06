using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Common.RepositoryTool
{
    public abstract class EntityBase<TKey>
    {
        protected EntityBase()
        {
            CreatedOn = DateTime.Now;
        }
        public TKey Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? LastModifyOn { get; set; }
    }
}
