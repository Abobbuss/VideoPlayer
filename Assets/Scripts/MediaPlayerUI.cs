
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RenderHeads.Media.AVProVideo;


public class MediaPlayerUI : MonoBehaviour
{
    public MediaPlayer mediaPlayer; // ������ �� ��������� ������������� �����
    public Button playButton; // ������ �� ������ "Play"

    bool isVideoPlaying = false; // ���������� ��� ������������ ��������� ������������ �����

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
            // ���� ����� ��� �������������, ������ ��� �� �����
            mediaPlayer.Control.Pause();
            isVideoPlaying = false;
        }
    }
}
