using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GvrVideoPlayerTexture))]
public class PlayController : MonoBehaviour {
    private GvrVideoPlayerTexture player;
    private long currentPositition;
    private ParticleSystem ps;
    public GameObject steam;
    public GameObject instructuionLookUp;
    public GameObject instructuionLookUp2;
    public  GameObject [] folloeMe;
    public GvrAudioSource[] audioSources;
    public int endPosition;
    public GameObject playPause;
    public AudioClip narration1;
    public AudioClip narration2;
    public AudioClip narration3;
    public int creditPosition;
    private bool narration2Started;
    private bool narration1Started;
    private bool narration3Started;
    private bool followMeIsShown;
    private bool videoIsEnding;
    public bool start;
    public int audioSourceIndex;
    // Use this for initialization



   
void Start () {
       
        player = GetComponent<GvrVideoPlayerTexture>();
        ps = steam.GetComponent<ParticleSystem>();
        setPlayerMarkers();
        start = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            currentPositition = player.CurrentPosition;
            Debug.Log("POS "+ currentPositition.ToString());
            if (currentPositition >= (long)33000 && !narration2Started) {
                
                   
                        if (ps)
                        {
                            if (!ps.isPlaying)
                            {
                                SteamPlayer(true);
                            }

                        }
                    
                
                   
            }
            if (currentPositition >= (long)65000 && !instructuionLookUp.activeSelf && !narration2Started)
            {
                
                    instructuionLookUp.SetActive(true);
                
               
            }
            if (currentPositition >= (long)70000 && !narration2Started)
            {

                audioSources[2].Stop();
                    narration2Started = true;
                    instructuionLookUp.SetActive(false);
                audioSources[1].clip = narration2;
                audioSources[1].Play();
                audioSources[3].Play();
                    if (ps.isPlaying)
                    {
                        SteamPlayer(false);
                    }
                
              
                   
               
            }
            if (currentPositition >= (long)100000 && !followMeIsShown && !narration3Started)
            {
             showFollowMe(true);
             instructuionLookUp2.SetActive(true);


            }
            if (currentPositition >= (long)122000 && !narration3Started)
            {
                
                narration3Started = true;
                showFollowMe(false);
                instructuionLookUp2.SetActive(false);
                audioSources[1].clip = narration3;
                audioSources[1].PlayDelayed(5);
                audioSources[audioSourceIndex].PlayDelayed(2);
                audioSources[3].Stop();
                
                
                

            }
            if (currentPositition >= endPosition && !videoIsEnding)
            {
                videoIsEnding = true;
                playPause.SetActive(false);
                JumpToPosition(creditPosition);
                playPause.SetActive(false);
                for (int i = 1; i <= audioSources.Length; i++)
                {
                    if (audioSources[i].isPlaying)
                    {
                        audioSources[i].Stop();
                    }
                }
            }
        }
	}
    public void RestartVideo()
    {
        player.Pause();
        player.CurrentPosition = 3;
        foreach (GvrAudioSource i in audioSources)
        {
            i.Stop();
        }
        setPlayerMarkers();
        if (ps)
        {
            if (ps.isPlaying)
            {
                SteamPlayer(false);
            }

        }
    }
    public void SteamPlayer (bool starting)
    {
        if (starting)
        {
            ps.Play();
        } else
        {
            ps.Stop();
        }
        
    }

    public void JumpToPosition(int position)
    {
        player.Pause();
        player.CurrentPosition = position;
        player.Play();
    }
    public void showFollowMe(bool b) {
        followMeIsShown = b;
        foreach (GameObject i in folloeMe)
        {
            i.SetActive(b);
        }
    }
  public void setEndPosition(int position)
    {
        endPosition = position;
    }
    public void setAudioSourceIndex(int index)
    {
        audioSourceIndex = index;
    }
    private void setPlayerMarkers()
    {
        audioSources[1].clip = narration1;
        endPosition = 140000;
        creditPosition = 489000;
        narration1Started = false;
        narration2Started = false;
        narration3Started = false;
        showFollowMe(false);
        videoIsEnding = false;
        start = true;
        audioSourceIndex = 4;
        instructuionLookUp.SetActive(false);
        instructuionLookUp2.SetActive(false);

    }
}
