using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameOverAnimator : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI scoreText;

    public AudioSource audioSource;
    public AudioClip countSound;   
    public AudioClip finalDing;  

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

        audioSource.clip = countSound;
        audioSource.loop = true;
        audioSource.Play();

        while (displayScore < finalScore)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            int newDisplay = Mathf.RoundToInt(Mathf.Lerp(0, finalScore, t));

            if (newDisplay > displayScore)
            {
                displayScore = newDisplay;
                scoreText.text = "Score: " + displayScore.ToString();
            }

            yield return null;
        }

        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(finalDing);

        scoreText.text = "Score: " + finalScore.ToString();
    }
}
