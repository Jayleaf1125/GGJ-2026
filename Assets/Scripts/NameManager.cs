using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] TextMeshProUGUI _placeholderText;
    [SerializeField] TextMeshProUGUI _btnText;
    [SerializeField] PlayerSO _currentPlayer;

    [Header("Canvas Objects")]
    [SerializeField] GameObject _nameCanvas;
    [SerializeField] GameObject _startCanvas;

    string _holderText = "Enter text...";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _titleText.text = $"Enter {_currentPlayer.name} name";
        _placeholderText.text = _holderText;

        _nameCanvas.SetActive(false);
        _startCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPlayer.nextPlayer == null)
        {
            _btnText.text = "Finish";
        }    
    }

    public void SetPlayerName()
    {
        if (_currentPlayer.nextPlayer != null)
        {
            _currentPlayer.playerName = _nameInputField.text;
            _currentPlayer = _currentPlayer.nextPlayer;
            _titleText.text = $"Enter {_currentPlayer.name} name";
            _nameInputField.text = "";
        }
        else
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void GoToPlayerCanvas()
    {
        _startCanvas.SetActive(false);
        _nameCanvas.SetActive(true);
    }
}
