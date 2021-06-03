The following code can be used to obtain a CreatureBoardAsset from a CreatureId:

```C#
CreatureBoardAsset asset;
CreaturePresenter.TryGetAsset(cid, out asset);
if(asset!=null)
{
  // Do something with the asset
}
```
The CreatureBoardAsset can then be used to obtain all of the creature data using
the Creature proeprty, such as:

```C#
CreatureBoardAsset asset;
CreaturePresenter.TryGetAsset(cid, out asset);
if(asset!=null)
{
   Debug.Log(asset.Creature.Name);
   Debug.Log(asset.Creature.Hp);
   Debug.Log(asset.Creature.Flying);
   Debug.Log(asset.Creature.Stat0);
   Debug.Log(asset.Creature.Stat1);
   Debug.Log(asset.Creature.Stat2);
   Debug.Log(asset.Creature.Stat3);
}
```

To obtain the CreatureBoardAsset for the currently select mini use:

```C#
CreatureBoardAsset asset;
CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
if(asset!=null)
{
  // Do something with the asset
}
```

   
