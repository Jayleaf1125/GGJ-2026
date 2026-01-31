using System;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject _selectCanvas;
    [SerializeField] GameObject _computerCanvas;
    [SerializeField] GameObject _mobileCanvas;

    [SerializeField] TextMeshProUGUI _codeText;
    [SerializeField] TMP_InputField _enterCodeTextField;
    [SerializeField] TextMeshProUGUI _playerList;

    //public event Action OnComputerBtnClick = delegate { };

    //private void OnEnable()
    //{
    //    LobbyManager.instance.OnPlayerJoin += UpdatePlayerList;
    //}

    //private void OnDisable()
    //{
    //    LobbyManager.instance.OnPlayerJoin -= UpdatePlayerList;
    //}

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _selectCanvas.SetActive(true);
        _computerCanvas.SetActive(false);
        _mobileCanvas.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_enterCodeTextField.text);
    }

    public void SelectComputerBtn()
    {
        LobbyManager.instance.CreateLobby();

        _selectCanvas.SetActive(false);
        _computerCanvas.SetActive(true);
    }

    public void SelectMobileBtn()
    {
        _selectCanvas.SetActive(false);
        _mobileCanvas.SetActive(true);
    }

    public void UpdateLobbyCodeText(string code)
    {
        _codeText.text = code;
    }

    public void SubmitLobbyCodeInput()
    {
        LobbyManager.instance.JoinLobbyByCode(_enterCodeTextField.text);
        //UpdateLobbyCodeText(LobbyManager.LobbyCode);
    }

    public void MoveToLobby()
    {
        _mobileCanvas.SetActive(false);
        _computerCanvas.SetActive(true);
    }

    public void UpdatePlayerList(FixedString64Bytes newPlayer)
    {
        _playerList.text = $"\n{newPlayer}";
    }

}
