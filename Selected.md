# Determine The Selected Mini

If you want to know the CreatureId of the selected asset, you ca use:

````C#
(NGuid)LocalClient.SelectedCreatureId.Value
````

If you need to get the CreatureBoardAsset from this, you can:

````C#

CreatureBoardAsset selectedMini = null;
CreatureBoardAsset[] assets = CreaturePresenter.AllCreatureAssets.ToArray();
foreach (CreatureBoardAsset asset in assets)
{
  if ((NGuid)LocalClient.SelectedCreatureId.Value == (NGuid)asset.Creature.CreatureId.Value)
  {
    selectedMini = asset;
    break;
  }
}
````

Alternatively, you can track the selected asset by monitoring the pickup 'event' such as:

````C#
CreatureBoardAsset selectedMini = null;
void Update()
{
    // Ensure that there is a board session manager instance
    if (BoardSessionManager.HasInstance)
    {
        // Ensure that there is a board
        if (BoardSessionManager.HasBoardAndIsInNominalState)
        {
            // Ensure that the board is not loading
            if (!BoardSessionManager.IsLoading)
            {
                CreatureMoveBoardTool moveBoard = SingletonBehaviour<BoardToolManager>.Instance.GetTool<CreatureMoveBoardTool>();
                var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
                CreatureBoardAsset asset = (CreatureBoardAsset)typeof(CreatureMoveBoardTool).GetField("_pickupObject", flags).GetValue(moveBoard);
                if (asset != null) { selectedMini = asset; }
            }
        }
    }
}
````
