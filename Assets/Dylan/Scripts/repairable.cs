using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repairable : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite repairedSprite;
    public Sprite brokenSprite;
    SpriteRenderer rend;
    SpriteRenderer healthBar;
    SpriteRenderer healthBarBack;
    GameObject repairIcon;
    
    [Header("Stats")]
    public bool isBroken;
    public float health;
    public float damage;
    public float repairSpeed;
    public float damageToSub;
    public float healthThreshHold;
    bool repairing;
    public float chanceForSkillCheck;

    [Header("Other")]
    public GameObject skillCheck;
    GameObject skillCheckParent;
    public roomController parentRoom;
    SubmarineHealth subController;
    bool playerInZone;
    PlayerInput _playerInput;
    bool inSkillCheck;
    GameObject skillcheckObj;
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = repairedSprite;
        healthBar = transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
        healthBarBack = transform.GetChild(2).GetChild(1).GetComponent<SpriteRenderer>();

        repairIcon = transform.GetChild(1).gameObject;
        playerInZone = false;

        _playerInput = new PlayerInput();
        _playerInput.Enable();

        enableHealthBar(2);

        subController = GameObject.Find("SubHealth").GetComponent<SubmarineHealth>();
        skillCheckParent = GameObject.Find("Canvas");
    }

	public void Update()
	{
		if(isBroken && playerInZone)
		{
			if (_playerInput.PlayerMap.Interact.inProgress)
			{
                health += repairSpeed;
                healthBar.size = new Vector2(health / 100, 1);
                repairing = true;

                float roll = Random.Range(0, 1f);
                if(roll < chanceForSkillCheck && !inSkillCheck)
				{
                   inSkillCheck = true;

                    spawnSkillCheck();
				}

                if(health >= 100)
				{
                    repaired();
				}
			}
			else
			{
                repairing = false;
			}
		}

		if (isBroken && !repairing)
		{
            health -= damage;
            if(health <= 0){ health = 0; }
            healthBar.size = new Vector2(health / 100, 1);
		}

        if(health <= healthThreshHold)
		{
            subController.TakeDamage(damageToSub);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player" && isBroken)
		{
            repairIcon.SetActive(true);
            playerInZone = true;
		}
    }

    private void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.tag == "Player" && isBroken)
		{
            repairIcon.SetActive(false);
            playerInZone = false;
            repairing = false;
			if (inSkillCheck)
			{
                skillcheckObj.GetComponent<skillCheck>().playerLeftEarly();
			}
		}
    }

	public void BreakDown()
	{
        isBroken = true;

        //turn the indicator on
        gameObject.GetComponent<IndicatorSystem>().isOn = true;
        rend.sprite = brokenSprite;
        enableHealthBar(1);
	}

    public void repaired()
	{
        isBroken = false;
        repairing = false;
        health = 100;

        //turn the indicator on
        gameObject.GetComponent<IndicatorSystem>().isOn = false;
        rend.sprite = repairedSprite;
        repairIcon.SetActive(false);
        playerInZone = false;
        parentRoom.removeIssue();
        enableHealthBar(2);

		if (inSkillCheck)
		{
            Destroy(skillcheckObj);
		}
	}

    void enableHealthBar(int i)
	{
        //if 1 enable if 2 disable
        if(i == 1)
		{
            healthBar.enabled = true;
            healthBarBack.enabled = true;
		}
		else
		{
            healthBar.enabled = false;
            healthBarBack.enabled = false;
		}
	}

    void spawnSkillCheck()
	{
        skillcheckObj = Instantiate(skillCheck, skillCheckParent.transform);
        skillcheckObj.GetComponent<skillCheck>().repairing = gameObject.GetComponent<repairable>();
	}

    public void skillCheckGains(float num)
	{
        health += num;
        inSkillCheck = false;

        if(health >= 100)
		{
            health = 100;
            repaired();
		}
		else if(health <= 0)
		{
            health = 0;
		}
	}
}
