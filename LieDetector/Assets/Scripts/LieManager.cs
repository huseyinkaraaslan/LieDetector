using UnityEngine;
using UnityEngine.UI;

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
        ShowNewStatement();
    }

    public void ShowNewStatement()
    {
        int index = Random.Range(0, statements.Length);
        currentStatement = statements[index];

        UIManager.Instance.SetSentence(currentStatement.sentence);
        UIManager.Instance.SetCharacter(currentStatement.normalFace);
        UIManager.Instance.SetButtonsEnabled(true);
    }

    public void PlayerChose(bool choseTruth)
    {
        UIManager.Instance.SetButtonsEnabled(false);

        bool correct = (choseTruth == currentStatement.isTruth);

        if (correct)
        {
            Debug.Log("Doğru tahmin!");
            // Buraya puan ver
        }
        else
        {
            Debug.Log("YANLIŞ tahmin!");
            // Buraya ceza uygula
        }

        // Tepki yüzü göster (örneğin 2 saniye)
        UIManager.Instance.SetCharacter(currentStatement.reactionFace);
        Invoke(nameof(ShowNewStatement), 2f);
    }

    // Bu metodları butonlara bağla
    public void OnTruthButton()
    {
        PlayerChose(true);
    }

    public void OnLieButton()
    {
        PlayerChose(false);
    }
}
