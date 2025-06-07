using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BigNumber))]
public class BigNumberDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty mantissaProp = property.FindPropertyRelative("mantissa");
        SerializedProperty exponentProp = property.FindPropertyRelative("exponent");

        // Format preview
        double value = mantissaProp.doubleValue * Mathf.Pow(10, exponentProp.intValue);
        string formatted = BigNumberFormatter.Format(value);

        // Draw foldout
        position = EditorGUI.PrefixLabel(position, label);
        Rect fieldRect = new Rect(position.x, position.y, position.width / 3f, position.height);
        Rect field2Rect = new Rect(position.x + position.width / 3f, position.y, position.width / 3f, position.height);
        Rect formattedRect = new Rect(position.x + (2f * position.width / 3f), position.y, position.width / 3f, position.height);

        EditorGUI.PropertyField(fieldRect, mantissaProp, GUIContent.none);
        EditorGUI.PropertyField(field2Rect, exponentProp, GUIContent.none);
        EditorGUI.LabelField(formattedRect, formatted);
    }
}
