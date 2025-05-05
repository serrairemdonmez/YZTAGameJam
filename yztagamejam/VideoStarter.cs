using UnityEngine;
using UnityEngine.Video;

public class VideoStarter : MonoBehaviour
{
    private VideoPlayer vp;
    private bool triedToPlay = false;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        if (vp != null)
        {
            vp.prepareCompleted += OnPrepared;
            vp.Prepare();  // önce hazırlasın
        }
    }

    void OnPrepared(VideoPlayer source)
    {
        vp.Play();
        triedToPlay = true;
    }

    void Update()
    {
        // Ekstra garanti: Eğer play olmadıysa tekrar dener
        if (!vp.isPlaying && !triedToPlay)
        {
            vp.Play();
        }
    }
}
