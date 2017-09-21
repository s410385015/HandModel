using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HandControl))]
public class ObjectBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		HandControl myScript = (HandControl)target;
		if(GUILayout.Button("Auto Set"))
		{
			myScript.SetRotation ();
		}
		if(GUILayout.Button("Reset"))
		{
			myScript.Reset ();
		}

		if(GUILayout.Button("Do not click this button"))
		{
			myScript.OnShot();
		}
	}
}