using UnityEditor;
using UnityEngine;

public class DEV_DEBUG_MANAGER_EDITOR : EditorWindow
{
	 [MenuItem("Debug/Debug Manager")]
        public static void ShowWindow()
        {
            GetWindow<DEV_DEBUG_MANAGER_EDITOR>("DEV DEBUG MANAGER");
        }
    
        private void OnGUI()
        {
            GUILayout.Label("Debug Settings", EditorStyles.boldLabel);
            
            DEV_DEBUG_MANAGER.ENABLE_LOG = EditorGUILayout.Toggle("ENABLE DEBUG LOG", DEV_DEBUG_MANAGER.ENABLE_LOG);
            
            // Button Example
            if (GUILayout.Button("EXAMPLE BUTTON"))
            {
                
            }
        }
}
