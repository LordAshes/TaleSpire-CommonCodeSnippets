using BepInEx;

namespace LordAshes
{
    public partial class TemplatePlugin : BaseUnityPlugin
    {
        /// <summary>
        /// Handler for Stat Messaging subscribed messages.
        /// </summary>
        /// <param name="changes"></param>
        public void HandleRequest(StatMessaging.Change[] changes)
        {
            // Change.cid = Creature Id of the creature associated with the message
            // Change.action = Indicates if the change is a message add, message modify or a message removal
            // Change.Previous = Previous message value
            // Change.Value = Current message value (this is the property that contains the current message)
            foreach (StatMessaging.Change change in changes)
            {
            }
        }

        /// <summary>
        /// Handler for Radial Menu selections
        /// </summary>
        /// <param name="cid"></param>
        private void SetRequest(CreatureGuid cid)
        {
        }
    }
}
