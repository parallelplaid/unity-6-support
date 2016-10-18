using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AsyncInEditor))]
public class AsyncInEditorEditor : Editor
{
	private bool isCanceled;
	private bool isRunning;

	public override async void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUI.enabled = !isRunning;
		if (GUILayout.Button("Start"))
		{
			isRunning = true;
			isCanceled = false;

			while (isCanceled == false)
			{
				await AsyncTools.ToThreadPool();
				AsyncTools.WhereAmI("1");

				await AsyncTools.ToEditorUpdate();
				AsyncTools.WhereAmI("2");

				await 1;
			}

			await AsyncTools.ToEditorUpdate();
			AsyncTools.WhereAmI("Stopped");

			isRunning = false;
			return;
		}

		GUI.enabled = isRunning;
		if (GUILayout.Button((isCanceled && isRunning) ? "Stopping" : "Stop"))
		{
			isCanceled = true;
		}
	}
}