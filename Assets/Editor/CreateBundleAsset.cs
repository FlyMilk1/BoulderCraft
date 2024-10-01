using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateAssetBundles
{
	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
  	    string assetBundleDirectory = Application.streamingAssetsPath + "/GameItemsFolder";
  	    if (!Directory.Exists(assetBundleDirectory))
  	    {
    	    Directory.CreateDirectory(assetBundleDirectory);
  	    }
  	    BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
	}
}
