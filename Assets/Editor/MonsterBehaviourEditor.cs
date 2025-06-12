using UnityEngine;
using UnityEditor;
using DD.Character.Monster;

[CustomEditor(typeof(MonsterBehaviour), true)]
public class MonsterBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MonsterBehaviour controller = (MonsterBehaviour)target;
        var stat = controller.GetStatus();

        if (Application.isPlaying && stat != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Monster Runtime Stats", EditorStyles.boldLabel);

            EditorGUILayout.LabelField("Cur HP", stat.CurHP.ToString());
            EditorGUILayout.LabelField("Cur Attack", stat.CurAttack.ToString());
            EditorGUILayout.LabelField("Cur Move Speed", stat.CurMoveSpeed.ToString("F2"));
            EditorGUILayout.LabelField("Cur Attack Speed", stat.CurAttackSpeed.ToString("F2"));
            EditorGUILayout.LabelField("Cur Attack Range", stat.CurAttackRange.ToString());
            EditorGUILayout.LabelField("Cur EXP", stat.CurEXP.ToString());
        }
        else
        {
            EditorGUILayout.HelpBox("Press Play to see runtime stats", MessageType.Info);
        }
    }
}
