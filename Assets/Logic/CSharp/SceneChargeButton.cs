using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChargeButton : MonoBehaviour
{
    public int gameMode;
    public void ChargeSceneByNumber(int scene)
    {
        encounter.gamemode = gameMode;
        SceneManager.LoadScene(scene);
    }
    public void ChargeSceneByString(string scene)
    {
        encounter.gamemode = gameMode;
        SceneManager.LoadScene(scene);
    }
}
