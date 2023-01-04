using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSequenceSoundItem : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] audioClips;
    public float[] audioClipsDelays;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartAudios();
    }

    int currentIndex;
    public void StartAudios()
    {
        if (currentIndex < audioClips.Length)
        {
            StartCoroutine(WaitForAudioClip());
        }
    }

    IEnumerator WaitForAudioClip()
    {
        yield return new WaitForSeconds(audioClipsDelays[currentIndex]);
        audioSource.PlayOneShot(audioClips[currentIndex]);
        currentIndex++;
        StartAudios();
    }
}
