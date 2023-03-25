using UnityEngine;
using UnityEngine.UI;

public class BgMusic : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public AudioSource audioSource;
    private float originalVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalVolume = audioSource.volume;
    }

    void Update()
    {
        if (pauseMenu.activeSelf || gameOverMenu.activeSelf)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = originalVolume;
        }
    }
}
