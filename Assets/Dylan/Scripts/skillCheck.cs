using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillCheck : MonoBehaviour
{
    public RectTransform pointer;
    public float pointerSpeed;
    bool goingForward;

	public float minOkayValue;
	public float maxOkayValue;
	public float minPerfectValue;
	public float maxPerfectValue;

	public float OkayGain;
	public float PerfectGain;
	public float MissGain;

	PlayerInput playerInput;

	public repairable repairing;


    // Start is called before the first frame update
    void Start()
    {
        goingForward = true;

		playerInput = new PlayerInput();
        playerInput.Enable();
    }

	// Update is called once per frame
	void Update()
	{
		float speed;
		if (goingForward){ speed = pointerSpeed; }
		else{ speed = pointerSpeed * -1; }

		pointer.localPosition = new Vector3(pointer.localPosition.x + speed, pointer.localPosition.y, pointer.localPosition.z);

		if(goingForward && pointer.localPosition.x >= 150){ goingForward = false; }
		else if(!goingForward && pointer.localPosition.x <= -150){ goingForward = true; }

		if (playerInput.PlayerMap.SkillCheck.triggered)
		{
			checkHit();
		}
	}

	void checkHit()
	{
		float value = interpolateValue(); 

		if(value >= minOkayValue && value < maxOkayValue)
		{
			repairing.skillCheckGains(OkayGain);
		}else if(value >= minPerfectValue && value < maxPerfectValue)
		{
			repairing.skillCheckGains(PerfectGain);
		}
		else
		{
			repairing.skillCheckGains(MissGain);
		}

		Destroy(gameObject);
	}


	float interpolateValue()
	{
		float lerpVal = (pointer.localPosition.x - (-150)) / (150 - (-150));

		return lerpVal;
	}

	public void playerLeftEarly()
	{
		repairing.skillCheckGains(MissGain);
		Destroy(gameObject);
	}
}
