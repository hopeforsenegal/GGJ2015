
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GridSnap))]
public class GridSnapEditor : Editor {
	public override void OnInspectorGUI( ) {
		GridSnap gridSnap = ((GridSnap)target);

		if (GUILayout.Button("Snap Children to Grid")) {
			((GridSnap)target).SnapChildren();
		}
		gridSnap.cellSize = EditorGUILayout.FloatField("Cell Size", gridSnap.cellSize);
		gridSnap.cellCount = EditorGUILayout.IntField("Number of Cells", gridSnap.cellCount);

		if (GUI.changed)
			EditorUtility.SetDirty(target);
	}
}