using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot calmSnapshot;
    [SerializeField] AudioMixerSnapshot intenseSnapshot;

    // duration of the crossfade in seconds
    private float transitionTime = 1f;

    // crossfades from calm to intense music
    public void GoIntense()
    {
        intenseSnapshot.TransitionTo(transitionTime);
    }

    // crossfades back to calm music
    public void GoCalm()
    {
        calmSnapshot.TransitionTo(transitionTime);
    }
}
