using System;
namespace Edge.SVA.Model.Domain
{
    public interface IKeyValue
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}
