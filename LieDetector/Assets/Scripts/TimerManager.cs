using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float timePerRound = 10f;
    private float currentTime;

    public Text timerText;

    private bool isRunning = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            TimeOut();
        }
    }

    public void StartTimer()
    {
        currentTime = timePerRound;
        isRunning = true;
        UpdateTimerUI();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
    }

    private void TimeOut()
    {
        Debug.Log("Süre doldu!");
        UIManager.Instance.SetButtonsEnabled(false);

        // Zaman dolduğunda oyuncu cevap vermemiş sayılır
        LieManager.Instance.PlayerChose(false); // Örnek olarak otomatik yanlış seçildi
    }
}
