using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AstroController : MonoBehaviour
{
    Animator animator;
    public static GameObject player;
    public static GameObject currentPlatfrom;
    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false;
    public static Rigidbody rBody;

    public GameObject magic;
    public Transform magicStartPos;
    Rigidbody magicRBody;

    int livesLeft;
    public Texture aiveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    public GameObject gameOverPanel;

    public Text highestScore;

    void restartGame()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    private void OnCollisionEnter(Collision other)
    {
        if((other.gameObject.tag == "Fire" || other.gameObject.tag == "Wall") && !isDead )
        {
            animator.SetTrigger("isDead");
            isDead = true;
            livesLeft--;
            PlayerPrefs.SetInt("lives", livesLeft);
            if(livesLeft > 0)
            {
                Invoke("restartGame", 2f);
            }
            else
            {
                //Game Over
                icons[0].texture = deadIcon;
                gameOverPanel.SetActive(true);
                PlayerPrefs.SetInt("lastScore", PlayerPrefs.GetInt("score"));
                if(PlayerPrefs.HasKey("highestScore"))
                {
                    if(PlayerPrefs.GetInt("highestScore") < PlayerPrefs.GetInt("score"))
                    {
                        PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
                }
            }
        }
        else
        {
            currentPlatfrom = other.gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = this.gameObject;
        startPosition = player.transform.position;
        GenerateWorld.runDummy();
        rBody = this.GetComponent<Rigidbody>(); 
        magicRBody = magic.GetComponent<Rigidbody>();
        isDead = false;
        livesLeft = PlayerPrefs.GetInt("lives");
        for(int i = 0; i < icons.Length; i++)
        {
            if(i>= livesLeft)
            {
                icons[i].texture = deadIcon;
            }
        }
        if(PlayerPrefs.HasKey("highestScore"))
        {
            highestScore.text = $"Highest : {PlayerPrefs.GetInt("highestScore")}";
        }
        else
        {
            highestScore.text = $"Highest : 0";
        }

    }

    void castMagic()
    {
        if(isDead)
        {
            return;
        }
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        magicRBody.AddForce(this.transform.forward*20000);
        Invoke("killMagic", 2f);
    }

    void killMagic()
    {
        magic.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
        {
            GenerateWorld.runDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is SphereCollider)
        {
            canTurn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            rBody.AddForce(Vector3.up * 80000);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("isMagic", true);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(0, 90, 0);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.runDummy();
            player.transform.position = new Vector3(startPosition.x, player.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn )
        {
            this.transform.Rotate(0, -90, 0);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.runDummy();
            player.transform.position = new Vector3(startPosition.x, player.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.4f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.4f, 0, 0);
        }

        PlayerPrefs.SetInt("lastScore", PlayerPrefs.GetInt("score"));
        if (PlayerPrefs.HasKey("highestScore"))
        {
            if (PlayerPrefs.GetInt("highestScore") < PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
        }

        if (PlayerPrefs.HasKey("highestScore"))
        {
            highestScore.text = $"Highest : {PlayerPrefs.GetInt("highestScore")}";
        }
        else
        {
            highestScore.text = $"Highest : 0";
        }
    }

    void stopJump()
    {
        animator.SetBool("isJumping", false);
    }

    void stopMagic()
    {
        animator.SetBool("isMagic", false);
    }
}
