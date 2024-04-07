using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CAVE2ClusterManager;

public class ExoMatSwitcher : MonoBehaviour
{
    // First array of materials
    public Material[] StarMaterials = new Material[7];

    // Second array of materials
    public Material[] ExoMaterials = new Material[7];

    public bool show_exo;
    // Start is called before the first frame update
    void Start()
    {
        show_exo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show_exo_planets(bool showexo)
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("star"); // Get all game objects tagged with "star"

        foreach (GameObject star in stars)
        {
            // Accessing the starmeta data script
            starMetaData starScript = star.GetComponent<starMetaData>();

            if (starScript != null)
            {
                if (show_exo)
                {
                    // Access planet_count and do TODO
                    int planetCount = starScript.planet_count;
                    Renderer renderer = star.GetComponent<Renderer>();
                    switch (planetCount)
                    {
                        case 0:
                            renderer.material = ExoMaterials[0];
                            break;

                        case 1:
                            renderer.material = ExoMaterials[1];
                            break;

                        case 2:
                            renderer.material = ExoMaterials[2];
                            break;

                        case 3:
                            renderer.material = ExoMaterials[3];
                            break;

                        case 4:
                            renderer.material = ExoMaterials[4];
                            break;

                        case 5:
                            renderer.material = ExoMaterials[5];
                            break;

                        case 6:
                            renderer.material = ExoMaterials[6];
                            break;

                        default:
                            Debug.Log("Value is not 1, 2, or 3");
                            break;
                    }
                }
                else
                {
                    // Access spec and do TODO2
                    char spec = starScript.spectrum;
                    Renderer renderer = star.GetComponent<Renderer>();
                    switch (spec)
                    {
                        case 'O':
                            renderer.material = StarMaterials[0];
                            break;

                        case 'B':
                            renderer.material = StarMaterials[1];
                            break;

                        case 'A':
                            renderer.material = StarMaterials[2];
                            break;

                        case 'F':
                            renderer.material = StarMaterials[3];
                            break;

                        case 'G':
                            renderer.material = StarMaterials[4];
                            break;

                        case 'K':
                            renderer.material = StarMaterials[5];
                            break;

                        case 'M':
                            renderer.material = StarMaterials[6];
                            break;

                        default:
                            Debug.Log("Value is not 1, 2, or 3");
                            break;
                    }

                }
            }
        }
    }

    public void toggle_exo()
    {
        if(show_exo)
        {
            show_exo = false;
        }
        else
        {
            show_exo = true;
        }

        show_exo_planets(show_exo);
    }

    public void update_exo()
    {
        show_exo_planets(show_exo);
    }
}
