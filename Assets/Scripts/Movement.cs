using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float MovSpeed = 5f;
    public float JumpPower = 3f;
    public float score = 0;

    Rigidbody2D rb;
    Animator anim;

    bool isGrounded = true;

    public GameObject PauseMenu;
    public GameObject YouLostPanel;
    public Text ScoreText;

    public GameObject BoxParticles;
    public GameObject MusicNoteParticles;
    public GameObject DustParticles;


    public AudioClip JumpSound;
    AudioSource SFX;

    public AudioClip BoxHit;
    public AudioClip TuneCollect;

    public GameObject DustInstantiationPoint;

   // public AudioSource Box;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SFX = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(this.gameObject.transform.position.y < -30f)
        {
            Destroy(this.gameObject);
            YouLostPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
           // MainSong.Stop();
        }

        ScoreText.GetComponent<Text>().text = score.ToString();

        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }

        if(MovSpeed > 16)
        {
            this.gameObject.GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        }
    }


    void FixedUpdate()
    {
        var Velocity = rb.velocity;
       
        Velocity.x = MovSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Velocity.y = JumpPower ;
            AudioSource.PlayClipAtPoint(JumpSound, this.gameObject.transform.position);
        }

        

        rb.velocity = Velocity;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "Ground" || col.transform.tag =="Ice" )
        {
        
            anim.SetBool("IsJumping", false);
            anim.SetFloat("Walk", 1);
            isGrounded = true;
           // Instantiate(DustParticles, DustInstantiationPoint.transform.position, Quaternion.identity);

        }
    }

    void OnCollisionExit2D(Collision2D coll )
    {
        if(coll.transform.tag == "Ground" || coll.transform.tag == "Ice")
        {

            anim.SetFloat("Walk", 0);
            anim.SetBool("IsJumping", true);
            isGrounded = false;

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag =="Box")
        {
            MovSpeed -= 2;
            SFX.PlayOneShot(BoxHit);
        }

       else if(col.transform.tag =="Enemy")
        {
            Destroy(this.gameObject);
            YouLostPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //MainSong.Stop();
        }

       else if(col.transform.tag =="Ice")
        {
            MovSpeed += 1;
        }

       /* else if (col.transform.tag == "Music")
        {
            score++;
            MovSpeed++;
        }*/




    }

    void OnTriggerEnter2D(Collider2D Coll)
    {
        if (Coll.transform.tag == "Music")
        {
            score++;
            MovSpeed++;
            Destroy(Coll.gameObject);
            SFX.PlayOneShot(TuneCollect);
            Instantiate(MusicNoteParticles, Coll.transform.position, Quaternion.identity);
        }
    }

    public void jumpp()
    {
        if (isGrounded)
        {
            var Velocity = rb.velocity;
            Velocity.y = JumpPower;
            rb.velocity = Velocity;
        }
    }
    
}
