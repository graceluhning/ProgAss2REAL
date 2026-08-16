using System.Collections.Generic;

namespace _Project.Code.Gameplay.Dialogue
// The dialogue script from class
{
    [System.Serializable]
    public class DialogueData
    {
        public string start;
        public DialogueCharacter[] characters;
        public DialogueScene[] scenes;
    }

    [System.Serializable]
    public class DialogueCharacter
    {
        public string reference;
        public string name;
        public DialogueEmotions emotions;
    }

    [System.Serializable]
    public class DialogueEmotions
    {
        public string happy;
        public string sad;
        public string shocked;
        public string neutral;
        public string angry;
        public string cool;

        public Dictionary<string, string> AsDictionary()
        {
            return new Dictionary<string, string>
            {
                { "happy", happy },
                { "sad", sad },
                { "neutral", neutral },
                { "shocked", shocked },
                { "angry", angry },
                { "cool", cool }
            };
        }
    }

    [System.Serializable]
    public class DialogueScene
    {
        public string name;
        public int entry;
        public string end_scene;
        public DialogueText[] dialogue;
    }

    [System.Serializable]
    public class DialogueText
    {
        public string character_ref;
        public string emotion;
        public string text;
        public bool fade_out;
    }

}
