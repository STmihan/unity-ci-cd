using Cake.Common;
using Cake.Core;
using Cake.Frosting;

namespace Build;

public class BuildContext : FrostingContext
{
    public string Type { get; }

    public BuildContext(ICakeContext context)
        : base(context)
    {
        Type = context.Argument("type", "PC");
    }
    
    public void SetCustomArguments(dynamic obj)
    {
        obj.type = Type;
        obj.target = Constants.ProjectName;
    }
}