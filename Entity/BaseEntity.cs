using System;
using System.ComponentModel.DataAnnotations;

namespace ApiFastReport.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        private DateTime? _createdAt;
        public DateTime? CreateAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdatedAt { get; set; }
    }
}