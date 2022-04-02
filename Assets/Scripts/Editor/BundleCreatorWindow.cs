using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleCreatorWindow : EditorWindow
{
    private static BundleCreatorWindow w = null;
    public Mod[] allMods = null;
    private Bundle baseBundle;

    [MenuItem("Window/Bundle Creator")]
    public static void OpenWindow(){
        w = GetWindow<BundleCreatorWindow>("Create Bundles");
        w.Show();
    }
    private void OnGUI() {
        //allMods = EditorGUILayout.ObjectField("Mods", allMods, typeof(Mod[]), false) as Mod[];

        //ScriptableObject scriptableObj = this;
        SerializedObject serialObj = new SerializedObject(this);
        SerializedProperty serialProp = serialObj.FindProperty("allMods");

        EditorGUILayout.PropertyField(serialProp, true);
        baseBundle = EditorGUILayout.ObjectField("BaseBundle", baseBundle, typeof(Bundle), true) as Bundle;
        serialObj.ApplyModifiedProperties();

        if (GUILayout.Button("Instanciate")) {
            CreateBundles();
            
        }

    }
    private void CreateBundles() {
        Bundle b;
        int z = 0;
        for (int h = 0; h < 2; h++) {
            for (int i = 0; i < allMods.Length; i++) {
                if (allMods[i].level > 0) {
                    if (h == 0) {
                        b = ScriptableObject.CreateInstance<Bundle>();
                        b.mods.Add(allMods[i]);
                        b.description = allMods[i].name;
                        AssetDatabase.CreateAsset(b, "Assets/Scripts/Bundles/AllBundles/" + ++z + " " + b.mods[0].name + ".asset");
                        
                    }
                    for (int j = 0; h >= 1 && j < allMods.Length; j++) {
                        if (h == 1 && allMods[i].level > allMods[j].level && Mathf.Abs(allMods[j].level) <= allMods[i].level && allMods[i].name.Split(' ')[0] != allMods[j].name.Split(' ')[0]) {
                            b = ScriptableObject.CreateInstance<Bundle>();
                            b.mods.Add(allMods[i]);
                            b.mods.Add(allMods[j]);
                            b.description = allMods[i].name + " " + (allMods[j].level < 0 ? ("<color=red>" + allMods[j].name + "</color>") : allMods[j].name);
                            AssetDatabase.CreateAsset(b, "Assets/Scripts/Bundles/AllBundles/" + ++z + " " + b.mods[0].name + ".asset");
                        }
                        //for (int k = 0; h >= 2 && k < allMods.Length; k++) {
                        //    if (h == 2 && allMods[i].level > allMods[j].level && allMods[j].level > allMods[k].level 
                        //        && allMods[i].name.Split(' ')[0] != allMods[j].name.Split(' ')[0]
                        //        && allMods[j].name.Split(' ')[0] != allMods[k].name.Split(' ')[0]
                        //        && allMods[i].name.Split(' ')[0] != allMods[k].name.Split(' ')[0]) {
                        //        b = ScriptableObject.CreateInstance<Bundle>();
                        //        b.mods.Add(allMods[i]);
                        //        b.mods.Add(allMods[j]);
                        //        b.mods.Add(allMods[k]);
                        //        AssetDatabase.CreateAsset(b, "Assets/Scripts/Bundles/AllBundles/" + ++z + " " + b.mods[0].name + ".asset");
                        //    }
                        //}
                    }

                }
            }
        }
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
    }

}
