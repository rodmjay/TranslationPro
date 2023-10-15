#region Header

// /*
// Copyright (c) 2021 . All rights reserved.
// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Enums;
using TemplateBase.Common.Data.Interfaces;
using TemplateBase.Common.Validation;

namespace TemplateBase.Common.Data.Bases
{
    public abstract class BaseEntity : ValidatableModel, IObjectState
    {
        [NotMapped] [IgnoreDataMember] public ObjectState ObjectState { get; set; }
    }

    public abstract class BaseEntity<T> : BaseEntity, IEntityTypeConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}