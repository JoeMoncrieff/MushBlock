using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShurikenScript : MonoBehaviour, IPointerDownHandler
{
    public float moveSpeed = 8f;
    public float topBound = 8f;
    public float bottomBound = -8f;
    GameObject scoreKeeper;
    public bool isBackground = true;
    SpriteRenderer sprite;

    public bool isHit = false;
    public Vector2 hitVector;
    public Rigidbody2D rBody;
    public GameObject restartMenu;


    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        scoreKeeper = GameObject.Find("ScoreTracker");
        sprite = GetComponent<SpriteRenderer>();
        restartMenu = GameObject.Find("RestartMenu");
        
        
    }

    // Update is called once per frame
    void Update()
    {
  
        Move();
 
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        //on the upswing we want to check when it reaches the top
        if (isBackground && temp.y >= topBound)
        {
            moveSpeed = moveSpeed * (-1f);
            isBackground = false;
            sprite.color = new Color(1,1,1,1);
            Vector3 newScale = new Vector3(0.13f,0.13f,0);
            sprite.sortingOrder = 0;
            transform.localScale = newScale;
        } else if ((!isBackground || isHit) && temp.y <= bottomBound)
        {
            gameObject.SetActive(false);
        }

        transform.position = temp;
    }
    
    // This is the code that's triggered when we click on a shuriken before it hits a mushroom
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isBackground)
        {
            isHit = true;
            rBody.gravityScale = 8;
            rBody.isKinematic = false;
            isBackground = true;
            rBody.AddForce(hitVector);
            moveSpeed = 0f;

            SoundManager.instance.shurikenHitSound();
            scoreKeeper.GetComponent<ScoreTracker>().ScoreUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (!isBackground)
            {
                moveSpeed = 0f;
                //TODO put lose condition call here
                restartMenu.GetComponent<RestartMenu>().triggerRestartMenu();
            }
        }
    }
}
