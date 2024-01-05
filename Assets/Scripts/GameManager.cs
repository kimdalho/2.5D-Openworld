using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Castle aTeamCastle;

    [SerializeField]
    private Castle bTeamCastle;

    public static GameManager Instance;
    public GameUiManager UIMgr;
    public bool GameOver = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        aTeamCastle.teamName = "A Team";
        bTeamCastle.teamName = "B Team";

    }

    private void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (GameOver == true)
            return;

        if (aTeamCastle.isdead)
        {
            GameOver = true;
            UIMgr.ShowGameResult(bTeamCastle);
        }

        if (bTeamCastle.isdead)
        {
            GameOver = true;
            UIMgr.ShowGameResult(aTeamCastle);
        }
    }
}
