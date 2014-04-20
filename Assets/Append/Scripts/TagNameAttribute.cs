using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using UnityEditorInternal;
#endif
public class TagNameAttribute : PropertyAttribute
{
    public int selectedValue = 0;
    public bool enableOnly = true;
    public TagNameAttribute(bool enableOnly = true)
    {
        this.enableOnly = enableOnly;
    }
}


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(TagNameAttribute))]
public class TagNameDrawer : PropertyDrawer
{
    private TagNameAttribute tagNameAttribute
    {
        get
        {
            return (TagNameAttribute)attribute;
        }
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string[] tagNames = GetEnabledTagNames();

        //if (tagNames.Length == 0)
        //{
        //    EditorGUI.LabelField(position, ObjectNames.NicifyVariableName(property.name), "Empty");
        //    return;
        //}

        int[] tagNumbers = new int[tagNames.Length];

        SetTagNambers(tagNumbers, tagNames);

        if (!string.IsNullOrEmpty(property.stringValue))
            tagNameAttribute.selectedValue = GetIndex(tagNames, property.stringValue);

        tagNameAttribute.selectedValue = EditorGUI.IntPopup(position, label.text, tagNameAttribute.selectedValue, tagNames, tagNumbers);

        property.stringValue = tagNames[tagNameAttribute.selectedValue];
    }

    string[] GetEnabledTagNames()
    {
        return InternalEditorUtility.tags;
        

        //List<EditorBuildSettingsScene> tags = (tagNameAttribute.enableOnly ? EditorBuildSettings.tags.Where(tag => tag.enabled) : EditorBuildSettings.tags).ToList();
        //tags.ForEach(tag =>
        //{
        //    tagNames.Add(tag.path.Substring(tag.path.LastIndexOf("/") + 1).Replace(".unity", string.Empty));
        //});

        //return tagNames.ToArray();
    }

    void SetTagNambers(int[] tagNumbers, string[] tagNames)
    {
        for (int i = 0; i < tagNames.Length; i++)
        {
            tagNumbers[i] = i;
        }
    }

    int GetIndex(string[] tagNames, string tagName)
    {
        int result = 0;
        for (int i = 0; i < tagNames.Length; i++)
        {
            if (tagName == tagNames[i])
            {
                result = i;
                break;
            }
        }
        return result;
    }
}
#endif