using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class SoundsManager : MonoBehaviour
    {
        [Header("Source Files")]
        [SerializeField] AudioClip[] clipsArray;
        public Dictionary<string, AudioClip> clipsDict = new Dictionary<string, AudioClip>();

        [Header("Audio Sources")]
        [SerializeField] AudioSource music;
        [SerializeField] AudioSource effects;

        private void Start()
        {
            //load sound effects
            foreach (AudioClip clip in clipsArray)
            {
                clipsDict.Add(clip.name, clip);
            }
        }

        public void PlaySoundClip(string clipName)
        {
            effects.PlayOneShot(clipsDict[clipName]);
        }

    }
}
