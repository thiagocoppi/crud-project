using System;

namespace Domain.Base
{
    public abstract class BaseEntity : ValidatorDomain
    {
        public Guid Id { get; set; }
    }
}