# Input Box For User Input

````C#
SystemMessage.AskForTextInput(
    string title,
    string message,
    string acceptBtnText,
    System.Action<string> onSubmit,
    System.Action onAccept,
    string cancelBtnText = "",
    System.Action onCancel = null,
    string inputString = "");
````
