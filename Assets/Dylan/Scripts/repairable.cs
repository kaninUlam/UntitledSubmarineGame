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

    bool playerInZone;
    PlayerInput _playerInput;
    public roomController parentRoom;

    

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
    }

	public void Update()
	{
		if(isBroken && playerInZone)
		{
			if (_playerInput.PlayerMap.Interact.inProgress)
			{
                health += repairSpeed;
                healthBar.size = new Vector2(health / 100, 1);

                if(health >= 100)
				{
                    repaired();
				}
			}
		}

		if (isBroken && !_playerInput.PlayerMap.Interact.inProgress)
		{
            health -= damage;
            healthBar.size = new Vector2(health / 100, 1);
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
        health = 100;

        //turn the indicator on
        gameObject.GetComponent<IndicatorSystem>().isOn = false;
        rend.sprite = repairedSprite;
        repairIcon.SetActive(false);
        playerInZone = false;
        parentRoom.removeIssue();
        enableHealthBar(2);
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
}
