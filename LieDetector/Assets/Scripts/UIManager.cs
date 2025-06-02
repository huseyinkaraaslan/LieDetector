using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public Image characterImage;
    public TextMeshProUGUI sentenceText;
    public Button truthButton;
    public Button lieButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetSentence(string sentence)
    {
        sentenceText.text = sentence;
    }

    public void SetCharacter(Sprite characterSprite)
    {
        characterImage.sprite = characterSprite;
    }

    public void SetButtonsEnabled(bool enabled)
    {
        truthButton.interactable = enabled;
        lieButton.interactable = enabled;
    }
}
