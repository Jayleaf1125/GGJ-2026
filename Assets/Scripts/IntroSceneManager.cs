using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] DialougeSO currrentDialouge;
    [SerializeField] TextMeshProUGUI dialougeText;
    [SerializeField] TextMeshProUGUI btnText;

    [Header("Canvas Objects")]
    [SerializeField] GameObject dialougeCanvas;
    [SerializeField] GameObject howToPlayCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialougeText.text = currrentDialouge.dialougeText;

        dialougeCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currrentDialouge.nextDialougeText == null)
        {
            btnText.text = "End Dialouge";
        }
    }

    public void NextText()
    {
        if (currrentDialouge.nextDialougeText != null)
        {
            currrentDialouge = currrentDialouge.nextDialougeText;
            dialougeText.text = currrentDialouge.dialougeText;
        }
        else
        {
            dialougeCanvas.SetActive(false);
            howToPlayCanvas.SetActive(true);
        }
    }

    public async void NextScene(int val)
    {
        await SceneManager.LoadSceneAsync(val);
    }
}
