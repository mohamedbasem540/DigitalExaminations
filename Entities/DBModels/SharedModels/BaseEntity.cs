﻿using Entities.Contracts;

namespace Entities.DBModels.SharedModels
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DisplayName(nameof(Id))]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName(nameof(CreatedAt))]
        public DateTime CreatedAt { get; set; }

        [DisplayName(nameof(CreatedAt))]
        public string CreatedAtString => CreatedAt.ToString("f");
    }
}
