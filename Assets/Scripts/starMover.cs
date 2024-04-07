﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starMover : MonoBehaviour
{
    public float time_elapsed;
    public float current_scale;
    CSV_reader CSVReaderScript;
    public GameObject CSVReaderObj;
    public GameObject player;
    ConstellationLoader ConstellationLoaderScript;
    public GameObject ConstellationLoaderObj;
    Dictionary<int, GameObject> mstarDictionary;
    Dictionary<int, GameObject> allstarDictionary;
    List<GameObject> starObjects;
    private Coroutine coroutine;
    public bool rev_time;

    public void ToggleRevTime()
    {
        rev_time = !rev_time;
    }
    public void scale_halve()
    {
        CSVReaderScript.new_scale_star_halve();
        
        current_scale = current_scale/2;

        int currConstellation = ConstellationLoaderScript.currConstellation;
        if (currConstellation == 0)
        {
            ConstellationLoaderScript.loadModernConstellation(true);
        }
        else if (currConstellation == 1)
        {
            ConstellationLoaderScript.loadGreekConstellation(true);
        }
        else if (currConstellation == 2)
        {
            ConstellationLoaderScript.loadChineseConstellation(true);
        }
        else if (currConstellation == 3)
        {
            ConstellationLoaderScript.loadIndianConstellation(true);
        }
        else if (currConstellation == 4)
        {
            ConstellationLoaderScript.loadEgyptConstellation(true);
        }
        else if (currConstellation == 5)
        {
            ConstellationLoaderScript.loadNoConstellation(true);
        }

        
    }
    public void scale_double()
    {
        CSVReaderScript.new_scale_star_double();

        current_scale = current_scale * 2;

        int currConstellation = ConstellationLoaderScript.currConstellation;
        if (currConstellation == 0)
        {
            ConstellationLoaderScript.loadModernConstellation(true);
        }
        else if (currConstellation == 1)
        {
            ConstellationLoaderScript.loadGreekConstellation(true);
        }
        else if (currConstellation == 2)
        {
            ConstellationLoaderScript.loadChineseConstellation(true);
        }
        else if (currConstellation == 3)
        {
            ConstellationLoaderScript.loadIndianConstellation(true);
        }
        else if (currConstellation == 4)
        {
            ConstellationLoaderScript.loadEgyptConstellation(true);
        }
        else if (currConstellation == 5)
        {
            ConstellationLoaderScript.loadNoConstellation(true);
        }


    }

    public void forward_10_years()
    {
        if(rev_time)
        {
            CSVReaderScript.jump_10k_years(-1);
        }
        else
        {
            CSVReaderScript.jump_10k_years(1);
        }
        
        mstarDictionary = CSVReaderScript.starDictionary;
        ConstellationLoaderScript = ConstellationLoaderObj.GetComponent<ConstellationLoader>();
        Debug.Log("sidtime Contents of mstarDictionary:" + mstarDictionary.Count);
        Debug.Log("sidtime jumping ahead 10k years!");
        time_elapsed = time_elapsed+10000;

 
        Debug.Log("sidtime jumped ahead by 25k years!!");
        int currConstellation = ConstellationLoaderScript.currConstellation;
        if(currConstellation == 0)
        {
            ConstellationLoaderScript.loadModernConstellation(true);
        }
        else if(currConstellation == 1)
        {
            ConstellationLoaderScript.loadGreekConstellation(true);
        }
        else if( currConstellation == 2)
        {
            ConstellationLoaderScript.loadChineseConstellation(true);
        }
        else if( currConstellation == 3)
        {
            ConstellationLoaderScript.loadIndianConstellation(true);
        }
        else if( currConstellation == 4)
        {
            ConstellationLoaderScript.loadEgyptConstellation(true);
        }
        else if( currConstellation == 5)
        {
            ConstellationLoaderScript.loadNoConstellation(true);
        }

    }

    public void StartFunction()
    {
        // Start the coroutine and store a reference to it
        coroutine = StartCoroutine(CallFunctionRepeatedly());
    }

    public void StopFunction()
    {
        // Stop the coroutine if it's running
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

    }

    IEnumerator CallFunctionRepeatedly()
    {
        // Infinite loop to repeatedly call the function
        while (true)
        {
            // Call your function here
            forward_10_years();

            // Wait for 200 milliseconds before the next iteration
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void reset()
    {
        time_elapsed = 0;
        current_scale = 1;
        player.transform.position = new Vector3(0f, -1.5f, 0.5f);
        player.transform.rotation = Quaternion.Euler(0f, -180f, 0f);

        CSVReaderScript.new_reset();


        int currConstellation = ConstellationLoaderScript.currConstellation;
        if (currConstellation == 0)
        {
            ConstellationLoaderScript.loadModernConstellation(true);
        }
        else if (currConstellation == 1)
        {
            ConstellationLoaderScript.loadGreekConstellation(true);
        }
        else if (currConstellation == 2)
        {
            ConstellationLoaderScript.loadChineseConstellation(true);
        }

    }
        // Start is called before the first frame update
        void Start()
    {
        rev_time = false;
        time_elapsed = 0;
        current_scale = 1;
        starObjects = new List<GameObject>();
        CSVReaderScript = CSVReaderObj.GetComponent<CSV_reader>();
        if (CSVReaderScript.starDictionary == null)
        {
            Debug.LogError("sidtime CSVReaderScript is null!");
        }
        else
        {
            mstarDictionary = CSVReaderScript.starDictionary;
            Debug.Log("sidtime Contents of mstarDictionary:" + mstarDictionary.Count);
        }

        ConstellationLoaderScript = ConstellationLoaderObj.GetComponent<ConstellationLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
