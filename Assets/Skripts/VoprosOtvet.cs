using System;

[Serializable]
public class VoprosOtvet
{
    public string Vopros;
    public string[] Otvet;
    public int PravOtvetIndex = -1;

    public VoprosOtvet()
    {
        Otvet = new string[4];
    }
}