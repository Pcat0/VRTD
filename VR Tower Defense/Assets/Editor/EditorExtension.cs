using UnityEngine;
using UnityEditor;

static class EditorExtension {
    public static void AddMenuItem(this GenericMenu menu, GUIContent content, bool enabled, bool slected, GenericMenu.MenuFunction funct) {
        if (enabled)
            menu.AddItem(content, slected, funct);
        else
            menu.AddDisabledItem(content);
    }
}