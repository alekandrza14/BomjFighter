using UnityEngine;

public class Boost : MonoBehaviour
{
    public string boostname = "boostspeed";
    void Start()
    {
        VarSave.SetBool(boostname, true);
    }
}
