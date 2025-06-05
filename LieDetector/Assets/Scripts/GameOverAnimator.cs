using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameOverAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
    }

    public void ShowGameOver(int finalScore)
    {
        StartCoroutine(FadeIn(finalScore));
    }

    IEnumerator FadeIn(int finalScore)
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        StartCoroutine(CountUpScore(finalScore));
    }

    IEnumerator CountUpScore(int finalScore)
    {
        int displayScore = 0;
        float duration = 1.5f;
        float elapsed = 0f;

        while (displayScore < finalScore)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            displayScore = Mathf.RoundToInt(Mathf.Lerp(0, finalScore, t));
            scoreText.text = "Score: " + displayScore.ToString();
            yield return null;
        }

        scoreText.text = "Score: " + finalScore.ToString();
    }
}
