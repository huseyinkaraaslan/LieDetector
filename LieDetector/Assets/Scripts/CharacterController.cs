using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string characterName;
        public Sprite bookSprite;
        [TextArea]
        public string description;
        public Sprite portrait;
    }

    public CharacterInfo[] characters;
    public GameObject bookButtonPrefab;
    public Transform bookshelfParent;

    public GameObject detailPanel;
    public Text detailNameText;
    public Text detailDescriptionText;
    public Image detailPortrait;

    void Start()
    {
        GenerateBooks();
        detailPanel.SetActive(false);
    }

    void GenerateBooks()
    {
        foreach (var character in characters)
        {
            GameObject button = Instantiate(bookButtonPrefab, bookshelfParent);
            button.GetComponent<Image>().sprite = character.bookSprite;
            button.GetComponentInChildren<Text>().text = character.characterName;
            button.GetComponent<Button>().onClick.AddListener(() => ShowCharacterDetail(character));
        }
    }

    void ShowCharacterDetail(CharacterInfo character)
    {
        detailNameText.text = character.characterName;
        detailDescriptionText.text = character.description;
        detailPortrait.sprite = character.portrait;
        detailPanel.SetActive(true);
    }

    public void CloseDetailPanel()
    {
        detailPanel.SetActive(false);
    }
}
