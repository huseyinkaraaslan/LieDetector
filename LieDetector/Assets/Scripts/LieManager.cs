using UnityEngine;

public class LieManager : MonoBehaviour
{
    public static LieManager Instance;

    [System.Serializable]
    public class Statement
    {
        public string sentence;
        public bool isTruth;
        public Sprite normalFace;
        public Sprite reactionFace;
    }

    public Statement[] statements;
    public Statement currentStatement;
    private int index = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        if (index != statements.Length)
            StartNewRound();            
        else
            Invoke(nameof(UIManager.Instance.BackToMainMenu), 2f);
    }

    public void StartNewRound()
    {
        UIManager.Instance.SetResultScreen(false, "");
        currentStatement = statements[index];

        UIManager.Instance.SetSentence(currentStatement.sentence);
        UIManager.Instance.SetCharacter(currentStatement.normalFace);
        UIManager.Instance.SetButtonsEnabled(true);

        TimerManager.Instance.StartTimer();

        index = Mathf.Min(index + 1, statements.Length);
    }

    public void PlayerChose(bool choseTruth)
    {
        TimerManager.Instance.StopTimer();
        UIManager.Instance.SetButtonsEnabled(false);

        if (index == statements.Length)
        {
            Invoke(nameof(UIManager.Instance.BackToMainMenu),2f);
        }
        bool correct = (choseTruth == currentStatement.isTruth);
        string resultAnswer;

        if (correct)
        {
            ScoreManager.Instance.AddScore(10);
            resultAnswer = "Correct Answer";
            Debug.Log("Doğru tahmin!");
        }
        else
        {
            resultAnswer = "Wrong Answer";
            Debug.Log("YANLIŞ tahmin!");
        }

        UIManager.Instance.SetResultScreen(true, resultAnswer);
        UIManager.Instance.SetCharacter(currentStatement.reactionFace);

        // Yeni turu başlat
        Invoke(nameof(StartNewRound), 2f);
    }

    public void OnTruthButton()
    {
        PlayerChose(true);
    }

    public void OnLieButton()
    {
        PlayerChose(false);
    }

    public void InvokeNewRound(float timeInvoke)
    {        
        Invoke(nameof(StartNewRound), timeInvoke);     
    }
}
