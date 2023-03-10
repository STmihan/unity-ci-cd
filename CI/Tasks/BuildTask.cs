using Cake.Common;
using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Unity;

namespace Build.Tasks;

[TaskName("Build")]
public class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var type = context.Argument("type", "PC");
        context.Information($"Building {type}...");
        var unityEditor = context.FindUnityEditor(2020, 3, 44);
        context.UnityEditor(
            unityEditor.Path,
            new UnityEditorArguments
            {
                ExecuteMethod = Constants.ExecuteMethod,
                ProjectPath = $"../src/{Constants.ProjectName}",
                LogFile = $"../build-{type}.log",
                SetCustomArguments = context.SetCustomArguments,
            },
            new UnityEditorSettings
            {
                RealTimeLog = true,
            }
        );
    }
}