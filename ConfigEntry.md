Mods are customizable to utilize config entries that allows the end user to tune their preference for their mod.
The config files are not saved until the first time the mod runs awake method. This bind feature also pulls the
user's saved bind back into the application. 

```csharp
[BepInPlugin(Guid, "AwesomePlugin", Version)]
public class AwesomePlugin: BaseUnityPlugin
    {
        // Configs
        private ConfigEntry<KeyboardShortcut> KeyboardShortcut { get; set; }
        private ConfigEntry<string> text { get; set; }
        private ConfigEntry<int> someNumber { get; set; }

        /// <summary>
        /// Awake plugin
        /// </summary>
        void Awake()
        {
            // Config.Bind("Section","Name","Default value");
            KeyboardShortcut = Config.Bind("Hotkeys", "Load Image Shortcut", new KeyboardShortcut(KeyCode.F1));
            text = Config.Bind("Hotkeys", "Clear Image Shortcut", "default string");
            someNumber = Config.Bind("Scale", "Scale Size", 40);

            // Load mod name+version into main menu
            ModdingTales.ModdingUtils.Initialize(this, Logger);
            // Load PUP
            PhotonUtilPlugin.AddMod(Guid);
        }

        void Update(){
          if (KeyboardShortcut.Value.IsUp()){
            // Do Something
          }
        }
}
```

To allow extra keys you can pass them like this for keyboard shortcuts.
```csharp
    new KeyboardShortcut(KeyCode.P, KeyCode.LeftControl)
```
