
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RenderHeads.Media.AVProVideo;


public class MediaPlayerUI : MonoBehaviour
{
    public MediaPlayer mediaPlayer; // Ссылка на компонент проигрывателя видео
    public Button playButton; // Ссылка на кнопку "Play"

    bool isVideoPlaying = false; // Переменная для отслеживания состояния проигрывания видео

    void Start()
    {
        mediaPlayer.Control.Pause();

        playButton.onClick.AddListener(ToggleVideo);
    }

    void ToggleVideo()
    {
        Debug.Log("Privet");
        if (!isVideoPlaying)
        {
            mediaPlayer.Control.Play();
            isVideoPlaying = true;
        }
        else
        {
            // Если видео уже проигрывается, ставим его на паузу
            mediaPlayer.Control.Pause();
            isVideoPlaying = false;
        }
    }
}
