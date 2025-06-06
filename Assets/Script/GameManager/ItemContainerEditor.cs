using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{

    
    public override void OnInspectorGUI()
    {
        ItemContainer container = target as ItemContainer;
        if (GUILayout.Button("Clear Container"))
        {
            for (int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
        }
        DrawDefaultInspector();
    }
}
    

