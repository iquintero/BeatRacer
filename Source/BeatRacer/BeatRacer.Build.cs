// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class BeatRacer : ModuleRules
{
	public BeatRacer(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "PhysXVehicles", "HeadMountedDisplay" });

		PublicDefinitions.Add("HMD_MODULE_INCLUDED=1");

        var basePath = Path.GetDirectoryName(RulesCompiler.GetFileNameFromType(GetType()));
        string thirdPartyPath = Path.Combine(basePath, "..", "..", "Thirdparty");


        // Add FMOD audio libraries
        PublicIncludePaths.Add(Path.Combine(thirdPartyPath, "FMOD", "Includes"));

        switch (Target.Platform)
        {
            case UnrealTargetPlatform.Win64:
                PublicLibraryPaths.Add(Path.Combine(thirdPartyPath, "FMOD", "Libraries", "Win64"));
                PublicAdditionalLibraries.Add("fmod64_vc.lib");
                string fmodDllPath = Path.Combine(thirdPartyPath, "FMOD", "Libraries", "Win64", "fmod64.dll");
                RuntimeDependencies.Add(new RuntimeDependency(fmodDllPath));

                string binariesDir = Path.Combine(basePath, "..", "..", "Binaries", "Win64");
                if (!Directory.Exists(binariesDir))
                    System.IO.Directory.CreateDirectory(binariesDir);

                string fmodDllDest = System.IO.Path.Combine(binariesDir, "fmod64.dll");
                CopyFile(fmodDllPath, fmodDllDest);
                PublicDelayLoadDLLs.AddRange(new string[] { "fmod64.dll" });

                break;
            default:
                throw new System.Exception(System.String.Format("Unsupported platform {0}", Target.Platform.ToString()));
        }

    }

    private void CopyFile(string source, string dest)
    {
        System.Console.WriteLine("Copying {0} to {1}", source, dest);
        if (System.IO.File.Exists(dest))
        {
            System.IO.File.SetAttributes(dest, System.IO.File.GetAttributes(dest) & ~System.IO.FileAttributes.ReadOnly);
        }
        try
        {
            System.IO.File.Copy(source, dest, true);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Failed to copy file: {0}", ex.Message);
        }
    }

}
