Update:

The preferred way of loading AssetBundles is to use the FileAccessPlugin because this allows the assetBundle to be read from any location that FileAccessPlugin searches which means you can just provide the assetBundle name without worrying about the full poath location. The rest of the code, however, remains the same.

Original:

The following code can be used to load assetBundles at runtime and get an instance of objects within. The example gets a reference to a GameObject
but I believe the same process should work for other object types. Please note that the latest version of Unity do not allow direct loading of
components. You must instance a GameObject and then access the component with GetComponent<>.

```C#
Debug.Log("Loading AssetBundle...");
var myLoadedAssetBundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(*path*, *assetBundleFileName*));

if (myLoadedAssetBundle != null)
{
  Debug.Log("Referencing Prefab...");
  var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(*objectName*);
  Debug.Log("Instancing Prefab...");
  GameObject go = Instantiate(prefab);
}
else
{
   Debug.Log("Failed to load AssetBundle!");
   return;
}
```

You can also get access to content in an assetBundle, such as a Texture, via:

```
spriteAssetBundle = AssetBundle.LoadFromFile($"{bundlePath}");
return spriteAssetBundle.LoadAsset<Texture2D>("icon.png");
```
