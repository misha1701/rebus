using System;
using System.Collections.Generic;

[Serializable]
public class VoprosOtvet
{
    public string Vopros;
    public string[] Otvet;
    public List<int> PravOtvetIndex = new List<int>();

    public VoprosOtvet()
    {
        Otvet = new string[4];
    }
}