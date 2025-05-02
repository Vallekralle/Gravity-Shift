using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static GameMananger instance;

    private Planet planet;
    private AudioSource audioSrc;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (audioSrc.isPlaying)
        {
            return;
        }

        audioSrc.Play();
    }

    private void Update()
    {
        audioSrc.volume = Mathf.Lerp(audioSrc.volume, 1, 0.0001f);
    }

    #region Getter and Setter

    public Planet getPlanet()
    {
        return planet;
    }

    public void setPlanet(Planet planet)
    {
        this.planet = planet;
    }

    #endregion
}
