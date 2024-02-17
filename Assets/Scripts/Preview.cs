using System;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public event Action<VideoData> OnPreviewClickedEvent;

    [SerializeField] private RawImage _previewImagePrefab;
    [SerializeField] private Transform _previewContainer;
    [SerializeField] private VideoData[] _videoData;

    private VideoData _firstVideo;
    private VideoData _currentVideo;
    public VideoData FirstVideo => _firstVideo;

    private void Start()
    {
        foreach (VideoData data in _videoData)
        {
            CreatePreview(data);
        }

        _firstVideo = _videoData[_videoData.Length - 1];
        _currentVideo = _firstVideo;
    }

    private void CreatePreview(VideoData data)
    {
        RawImage previewImage = Instantiate(_previewImagePrefab, _previewContainer);
        previewImage.texture = data.PreviewTexture;

        previewImage.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnPreviewClicked(data);
        });
    }

    private void OnPreviewClicked(VideoData data)
    {
        if (data != _currentVideo)
        {
            _currentVideo = data;
            OnPreviewClickedEvent?.Invoke(data);
        }
    }
}