using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;
using System.Collections.Generic;

public class PostProcessBuildSteps : MonoBehaviour
{
#if UNITY_IOS
    [PostProcessBuild]
    static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        // Read plist
        var plistPath = Path.Combine(path, "Info.plist");
        var plist = new PlistDocument();
        plist.ReadFromFile(plistPath);
 
        // Update value
        PlistElementDict rootDict = plist.root;
        rootDict.SetString("NSMotionUsageDescription", "Used for Steps Count");
 
        // Write plist
        File.WriteAllText(plistPath, plist.WriteToString());
    }
#endif
}