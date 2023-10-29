using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Zastavka : MonoBehaviour
{
    [SerializeField] VideoPlayer zastavka;
    [SerializeField] AudioSource fonovMusicPlayer;
    [SerializeField] AudioSource zastavkaMusicPlayer;
    
    // ���������� ������ ���� (� ������ ����������� � ����������/����)
    private void Update()
    {


        // ����
        // ������ �����,
        // �� ��������� �����

        // ����(����.�������������(������������.������������))
        // if (Input.GetKeyDown(KeyCode.LeftArrow))

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ZastavkaFolse();

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ZastavkaTrue();
        }
    }
    private void Start()
    {
        ZastavkaTrue();
    }
    private void ZastavkaTrue()
    {
        // ��������.�������������.��������������������(������)
        zastavka.gameObject.SetActive(true);
        
        fonovMusicPlayer.Stop();
        zastavkaMusicPlayer.Play();
    }

    private void ZastavkaFolse()
    {
        // ��������.�������������.��������������������(����/���)
        zastavka.gameObject.SetActive(false);
        
        // ����������������������.����()
        fonovMusicPlayer.Play();
        zastavkaMusicPlayer.Stop();
    }
}