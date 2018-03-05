using System;
using System.Collections.Generic;
using System.Text;

public interface ILieutenant : IPrivate
{
    IReadOnlyCollection<ISoldier> Privates { get; }
    void AddPrivate(ISoldier soldier);
}

