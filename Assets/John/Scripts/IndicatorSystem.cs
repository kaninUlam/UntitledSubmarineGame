using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSystem : MonoBehaviour
{

    public GameObject Indicator;
    public GameObject Target;

    Renderer rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if target is not visible to camera
        if(rd.isVisible == false)
        {
            if(Indicator.activeSelf == false)
            {
                Indicator.SetActive(true);
            }

            // direction of where the ray cast should point towards
            Vector2 direction = Target.transform.position - transform.position;

            //creates a ray cast that will hit the player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);


            //a check if the ray cast has hit something for example the player.
            if(ray.collider != null)
            {
                Indicator.transform.position = ray.point;
                Debug.Log(ray.point);
            }

            //if the target is visible to the camera 
            else
            {
                if (Indicator.activeSelf == true)
                {
                    Indicator.SetActive(false);
                }
            }
        }
    }
}
