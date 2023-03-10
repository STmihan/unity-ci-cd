using UnityEditor;
using UnityEngine;

namespace Editor.Builds
{
    public static class Builder
    {
        public static void BuildType()
        {
            var options = BuildUtils.ParseBuildConfigPath();
            
            switch (options.Type)
            {
                case "pc":
                    BuildPCWindows();
                    break;
                case "webgl":
                    BuildWebGL();
                    break;
                default:
                    BuildPCWindows();
                    break;
            }
        }
        
        [MenuItem("Builds/PC")]
        public static void BuildPCWindows()
        {
            var options = BuildUtils.ParseBuildConfigPath();

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = BuildUtils.FindEnabledEditorScenes(),
                locationPathName = $"{options.OutPath}/{options.Type}/{options.TargetName}",
                options = options.Options,
                target = BuildTarget.StandaloneWindows64,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }

        [MenuItem("Builds/WebGL")]
        public static void BuildWebGL()
        {
            var options = BuildUtils.ParseBuildConfigPath();

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = BuildUtils.FindEnabledEditorScenes(),
                locationPathName = $"{options.OutPath}/{options.Type}/{options.TargetName}",
                options = options.Options,
                target = BuildTarget.WebGL,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
    }
}