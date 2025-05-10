using UnityEngine;

public class encounter : MonoBehaviour
{
    public static int gamemode;
    public GameObject[] GameModes;
    void Start()
    {
        foreach (GameObject gameMode in GameModes) 
        {
            gameMode.SetActive(false);
        }
            GameModes[gamemode].SetActive(true);
    }
}
