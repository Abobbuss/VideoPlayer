using UnityEngine;

[CreateAssetMenu(fileName = "New Series", menuName = "Series")]
public class VideoData : ScriptableObject
{
    [SerializeField] private Texture2D _previewTexture;
    [SerializeField] private string _videoPath;
    [SerializeField] private string _videoName;

    public Texture2D PreviewTexture => _previewTexture;
    public string VideoPath => _videoPath;
    public string VideoName => _videoName;
}