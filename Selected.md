# Determine The Selected Mini

To determine the selected mini (CreatureBoardAsset), one can track what mini was picked up. This can be done using code similar to:


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

Alternatively if you just want to know the CreatureId that is selcted, you can use:

````C#
(NGuid)LocalClient.SelectedCreatureId.Value
````
