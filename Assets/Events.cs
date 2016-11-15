using UnityEngine;
using System.Collections;

public static class Events
{
    public static System.Action ResetApp = delegate { };
    
    public static System.Action<WorldCreator.EditingType> OnEditmode = delegate { };

    public static System.Action<string> GotoTo = delegate { };
    public static System.Action<string> GotoBackTo = delegate { };
    public static System.Action Back = delegate { };
    public static System.Action ClickedOnScreen = delegate { };
    public static System.Action<bool> OnDragging = delegate { };

    //
    public static System.Action<Transform> OnEditorRaycastHit = delegate { };
}
   
