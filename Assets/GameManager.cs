using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private int selecteZombieposition = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;
    public Text scoreText;
    private int score; 
    // Use this for initialization
    void Start () {
        SelectZombie (selectedZombie);
        scoreText.text = "Score : " + score;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("left"))
        {
            GetZombieLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            GetZombieRight();
        }
        if (Input.GetKeyDown("up"))
        {
            PushUp();
        }
    }

    void GetZombieLeft()
    {
        if(selecteZombieposition ==0)
        {
            selecteZombieposition = 3;
            SelectZombie(zombies[3]);
        }
        else
        {
            selecteZombieposition = selecteZombieposition - 1;
            SelectZombie(zombies[selecteZombieposition]);
        }
    }

    void GetZombieRight()
    {
        if (selecteZombieposition == 3)
        {
            selecteZombieposition = 0;
            SelectZombie(zombies[0]);
        }
        else
        {
            selecteZombieposition = selecteZombieposition + 1;
            SelectZombie(zombies[selecteZombieposition]);
        }
    }

    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;

    }

    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0,0,10,ForceMode.Impulse);
    }

    public void AddPoint ()
    {
        score = score + 1;
        scoreText.text = "Score : " + score;
    }
}
