using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    public AudioSource LoopEfxSource;
    public AudioSource efxSource;                   
    public AudioSource efxRandomSource;                   
    public AudioSource musicSource;                 
    
    public float lowPitchRange = .95f;              
    public float highPitchRange = 1.05f;            
    
    private bool isStopLoopSfx;
    private bool isLoopInit;

    public void PlaySingleSfx(AudioClip clip)
    {
        efxSource.PlayOneShot(clip);
    }


    public void PlayRandomizeSfx(AudioClip clips)
    {
        //int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxRandomSource.pitch = randomPitch;

        //efxRandomSource.clip = clips[randomIndex];

        efxRandomSource.clip = clips;

        efxRandomSource.Play();
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;

        musicSource.Play();
    }
    
    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayLoopSfx(AudioClip loopSfx)
    {
        isStopLoopSfx = false;
        LoopEfxSource.volume = 1;
        LoopEfxSource.clip = loopSfx;
        LoopEfxSource.Play();
    }

    public void PlayLoopSfxWithVolume(AudioClip loopSfx, float _volume)
    {
        if (!isLoopInit)
        {
            isStopLoopSfx = false;
            LoopEfxSource.clip = loopSfx;
            //LoopEfxSource.loop = true;
            LoopEfxSource.Play();

            isLoopInit = true;
        }

        LoopEfxSource.volume = _volume ;
    }

    public void StopLoopSfx()
    {
        isStopLoopSfx = true;

        isLoopInit = false;

    }

    public void PauseMusic(bool isPause)
    {
        if(isPause == false)
        {
            musicSource.Play();
        }
        if (isPause == true)
        {
            musicSource.Pause();
        }
    }

    public void StopMusicSmooth(float durationOfFade)
    {
        musicSource.DOFade(0, durationOfFade);
    }


    private void Update()
    {
        if (isStopLoopSfx)
        {
            LoopEfxSource.volume -= Time.deltaTime * 2.5f;
        }
    }

    public IEnumerator playMusicWithDelay(AudioClip music, float delayTime, float fadeDuration)
    {
        yield return new WaitForSeconds(delayTime);

        musicSource.DOFade(1, fadeDuration);
        PlayMusic(music);

        yield return null;
    }
}
