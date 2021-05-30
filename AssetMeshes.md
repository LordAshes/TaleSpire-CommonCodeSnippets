# Asset Meshes

Sometimes it is desirable to get from a CreatureBoardAsset or CreatureId to the base and creature mesh game object.
This is typically useful when you want to modify the meshes on the fly.

## CreatureBoardAsset to Creature Mesh Game Object 

````C#
CreatureBoardAsset asset;
GameObject go = asset.CreatureLoader.LoadedAsset();
MeshFilter mf = go.GetComponent<MeshFilter>();
MeshRenderer mr = go.GetComponent<MeshRenderer>();
````

Obviously in the above code, one would need to set the value of 'asset' from something first.

## CreatureId to Creature Mesh Game Object 

````C#
CreatureBoardAsset asset;
CreaturePresenter.TryGetAsset(LocalClient.LocalClient.SelectedCreatureId, out asset);
if(asset!=null)
{
  GameObject go = asset.CreatureLoader.LoadedAsset();
  MeshFilter mf = go.GetComponent<MeshFilter>();
  MeshRenderer mr = go.GetComponent<MeshRenderer>();
}
````

The above code sets the CreatureId base on the currently selected creature but the CreatureId could be generated any other way.
