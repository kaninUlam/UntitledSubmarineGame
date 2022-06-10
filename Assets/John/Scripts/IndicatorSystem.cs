using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSystem : MonoBehaviour
{
    //johns Variables
    public GameObject Indicator;
    public GameObject Target;
    public bool isOn;

    Renderer rd;


    //Dylans Variables
    Vector3 targetPosition;
    public RectTransform pointerRefrence;
    [SerializeField] private Camera uiCamera;

    // Start is called before the first frame update
    void Start()
    {
        //john
        rd = GetComponent<Renderer>();
        isOn = false;

        //Dylan
        targetPosition = gameObject.transform.position;
        

        uiCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isOn)
		{
            DylanMethod();
		} 
    }

    public void johnsMethod()
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
                }else //if the target is visible to the camera 
                {
                    if (Indicator.activeSelf == true)
                    {
                        Indicator.SetActive(false);
                    }
                }
            }
	}

    public void DylanMethod()
	{
        //Indicator.SetActive(true);
        Vector3 toPos = targetPosition;
        Vector3 fromPos = Camera.main.transform.position;
        fromPos.z = 0f;
        Vector3 dir = (toPos - fromPos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0){ angle += 360; }
        //pointerRefrence.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 50;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.x >= Screen.height - borderSize;

		if (isOffScreen)
		{
            Vector3 cappedTargetScreenPos = targetPositionScreenPoint;
            if (cappedTargetScreenPos.x <= borderSize) cappedTargetScreenPos.x = borderSize;
            if (cappedTargetScreenPos.x >= Screen.width - borderSize) cappedTargetScreenPos.x = Screen.width - borderSize;
            if (cappedTargetScreenPos.y <= borderSize) cappedTargetScreenPos.y = borderSize;
            if (cappedTargetScreenPos.y >= Screen.height - borderSize) cappedTargetScreenPos.y = Screen.height - borderSize;

            Vector3 pointerWorldPos = uiCamera.ScreenToWorldPoint(cappedTargetScreenPos);
            pointerRefrence.position = pointerWorldPos;
            pointerRefrence.localPosition = new Vector3(pointerRefrence.localPosition.x, pointerRefrence.localPosition.y, 0);
		}
		else
		{
            Vector3 pointerWorldPos = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            pointerRefrence.position = pointerWorldPos;
            pointerRefrence.localPosition = new Vector3(pointerRefrence.localPosition.x, pointerRefrence.localPosition.y, 0);
		}
	}
}
