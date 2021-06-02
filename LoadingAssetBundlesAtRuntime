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
