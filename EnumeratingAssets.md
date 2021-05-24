# To List All The CreatureBoardAssets (Minis):

````C#
CreatureBoardAsset[] assets = CreaturePresenter.AllCreatureAssets.ToArray();
foreach (CreatureBoardAsset asset in assets)
{
  // Do something with the asset or use asset.Creature to access the related creature information
}
````
