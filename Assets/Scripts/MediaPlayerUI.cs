using UnityEngine;
using RenderHeads.Media.AVProVideo;
using TMPro;

public class MediaPlayerUI : MonoBehaviour
{
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private TextMeshProUGUI _videoname;

    private Preview _preview;
    private MediaPath _videoPath = new MediaPath("", MediaPathType.RelativeToDataFolder);

    private void Awake()
    {
        _preview = GetComponentInChildren<Preview>();
    }

    private void Start()
    {
        SetVideo(_preview.FirstVideo);
    }

    private void OnEnable()
    {
        GetComponentInChildren<Preview>().OnPreviewClickedEvent += SetVideo;
    }

    private void OnDisable()
    {
        GetComponentInChildren<Preview>().OnPreviewClickedEvent -= SetVideo;
    }

    private void SetVideo(VideoData data)
    {
        SetVideoPath(data.VideoPath);
        SetVideoName(data.VideoName);
    }

    private void SetVideoPath(string path)
    {
        _videoPath.Path = path;
        _mediaPlayer.OpenMedia(_videoPath, false);
    }

    private void SetVideoName(string name) => _videoname.text = name;
}