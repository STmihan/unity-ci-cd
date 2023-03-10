using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Editor.Builds
{
    public static class BuildUtils
    {
        public class BuildOptionsWrapper
        {
            public BuildOptions Options { get; set; } = BuildOptions.None;
            public string Version { get; set; } = "0.0.0";
            public string OutPath { get; set; } = "Builds";
            public string TargetName { get; set; } = "Biped.exe";
            public string Type { get; set; } = "";
        }

        public static BuildOptionsWrapper ParseBuildConfigPath()
        {
            BuildOptionsWrapper options = new BuildOptionsWrapper();
            string[] args = Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("--options"))
                {
                    string[] op_array = args[i + 1].Split('|');
                    foreach (var op in op_array)
                    {
                        options.Options |= (BuildOptions)Enum.Parse(typeof(BuildOptions), op);
                    }
                }
                else if (args[i].Contains("--version"))
                {
                    options.Version = args[i].Split('=')[1];
                }
                else if (args[i].Contains("--path"))
                {
                    options.OutPath = args[i].Split('=')[1];
                }
                else if (args[i].Contains("--target"))
                {
                    options.TargetName = args[i].Split('=')[1];
                }
                else if (args[i].Contains("--type"))
                {
                    options.Type = args[i].Split('=')[1];
                }
            }
            
            Debug.Log($"Options: {options.Options}");
            Debug.Log($"Version: {options.Version}");
            Debug.Log($"Path: {options.OutPath}");
            Debug.Log($"Target: {options.TargetName}");
            Debug.Log($"Type: {options.Type}");

            return options;
        }

        public static string[] FindEnabledEditorScenes()
        {
            List<string> editorScenes = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled)
                {
                    continue;
                }

                if (scene.path.IndexOf("ART") >= 0 || scene.path.IndexOf("DEV") >= 0)
                {
                    continue;
                }

                editorScenes.Add(scene.path);
            }

            return editorScenes.ToArray();
        }
    }
}