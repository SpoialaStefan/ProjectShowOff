using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

[CreateAssetMenu(fileName = "HumanAction", menuName = "ScriptableObjects/HumanAction", order = 1)]
public class HumanAction :ScriptableObject
{
    public bool isActionComplete = false;

    [System.Serializable]
    public enum ActionType
    {
        DoToDestination,
        WaitTime,
        TransformChange,
        GameBojectTurnOn,
        GameBojectTurnOff,
    }

    public ActionType actionType;

    GameObject destination;

    int waitTime;

    Quaternion rotation1;
    Quaternion rotation2;

    List<GameObject> gameBojectsToTurnOn;

    List<GameObject> gameBojectsToTurnOff;

    bool showGameobjects = false;

#if UNITY_EDITOR

    [CustomEditor(typeof(HumanAction))]
    public class HumanActionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            HumanAction humanAction = (HumanAction)target;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Details");

            switch (humanAction.actionType)
            {
                case ActionType.DoToDestination:
                    humanAction.destination = EditorGUILayout.ObjectField("Destination ", humanAction.destination, typeof(GameObject), true) as GameObject;
                    break;
                case ActionType.WaitTime:
                    humanAction.waitTime = EditorGUILayout.IntField(humanAction.waitTime);
                    break;
                case ActionType.TransformChange:
                    break;
                case ActionType.GameBojectTurnOn:
                    ShowObjectToTurnOn(humanAction, humanAction.gameBojectsToTurnOn);
                    break;
                case ActionType.GameBojectTurnOff:
                    ShowObjectToTurnOn(humanAction, humanAction.gameBojectsToTurnOff);
                    break;
            }

        }

        private static void ShowObjectToTurnOn(HumanAction humanAction, List<GameObject> l)
        {
            humanAction.showGameobjects = EditorGUILayout.Foldout(humanAction.showGameobjects, "GameObjects", true);

            if (humanAction.showGameobjects)
            {
                List<GameObject> list = l;
                int size = Mathf.Max(0, EditorGUILayout.IntField("Size", list.Count));

                while (size > list.Count)
                {
                    list.Add(null);
                }
                while (size < list.Count)
                {
                    list.RemoveAt(list.Count - 1);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = EditorGUILayout.ObjectField("Element " + i, list[i], typeof(GameObject), true) as GameObject;
                }
            }
        }
    }
#endif

}
