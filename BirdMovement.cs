using UnityEngine;
public class BirdMovement : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;
	
	public bool didFlap = false;
	
	public Animator animator;
	
	public bool dead = false;
	float deathCooldown;
	
	public bool godMode = false;
	
	// Values to set: Touch
	public float comfortZone = 70.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 0.5f;
	
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;

	private float time = 0.0f;

	public SwipeDirection lastSwipe = BirdMovement.SwipeDirection.None;
	public float lastSwipeTime;
	
	public enum SwipeDirection {
		None,
		Up,
		Down
	}

	
	float velocityOfSwipe=0;


	//Touch control initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		
		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}


	}


	public AudioClip swoosh;
	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;
			
			if(deathCooldown <= 0) {
				AutoFade.LoadLevel("EndMenu" ,0.5f,0.5f,Color.white);  
			}
		}
		else {
			/*if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
			}*/
			if (Input.touchCount > 0)
			{
				Touch touch = Input.touches[0];
				
				switch (touch.phase)
				{
				case TouchPhase.Began:
					lastSwipe = BirdMovement.SwipeDirection.None;
					lastSwipeTime = 0;
					couldBeSwipe = true;
					startPos = touch.position;
					startTime = Time.time;
					break;
					
				case TouchPhase.Moved:
					if (Mathf.Abs(touch.position.x - startPos.x) > comfortZone)
					{
						Debug.Log("Not a swipe. Swipe strayed " + (int)Mathf.Abs(touch.position.x - startPos.x) +
						          "px which is " + (int)(Mathf.Abs(touch.position.x - startPos.x) - comfortZone) +
						          "px outside the comfort zone.");
						couldBeSwipe = false;
					}
					break;
				case TouchPhase.Ended:
					if (couldBeSwipe)
					{
						float swipeTime = Time.time - startTime;
						float swipeDist = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
						
						if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
						{
							// Swipe
							GetComponent<AudioSource>().PlayOneShot(swoosh,0.9f);
							float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
							
							// If positive swipe direction = upward swipe.
							// If negative swipe direction = downward swipe.
							if (swipeValue > 0){
								lastSwipe = BirdMovement.SwipeDirection.Up;
								didFlap = true;
								velocityOfSwipe = swipeDist/swipeTime/50;
							}
							else if (swipeValue < 0){
								lastSwipe = BirdMovement.SwipeDirection.Down;
								didFlap = true;
								velocityOfSwipe = -swipeDist/swipeTime/50;
							}
							lastSwipeTime = Time.time;
						}
					}
					break;
				}
			}
			
			
		}
	}
	

	// physics engine updates here
	void FixedUpdate () {
		
		if(dead)
			return;
		
		GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );
		animator.SetTrigger("DoFlap");
		if(didFlap) {
			/*rigidbody2D.velocity = Vector2.right;
				rigidbody2D.AddForce( Vector2.up * flapSpeed );
				animator.SetTrigger("DoFlap");
				didFlap = false;*/
			if(velocityOfSwipe != 0){
				GetComponent<Rigidbody2D>().AddForce( Vector2.up * velocityOfSwipe );
				didFlap = false;
			}
			
		}
		
		if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			float angle = Mathf.Lerp (0, 55, (GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
	

	public AudioClip impact1;
	public AudioClip impact2;
	public AudioClip impact3;
	public AudioClip impact4;
	public AudioClip impact5;
	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;
		GameObject soundObject = GameObject.Find("Music");
		AudioSource audioSource = soundObject.GetComponent<AudioSource>();
		audioSource.Pause ();
		int which = Random.Range (1, 6);
		if(which ==1)
			GetComponent<AudioSource>().PlayOneShot(impact1,0.4f);
		if(which ==2)
			GetComponent<AudioSource>().PlayOneShot(impact2);
		if(which ==3)
			GetComponent<AudioSource>().PlayOneShot(impact3);
		if(which ==4)
			GetComponent<AudioSource>().PlayOneShot(impact4);
		if(which ==5)
			GetComponent<AudioSource>().PlayOneShot(impact5);
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
}
