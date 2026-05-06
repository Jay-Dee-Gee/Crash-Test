using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource sourceA;   
    public AudioSource sourceB;   
    public AudioSource sourceC;   

    [Header("Music Clips")]
    public AudioClip track1;
    public AudioClip track2;
    public AudioClip track3;

    [Header("Settings")]
    public float fadeDuration = 2f;

    private bool switchedTo2 = false;
    private bool switchedTo3 = false;

    void Start()
    {
        // Start with track 1
        sourceA.clip = track1;
        sourceA.volume = 0.175f;
        sourceA.Play();

        // Prepare other tracks
        sourceB.clip = track2;
        sourceB.volume = 0f;

        sourceC.clip = track3;
        sourceC.volume = 0f;
    }

    void Update()
    {
        int score = ScoringSystem.score;

        if (!switchedTo2 && score >= 80)
        {
            switchedTo2 = true;
            StartCoroutine(Crossfade(sourceA, sourceB));
        }

        if (!switchedTo3 && score >= 150)
        {
            switchedTo3 = true;
            StartCoroutine(Crossfade(sourceB, sourceC));
        }
    }

    private System.Collections.IEnumerator Crossfade(AudioSource from, AudioSource to)
    {
        to.Play();

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            from.volume = Mathf.Lerp(0.175f, 0f, t);
            to.volume = Mathf.Lerp(0f, 0.175f, t);

            yield return null;
        }

        from.Stop();
    }
}
