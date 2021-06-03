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
        /// Awake - Executed Once On Plugin Load
        /// </summary>
        void Awake()
        {
            // Config.Bind("Section","Name","Default value");
            KeyboardShortcut = Config.Bind("Hotkeys", "Load Image Shortcut", new KeyboardShortcut(KeyCode.F1));
            text = Config.Bind("Hotkeys", "Clear Image Shortcut", "default string");
            someNumber = Config.Bind("Scale", "Scale Size", 40);
        }

        /// <summary>
        /// Update - Executed Periodically While Plugin Is Running
        /// </summary>
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

When the plugin is run for the first time, R2ModMan will create a corresponding configuration for the plugin using the default setting provided in the Config.Bind code. You can then access this configuration using the Config Editor link in R2ModMan.