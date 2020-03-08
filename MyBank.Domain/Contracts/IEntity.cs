using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Contracts
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
