using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public GameManager manager;

	public float moveSpeed;
	private Vector3 input;
	private float maxSpeed = 10f;
	private Vector3 spawn;
	public GameObject deathParticles;
	public bool useManager = true;

    bool goUp, goDown, goLeft, goRight = false;
	public AudioClip[] audioClip;
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		if (useManager) {
			manager = manager.GetComponent<GameManager> ();
				}

	}
	
	// Update is called once per frame
	void Update () {

        if(goUp && !goDown && !goLeft && !goRight)
        {
            transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed);
        }else if(!goUp && goDown && !goLeft && !goRight)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime*moveSpeed);
        }
        else if (!goUp && !goDown && goLeft && !goRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (!goUp && !goDown && !goLeft && goRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (transform.position.y < -2) {
			Die();
				}
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            Die();
        }

    }
    void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "enemy") {
			Die();
				}
		if (other.transform.tag == "Token") {
			if(useManager)
			{
				manager.tokenCount += 1;

			}
			PlaySound(0);
            Debug.Log("playing sound");
			Destroy(other.gameObject);
			}
		if (other.transform.tag == "Goal") {
			PlaySound(1);
			Time.timeScale = 0f;
			manager.CompleteLevel();
		}
		}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip [clip];
		GetComponent<AudioSource>().Play();
		}
	void Die()
	{
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));
		            transform.position = spawn;
	}
    public void MoveUpTrue()
    {
        goUp = true;
        //if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        //{
        //    GetComponent<Rigidbody>().AddForce(input * moveSpeed);

        //}

    }
    public void MoveUpFalse()
    {
        goUp = false;
        //if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        //{
        //    GetComponent<Rigidbody>().AddForce(input * moveSpeed);

        //}

    }
    public void MoveDownTrue()
    {
        goDown = true;

    }
    public void MoveDownFalse()
    {
        goDown = false;

    }
    public void MoveLeftTrue()
    {
        goLeft = true;
    }
    public void MoveLeftFalse()
    {
        goLeft = false;
    }
    public void MoveRightTrue()
    {
        goRight = true;

    }
    public void MoveRightFalse()
    {
        goRight = false;

    }
	public void GotoMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
}
