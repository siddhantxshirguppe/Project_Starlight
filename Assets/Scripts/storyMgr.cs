using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class storyMgr : MonoBehaviour
{
    public GameObject quad;
    public GameObject player;
    private Vector3 playerPos;
    public bool quad_is_active;
    public void orion_story()
    {
        playerPos = player.transform.position;
        quad.SetActive(true);
        quad_is_active = true;
        VideoPlayer videoPlayer = quad.GetComponent<VideoPlayer>();

        // Check if the VideoPlayer component exists
        if (videoPlayer != null)
        {
            // Play the video
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer component not found on the quad!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        quad_is_active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos != player.transform.position && quad_is_active)
        {
            quad.SetActive(false);
        }
    }
}
