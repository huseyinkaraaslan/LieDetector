using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI sentenceText;
    public Button truthButton;
    public Button lieButton;
    public Image characterImage;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetSentence(string sentence)
    {
        sentenceText.text = sentence;
    }

    public void SetCharacter(Sprite face)
    {
        characterImage.sprite = face;
    }

    public void SetButtonsEnabled(bool enabled)
    {
        truthButton.interactable = enabled;
        lieButton.interactable = enabled;
    }
}
