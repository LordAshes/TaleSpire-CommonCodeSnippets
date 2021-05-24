# Speak Through An Creature Asset Locally (On Seen On One Client):

To speak through an creature asset (mini) only on the one client, we first need to get a reference to the mini's CreatureBoardAsset. There are multipe ways to do this including,
but not limited to, getting the last selected mini or getting a mini by creature name. See the corresponding code snippets for either of those options.

````C#
CreatureBoardAsset asset;
string msg = "Hello Everyone!";
...
asset.Creature.Speak(msg);
````

# Speak Through An Asset On All Clients:

To speak through an asset so that all clients see it, the ChatManager is used. This will speak though the asset and also put the corresponding speach in the chat.
To speak through a creature, you need to get the creature's CreatureBoardAsset. There are multipe ways to do this including, but not limited to, getting the last
selected mini or getting a mini by creature name. See the corresponding code snippets for either of those options.

````C#
CreatureBoardAsset asset;
string msg = "Hello Everyone!";
...
ChatManager.SendChatMessage(msg, asset.Creature.CreatureId);
````

To speak as a player, use the PlayerId instead. This can be obtained from LocalPlayer such as:

````C#
CreatureBoardAsset asset;
string msg = "Hello Everyone!";
...
ChatManager.SendChatMessage("Hello", LocalPlayer.Id.Value);
````





