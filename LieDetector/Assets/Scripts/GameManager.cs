using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image characterImage;
    public TMP_Text speechText;
    public GameObject resultPanel;
    public TMP_Text resultText;

    private string currentStatement;
    private bool isTruth;

    void Start()
    {
        LoadNewCharacter();
    }

    public void OnTruthPressed()
    {
        CheckAnswer(true);
    }

    public void OnLiePressed()
    {
        CheckAnswer(false);
    }

    void LoadNewCharacter()
    {
        resultPanel.SetActive(false);

        string[] statements = {
            "Ben 3 yaşında Harvard'a girdim.",
            "sasa",
            "selammm",
            "1",
            "2",
            "3",
            "Ben sabahları balıkla konuşurum.",
            "Kedim piyano çalıyor."
        };
        int index = Random.Range(0, statements.Length);
        currentStatement = statements[index];
        isTruth = Random.value > 0.5f; // Rastgele doğru/yalan

        speechText.text = currentStatement;
        // karakterImage.sprite = (ileride eklenecek)
    }

    void CheckAnswer(bool playerChoice)
    {
        resultPanel.SetActive(true);
        if (playerChoice == isTruth)
        {
            resultText.text = "✔️ Doğru söyledin!";
            resultPanel.GetComponent<Image>().color = Color.green;
        }
        else
        {
            resultText.text = "❌ Yalan yakalandı!";
            resultPanel.GetComponent<Image>().color = Color.red;
        }

        Invoke(nameof(LoadNewCharacter), 2f);
    }
}
