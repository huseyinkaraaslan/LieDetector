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
    private Statement currentStatement;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        int index = Random.Range(0, statements.Length);
        currentStatement = statements[index];

        UIManager.Instance.SetSentence(currentStatement.sentence);
        UIManager.Instance.SetCharacter(currentStatement.normalFace);
        UIManager.Instance.SetButtonsEnabled(true);

        TimerManager.Instance.StartTimer();
    }

    public void PlayerChose(bool choseTruth)
    {
        TimerManager.Instance.StopTimer();
        UIManager.Instance.SetButtonsEnabled(false);

        bool correct = (choseTruth == currentStatement.isTruth);

        if (correct)
        {
            Debug.Log("Doğru tahmin!");
            ScoreManager.Instance.AddScore(10);
        }
        else
        {
            Debug.Log("YANLIŞ tahmin!");
            // İstersen burada ceza puanı vs. uygula
        }

        // Tepki yüzü göster
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
}
