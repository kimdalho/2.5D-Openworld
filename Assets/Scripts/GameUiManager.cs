using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUiManager : MonoBehaviour
{
    public static GameUiManager Instance;

    public GameObject WinerPanel;
    public TextMeshProUGUI text_winder;
    public Button btnNext;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        btnNext.onClick.AddListener(() => {
            SceneManager.LoadScene("LobbyScene");
        });

    }

    public void ShowGameResult(Castle WinTeam)
    {
        WinerPanel.gameObject.SetActive(true);
        text_winder.text = $"{WinTeam.teamName} Win!";
    }


}
