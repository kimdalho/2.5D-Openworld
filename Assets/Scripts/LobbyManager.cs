using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private Button btn_battle;
    [SerializeField]
    private Button btn_myhome;
    [SerializeField]
    private Button btn_exit;

    private void Awake()
    {
        btn_battle.onClick.AddListener(OnClickGameStart);
        btn_myhome.onClick.AddListener(OnClickMyHome);
        btn_exit.onClick.AddListener(OnClickExit);

    }


    private void OnClickGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnClickMyHome()
    {

    }

    private void OnClickExit()
    {

    }
}
