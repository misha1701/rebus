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
    
    // вызываетс€ каждый кадр (и каждое считываение с клавиатуры/мыши)
    private void Update()
    {


        // если
        // пробел нажат,
        // то выключить видео

        // если(¬вод.Ќажата лавиша(Ќомер лавиши.Ћева€—трелка))
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
        // заставка.игровойќбьект.”становитьјктивность(правда)
        zastavka.gameObject.SetActive(true);
        
        fonovMusicPlayer.Stop();
        zastavkaMusicPlayer.Play();
    }

    private void ZastavkaFolse()
    {
        // заставка.игровойќбьект.”становитьјктивность(ложь/нет)
        zastavka.gameObject.SetActive(false);
        
        // аудио»сходники«аставки.—топ()
        fonovMusicPlayer.Play();
        zastavkaMusicPlayer.Stop();
    }
}