using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    [SerializeField] private RawImage _previewImagePrefab;
    [SerializeField] private Transform _previewContainer;
    [SerializeField] private VideoData[] _videoData;

    void Start()
    {
        foreach (VideoData data in _videoData)
        {
            CreatePreview(data);
        }
    }

    void CreatePreview(VideoData data)
    {
        RawImage previewImage = Instantiate(_previewImagePrefab, _previewContainer);
        previewImage.texture = data.PreviewTexture;

        // Добавляем слушатель нажатия на превью
        previewImage.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnPreviewClicked(data.VideoPath);
        });
    }

    void OnPreviewClicked(string videoPath)
    {
        Debug.Log("Path to video: " + videoPath);
        // Здесь вы можете выполнить нужные действия при нажатии на превью, например, воспроизведение видео
    }
}
