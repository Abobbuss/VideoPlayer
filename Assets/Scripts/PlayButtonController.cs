using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;

public class PlayButtonController : MonoBehaviour
{
    [SerializeField] private Button _playPauseButton;
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private Material _playPauseMaterial;

    private readonly LazyShaderProperty _propMorph = new LazyShaderProperty("_Morph");

    private void Start()
    {
        UpdatePlayPauseMaterial(false);

        _playPauseButton.onClick.AddListener(TogglePlayPause);
        _mediaPlayer.Events.AddListener(OnMediaPlayerEvent);
    }

    private void TogglePlayPause()
    {
        bool isPlaying = _mediaPlayer.Control.IsPlaying();

        if (isPlaying)
            _mediaPlayer.Control.Pause();
        else
            _mediaPlayer.Control.Play();

        UpdatePlayPauseMaterial(!isPlaying);
    }

    private void UpdatePlayPauseMaterial(bool isPlaying)
    {
        float playValue = 1f;
        float stopValue = 0f;

        if(isPlaying)
            _playPauseMaterial.SetFloat(_propMorph.Id, playValue);
        else
            _playPauseMaterial.SetFloat(_propMorph.Id, stopValue);    
    }

    private void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        if (et == MediaPlayerEvent.EventType.FinishedPlaying)
            UpdatePlayPauseMaterial(false);
    }
}