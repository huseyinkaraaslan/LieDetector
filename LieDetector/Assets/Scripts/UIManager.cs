using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameOverAnimator gameOverAnimator;

    [Header("UI Elements")]
    public GameObject resultScreen;
    public GameObject mainMenuScreen;
    public GameObject endOfChapterScreen;
    public GameObject gameScreen;
    public Image characterImage;
    public TextMeshProUGUI sentenceText;
    public TextMeshProUGUI finalScoreText;
    public Button truthButton, lieButton, playButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        ShowMainMenu();
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

    public void SetResultScreen(bool isActive, string resultText)
    {
        resultScreen.SetActive(isActive);
        resultScreen.GetComponentInChildren<TextMeshProUGUI>().text = resultText;
    }

    public void OnPlayPressed()
    {
        mainMenuScreen.SetActive(false);
        resultScreen.SetActive(false);
        endOfChapterScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void OnPlayRetry()
    {
        mainMenuScreen.SetActive(false);
        resultScreen.SetActive(false);
        endOfChapterScreen.SetActive(false);
        gameScreen.SetActive(true);
        ScoreManager.Instance.ResetScore();
    }

    public void ShowMainMenu()
    {
        mainMenuScreen.SetActive(true);
        gameScreen.SetActive(false);
        resultScreen.SetActive(false);
        endOfChapterScreen.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameScreen.SetActive(false);
        endOfChapterScreen.SetActive(true);
        gameOverAnimator.ShowGameOver(ScoreManager.Instance.score);        
    }      
}
