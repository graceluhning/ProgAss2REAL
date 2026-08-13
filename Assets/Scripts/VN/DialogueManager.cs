using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

namespace _Project.Code.Gameplay.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private TMP_Text characterNameText;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private Image characterImage;

        [SerializeField] private float fadeDuration = 2f;

        private DialogueData dialogueData;

        private DialogueScene currentScene;
        private DialogueText currentLine;

        private int currentLineIndex = 0;

        void Start()
        {
            LoadDialogue();
        }

        void LoadDialogue()
        {
            TextAsset json = Resources.Load<TextAsset>("Dialogue/dialogue");

            dialogueData = JsonUtility.FromJson<DialogueData>(json.text);

            StartDialogue();
        }

        void StartDialogue()
        {
            currentScene = dialogueData.scenes
                .First(scene => scene.name == dialogueData.start);

            currentLineIndex = 0;

            ShowLine();
        }

        void ShowLine()
        {
            currentLine = currentScene.dialogue[currentLineIndex];

            DialogueCharacter character = dialogueData.characters
                .First(c => c.reference == currentLine.character_ref);

            characterNameText.text = character.name;
            dialogueText.text = currentLine.text;

            string spritePath = character.emotions
                .AsDictionary()[currentLine.emotion];

            Sprite sprite = Resources.Load<Sprite>(
                "Characters/" + spritePath
            );

            characterImage.sprite = sprite;

            characterImage.color = new Color(
                characterImage.color.r,
                characterImage.color.g,
                characterImage.color.b,
                1f
            );
        }

        public void ContinueDialogue()
        {
            currentLineIndex++;

            if (currentLineIndex < currentScene.dialogue.Length)
            {
                ShowLine();
                return;
            }

            if (currentLine.fade_out)
            {
                StartCoroutine(FadeOutCharacter());
            }
            else
            {
                LoadNextScene();
            }
        }

        private IEnumerator FadeOutCharacter()
        {
            float elapsed = 0f;
            Color color = characterImage.color;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;

                color.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
                characterImage.color = color;

                yield return null;
            }

            color.a = 0f;
            characterImage.color = color;

            LoadNextScene();
        }

        private void LoadNextScene()
        {
            if (!string.IsNullOrEmpty(currentScene.end_scene))
            {
                SceneManager.LoadScene(currentScene.end_scene);
            }
        }
    }
}