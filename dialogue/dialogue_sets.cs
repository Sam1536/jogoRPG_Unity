using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "New Dialogue/Dialogue")]
public class dialogue_sets : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite SpeakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public  class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages Sentence;

}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if  UNITY_EDITOR
[CustomEditor(typeof(dialogue_sets))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        dialogue_sets ds = (dialogue_sets)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.SpeakerSprite;
        s.Sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.SpeakerSprite = null;
                ds.sentence = "";          }
        }
    }
}

#endif