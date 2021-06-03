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

The *KeyboardShortcut.Value.IsUp()* is a simplistic check which checks if the key and modifier (if any) have been pressed. For example, if LEFT CTRL and S have been pressed. However, it does not check for absence of other modifiers. This means LEFT CTRL + LEFT SHIFT + S would also trip the condition. This is typically not ideal because it prevents the same key from being used with other modifiers. The following code does a strict evaluation of the shortcut and returns true only if the specified keys are pressed but no other modifiers keys are pressed:

```C#
public bool StrictKeyCheck(KeyboardShortcut check)
{
  // Check main key
  if(!check.IsUp()) { return false; }
  // Check that specified modifiers are pressed while all other modifiers are not pressed
  foreach (KeyCode modifier in new KeyCode[]{KeyCode.LeftAlt, KeyCode.RightAlt, KeyCode.LeftControl, KeyCode.RightControl, KeyCode.LeftShift, KeyCode.RightShift })
  {
    if (Input.GetKey(modifier) != check.Modifiers.Contains(modifier)) { return false; }
  }
  return true;
}
```
