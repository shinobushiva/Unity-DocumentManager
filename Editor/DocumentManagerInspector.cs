using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[CanEditMultipleObjects]
[CustomEditor(typeof(DocumentManager))]
public class DocumentManagerInspector : Editor
{
	public override void OnInspectorGUI()
	{
		//serializedObject.Update();
		DrawProperties();
		//serializedObject.ApplyModifiedProperties();
	}
	
	//各要素の描画
	void DrawProperties()
	{
		DrawDefaultInspector ();
		
		EditorGUILayout.BeginVertical();
		if (GUILayout.Button("Load"))
		{
			List<DocumentManager.Document> docs = new List<DocumentManager.Document>();
			
			Entity_Data data = Resources.Load("shishin") as Entity_Data;
			foreach(Entity_Data.Sheet s in data.sheets){ 
				foreach(Entity_Data.Param p in s.list){
					
					DocumentManager.Document d = new DocumentManager.Document();
					d.id = p.key;
					d.content = p.value; 
					docs.Add(d);
				}
			}
			((DocumentManager)target).documents = docs.ToArray();
			EditorUtility.SetDirty(target);
		} 
		
		EditorGUILayout.EndVertical();
	}
}
