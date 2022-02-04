using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

using UnityEngine;

/// <summary>
/// 
/// Notes:
/// 
/// 1. Try to keep this main page simple with just the Unity/TS methods like Awake() and Update() methods
/// 2. Place your processing code in class specific files or a general class file like the sample Handler.cs file
/// 3. You can make your additional class file part of the main plugin class by making them "public partial class TemplatePlugin : BaseUnityPlugin"
///    (See the sample Handler.cs and/or Unity.cs files for an example)
/// 
/// </summary>

namespace LordAshes
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(LordAshes.FileAccessPlugin.Guid)]
    [BepInDependency(LordAshes.StatMessaging.Guid)]
    [BepInDependency(RadialUI.RadialUIPlugin.Guid)]
    public partial class TemplatePlugin : BaseUnityPlugin
    {
        // Plugin info
        public const string Name = "Template Plug-In";                      // Update plugin name (and give the same name under Project | Properties)
        public const string Guid = "org.{username}.plugins.template";       // Update user name and plugin id (usually changing 'template' to name of plugin)
        public const string Version = "1.0.0.0";                            // Update version as appropriate (and use same version under Project | Properties | Assembly Information)

        // Configuration
        private ConfigEntry<KeyboardShortcut> triggerKey { get; set; }      // Sample configuration for triggering a plugin via keyboard
        private ConfigEntry<UnityEngine.Color> baseColor { get; set; }      // Sample configuration for storing/retrieving a color
        private ConfigEntry<string> baseText { get; set; }                  // Sample configuration for storing/retrieving a string (could be most other data types)

        // Reference to the TaleSpire_CustomData folder used by a lot a plugins.
        // This reference is usually no longer needed if you are using the FileAccessPlugin (which is highly recommended) 
        private string dir = UnityEngine.Application.dataPath.Substring(0, UnityEngine.Application.dataPath.LastIndexOf("/")) + "/TaleSpire_CustomData/";

        /// <summary>
        /// Function for initializing plugin
        /// This function is called once by TaleSpire
        /// </summary>
        void Awake()
        {
            // Not required but good idea to log this state for troubleshooting purpose
            UnityEngine.Debug.Log("Template Plugin: Lord Ashes Template Plugin Is Active.");

            //
            // (Optional) Read Configruation:
            //
            // Read configuration providing defaults if the configuration does not exist.
            // If configuration does not exist it will be created automatically with the given default value)
            //

            // The Config.Bind() format is category name, setting text, default
            triggerKey = Config.Bind("Hotkeys", "States Activation", new KeyboardShortcut(KeyCode.S, KeyCode.LeftControl));
            baseColor = Config.Bind("Appearance", "Base Text Color", UnityEngine.Color.black);
            baseText = Config.Bind("Appearance", "Base Text", "Happy Birthday!");

            //
            // (Optional) Register A Radial Main
            //

            // Ensures that the indicated menu exist at the root of the character menu
            // (This allows multiple plugins to use the same root level radial menu)
            RadialUI.RadialSubmenu.EnsureMainMenuItem(  RadialUI.RadialUIPlugin.Guid + ".Info",
                                                        RadialUI.RadialSubmenu.MenuType.character, "Info",
                                                        FileAccessPlugin.Image.LoadSprite("Info.png")
                                                     );

            // Register a radial sub-menu with a resulting action
            RadialUI.RadialSubmenu.CreateSubMenuItem(   RadialUI.RadialUIPlugin.Guid + ".Info",
                                                        "Icons",
                                                        FileAccessPlugin.Image.LoadSprite("States.png"),
                                                        (cid, menu, mmi) => { SetRequest(cid); },
                                                        false,
                                                        null
                                                    );

            //
            // (Optional) Subscribing To Network Messages
            //

            // Subscribe to Stat Messages related to the given key.
            // Typically the plugin Guid is used as the given to so that the plugin gets only messages to this specific plugins.
            // However, there are exceptions to this rule. Some plugins require more than one key in which case the Guid is
            // usually suffixed with a dot and an extension text (e.g. TemplatePlugin.Guid+".reset"). In other cases a plugin
            // may subscribe to the Guid of another plugin if the messages are intended to communicate from one plugin to another.
            StatMessaging.Subscribe(TemplatePlugin.Guid, HandleRequest);

            //
            // (Optional) Post plugin on the TaleSpire main page
            //

            // This places the plugin name on the main page of TaleSpire. The current convention is to place a plugin on the
            // main page only if it provides the user with some end functionality. If the plugin is a dependency plugin which
            // does not provide any user functionality by it self, it should not be shown on the front page. For example, CMP
            // can be used as a dependency plugin but it provides some user fucntionality directly, so it is displayed on the
            // main page. FileAccessPlugin, on the other hand, only provide file access for other plugins and thus is not listed
            // on the main page.
            Utility.PostOnMainPage(this.GetType());

            //
            // (Optional) This is Required if Patches are being used
            //
            
            // This tells harmony to enable your patches at runtime. On Awake will generally give the system enough time
            // To patch the methods before they are called within the unity engine.
            new Harmony(Guid).PatchAll();
        }

        /// <summary>
        /// Function for determining if view mode has been toggled and, if so, activating or deactivating Character View mode.
        /// This function is called periodically by TaleSpire.
        /// </summary>
        void Update()
        {
            // Can be used to determine if a board is loaded
            // Beware: Board loaded does not necessarily mean all the minis have properly loaded and are accessible
            if (Utility.isBoardLoaded())
            {
                // Proper way to check for keyboard combinations. This not only tests for the required keys but it also checks
                // for not required keys. For example, if the required keys are LCTRL+M then LCTRL+SHIFT+M will not result in
                // a true check. Using the regular Unity Input check or even the triggerKey.Value.IsUp() resulst the check being
                // true even if other modifiers are being pressed.
                if (Utility.StrictKeyCheck(triggerKey.Value))
                {

                }
            }
        }
    }
}
