using System;

[Serializable]
public class VoprosOtvet
{
    public string Vopros;
    public string[] Otvet;
    public string PravelOtvet;

    public int PolucitPravelOtvet()
    {
        int i = Array.IndexOf(Otvet, PravelOtvet);
        return i;
    }
    
}