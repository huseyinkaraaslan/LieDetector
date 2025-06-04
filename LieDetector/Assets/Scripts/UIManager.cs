using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public GameObject resultScreen;
    public GameObject mainMenuScreen;
    public GameObject gameScreen;
    public Image characterImage;
    public TextMeshProUGUI sentenceText;
    public Button truthButton, lieButton, playButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        SetMainMenuScreen(true);
        SetResultScreen(false, "");
        SetGameScreen(false);
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

    public void SetMainMenuScreen(bool isActive)
    {
        mainMenuScreen.SetActive(isActive);
    }

    public void SetGameScreen(bool isActive)
    {
        gameScreen.SetActive(isActive);
    }

    public void SetResultScreen(bool isActive, string resultText)
    {
        resultScreen.SetActive(isActive);
        resultScreen.GetComponentInChildren<TextMeshProUGUI>().text = resultText;
    }

    public void OnPlayPressed()
    {
        SetMainMenuScreen(false);
        SetResultScreen(false, "");
        SetGameScreen(true);
    }
    public void BackToMainMenu()
    {
        mainMenuScreen.SetActive(true);
        gameScreen.SetActive(false);
        resultScreen.SetActive(false);
    }
}
