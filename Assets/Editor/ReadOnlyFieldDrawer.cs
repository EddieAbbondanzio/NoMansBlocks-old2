using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
/// <summary>
/// Handles rendering the read only field in the Unity editor.
/// Source: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
/// </summary>
[CustomPropertyDrawer(typeof(ReadOnlyFieldAttribute))]
public sealed class ReadOnlyFieldDrawer : PropertyDrawer {
    #region Publics
    /// <summary>
    /// How tall is the field?
    /// </summary>
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    /// <summary>
    /// Draw it.
    /// </summary>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
    #endregion
}
#endif