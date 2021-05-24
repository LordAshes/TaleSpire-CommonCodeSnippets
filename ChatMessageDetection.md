# Detecting Asset Speech And Chat Messages

While there may be a more direct way to do this, at this time it has not been reverse engineered. So to detect assets speaking or chat messages we need to enumerate through all
TextMeshProUGUI objects and then use additional criteria to narrow down the search.

Speech text (speech bubbles), the chat entry bar and chat messages all have the ".name" property set to "Text" so we can use that as the starting point for eliminating other
instances of TextMeshProUGUI. To distinguish between speech bubbles, the chat entry bar and chat messages, on possible way is to check the font since different fonts are
used for each. This would result in code similar to:

````C#
TextMeshProUGUI[] texts = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>();
for (int i = 0; i < texts.Length; i++)
{
   if ((texts[i].name == "Text") && (texts[i].font.name == fontName) && (texts[i].text.Trim().Contains("! ")))
   {
      // Do something with texts[i].text
   }
}
````

# Leveraging The Chat For Request

One way to distribute "commands" betwen clients is to send them through the Chat and then have code similar to the code above to detect the chat messages and process them if
they are recognized as a "command".

If implementing such a solution, keep in mind that the char bar, speech bubbles and chat messages will be present for many Update() cycles and thus a method to prevent
re-processing the "command" multiple times will be needed. Here are some possible options...

## Presence List

When a "command" is recognized it is compared to a list of commands. If it is not present then it is new and thus is processed. If it is on the list, it is not processed.
In each case the command is also placed on a new list which becomes the list for the next Update() cycle. This means that when the message is first detected the command
will be processed but then successive detections will have the command on the list and thus it will not be processed. When the message finally disappears (e.g. speech bubbles
are removed) the message will no longer be put in the next cycle's list and thus the command list will be self cleaning.

## Invalidate The Command Syntax

An alternative method is to replace the message content with one that no longer triggers as being recognized as a command. For example, lets assume that the chat message
detection code is looking for messages that start with a > character. Once such a message is found, it can be changed using something like:

````C#
texts[i].text = "<"+texts[i].text.Substring(2)
````
so that the message content no longer starts with the > character. This will cause it to get ignored on successive Update() cycles. This method works on chat messages
but it does not work on Speech bubble text because Speech bubble text cannot be changed once initiated. This is probably because it is passed to a function which does
the writing out of the text (letter by letter).

