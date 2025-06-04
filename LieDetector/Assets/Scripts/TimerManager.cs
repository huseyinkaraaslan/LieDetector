using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float timePerRound = 10f;
    private float currentTime;

    public TextMeshProUGUI timerText;

    private bool isRunning = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (!isRunning || !(UIManager.Instance.gameScreen.activeSelf)) return;

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
        UIManager.Instance.SetButtonsEnabled(false);
        UIManager.Instance.SetCharacter(LieManager.Instance.currentStatement.reactionFace);
        UIManager.Instance.SetResultScreen(true,"Time Is Up");
        LieManager.Instance.InvokeNewRound(2f);
        Debug.Log("Timeout");  
    }
}
