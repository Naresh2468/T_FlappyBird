using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public Vector3 direction;
    public float gravity = -9.81f;
    public float PlayerMoveSpeed = 2.0f;
    public float BoostUpSpeed = 1.0f;
    //public bool IsBoostUp = false;
    public float jumpSpeed;

    Rigidbody myRigidbody;
    public float leftSideEndx = -1.3f;
    public float RightSideEndx = 1.3f;
    public float UpSideEndy = 4.82f;
    public float DownSideEndy = -1.50f;
    public float GameOverRange = -1.30f; 
   
    public float horizontalMultiplier = 1.5f;

    public Vector3 rotationSpeed = new Vector3(0,10,0);

    public bool isPlayGame = false;

    public GameObject Feather1;
    public GameObject Feather2;
    public GameObject Feather3;

    [Header("GroundCheck")]
    public bool grounded = false;
   

    [Header("PlayerGameOver Varabile")]
    public GameObject Trigger;

    public BirdDamage birdDamage;
    public int BirdDamage = 100;

    public BoxCollider myCollider;

    public Animator BirdAnimate;
 
    public float dirZ;

   [Header("CoinCollection")]

    public TMP_Text coinScore;
    public AudioSource myAudio;
    public AudioClip coinClip;
    public int CoinScoreNum;
    public GameObject Coins;

    [Header("DiamondsCollection")]

    public TMP_Text diamondScore;
    public AudioClip DimaondCLip;
    public int DiamondScoreNum;

    //[Header("GroundCheck")]
    // public Transform groundCheckTransform;
    // public LayerMask groundPlatformLayer;
    // public float groundCheckDistance = 0.2f;
    // [SerializeField]private bool isGrounded = false;


    // [Header("Player Score")]
    // public TMP_Text currentScoreText;
    // public static int scoreCount = 0;

    [Header("Others Scripts")]
    public GameMenu gameMenu;
    public PlayerInput playerInput;
    public TMP_Text StartText;
    // public ScoreManager scoreManager;


    [Header("PowerUpClips")]
    public AudioClip PowerUpPickupClip;
    public AudioClip BoostupClip;
    public AudioClip ShuntAttackClip;
    public AudioClip ShieldClip;
    public AudioClip FirstAidClip;

    [Header("BoostUp")]
    public bool IsBoostUpActive = false;

    [Header("FirstAid")]
    public bool FirstAidActivate = false;

    [Header("ShuntFire ATTack")]
    public bool IsShuntAttack = false;
    public GameObject ShuntAttackPrefabs ;
    public Transform PowerUpTransformPoint;
    public float ShuntSpeed = 0.6f;

    [Header("Shield PowerUp")]
    [SerializeField]private float shieldTimer ;
    public GameObject shieldPrefab;
    
    [SerializeField]private GameObject activeShield;
    public bool IsTimer = false;
    [SerializeField]public bool ShieldActivate = false;

    private bool isShieldActive = false;
    public int maxShieldDamage = 5; // Maximum shield damage to apply
    
    [Header("Alert_Message ")]
    public TMP_Text alertMessage;

    private void Start() {
        BirdAnimate = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>(); 
        myCollider = GetComponent<BoxCollider>();
        birdDamage = GetComponent<BirdDamage>();
        myAudio = GetComponent<AudioSource>();
        playerInput = GetComponent<PlayerInput>();
        activeShield.SetActive(false);
        shieldPrefab.SetActive(false);
        StartText.gameObject.SetActive(true);
       
        

        CoinScoreNum = 0;
        coinScore.text = CoinScoreNum.ToString();

        DiamondScoreNum = 0;
        diamondScore.text = ""+DiamondScoreNum;
    }
   
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Return  key in PC also called Enter key
        {
            StartText.gameObject.SetActive(false);
           isPlayGame = true;
        }
        
        PlayerController();
        BoostUp();
        //PowerUp
        FirstAidPowerUp();
        
        PowerUpFire();
        ShieldUP();
       
        Timer();

    }
    
    public void PlayerController()
    {
        if (isPlayGame == true && grounded == true)
        {
             BirdAnimate.SetTrigger("ExitIdle");   
        }
        if (isPlayGame == true )
        {   
            if (grounded == true)
            {
                 BirdAnimate.SetTrigger("ExitIdle"); 
            }
            else
            {
                BirdAnimate.SetTrigger("Idle");
            }
            float translation = Input.GetAxis("Vertical")*PlayerMoveSpeed * Time.deltaTime;
            myRigidbody.velocity = new Vector3(translation,myRigidbody.velocity.y,PlayerMoveSpeed);

            if (IsBoostUpActive == true && Input.GetKeyDown(KeyCode.Alpha4 ))
            {
                myCollider.enabled = false;
                myRigidbody.isKinematic = true;
                float boostSpeedModifier = 2.5f;
                float translationWithBoost = Input.GetAxis("Vertical") * (PlayerMoveSpeed + boostSpeedModifier) * Time.deltaTime;
                myRigidbody.velocity = new Vector3(translation,myRigidbody.velocity.y,translationWithBoost);
            
            //transform.Translate(0,0,1f);
            }
            else
            {
                myCollider.enabled = true;
                myRigidbody.isKinematic = false;
               
                myRigidbody.velocity = new Vector3(translation,myRigidbody.velocity.y,translation);
                
            }
             
         
            PlayerSpeed();
           
            

         

            float dirX = 0f;

            // if (playerInput.actions["Leftt_BM"].triggered)
            // {
            //     float moveAmount = horizontalMultiplier * Time.deltaTime;
            //     myRigidbody.velocity = new Vector3(-moveAmount,0f,translation);
            //     dirX = -moveAmount; 
    
            // }
            // else if (playerInput.actions["Right_BM"].triggered)
            // {
            //     float moveAmount = horizontalMultiplier * Time.deltaTime;
            //     myRigidbody.velocity = new Vector3(moveAmount,0f,translation); 
            //     dirX = moveAmount;

            // }


            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)   )
            {
                myRigidbody.velocity = new Vector3(-horizontalMultiplier,0f,translation);
                dirX = -horizontalMultiplier; 
            
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )
            {
                
            myRigidbody.velocity = new Vector3(horizontalMultiplier,0f,translation);
            
                dirX = horizontalMultiplier;
            
            }
            
            Vector3 movement = new Vector3(dirX, 0f, translation);
            myRigidbody.velocity += movement;
            myRigidbody.velocity = new Vector3(dirX,myRigidbody.velocity.y,PlayerMoveSpeed);


            // Restrict the player's position within the specified range
            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.Clamp(currentPosition.x, leftSideEndx, RightSideEndx);
            Vector3 currentPositionY = transform.position;
            currentPositionY.y = Mathf.Clamp(currentPositionY.y,  DownSideEndy, UpSideEndy);
            transform.position = currentPosition;
            transform.position = currentPositionY;
        
            if (Input.GetKeyDown(KeyCode.UpArrow) || playerInput.actions["Jump_BM"].triggered)
            {
                myRigidbody.velocity = new Vector3(translation,jumpSpeed);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                gameMenu.RestartLevelEvent();
                //SceneManager.LoadScene("Game");
            }

            if (currentPositionY.y < GameOverRange)
            {
                SceneManager.LoadScene("Game");
            }

         
             
        
        }
        else
        {
           
        }  
           
    }
    // private void OnDrawGizmosSelected() 
    // {

    //     if (groundCheckTransform != null)
    //     {
    //         Gizmos.color  = Color.green;
    //         Gizmos.DrawLine(groundCheckTransform.position , groundCheckTransform.position + Vector3.down * groundCheckDistance);
    //     }   
    // }
    public void PlayerSpeed()
    {
        // Player SpeedUp By Coins

                if (CoinScoreNum > 500)
                {
                    PlayerMoveSpeed = 5.0f;

                }
                else if (CoinScoreNum > 450)
                {
                    PlayerMoveSpeed = 4.8f;
                }
                else if (CoinScoreNum > 400)
                {
                    PlayerMoveSpeed = 4.5f;
                }
                else if (CoinScoreNum > 350)
                {
                    PlayerMoveSpeed = 4.2f;
                }
                else if (CoinScoreNum > 300)
                {
                    PlayerMoveSpeed = 4.0f;
                }
                else if (CoinScoreNum > 250)
                {
                    PlayerMoveSpeed = 3.8f;
                }
                else if (CoinScoreNum > 200)
                {
                    PlayerMoveSpeed = 3.5f;
                }
                else if (CoinScoreNum > 150)
                {
                    PlayerMoveSpeed = 3.2f;
                }
                else if (CoinScoreNum > 80)
                {
                    PlayerMoveSpeed = 3.0f;
                }
                else if (CoinScoreNum > 40)
                {
                    PlayerMoveSpeed = 2.2f;
                }
                else
                {
                    PlayerMoveSpeed = 1.5f;
                }
    }
    public void PowerUpFire()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && IsShuntAttack == true && IsBoostUpActive == false)
        {
             myAudio.PlayOneShot(ShuntAttackClip, 1);
            Vector3 spawnPosition = PowerUpTransformPoint.position + PowerUpTransformPoint.forward ;
            Quaternion spawnRotation = PowerUpTransformPoint.rotation;

            var Shunt = Instantiate(ShuntAttackPrefabs ,spawnPosition, spawnRotation);
            Shunt.GetComponent<Rigidbody>().velocity = PowerUpTransformPoint.forward * ShuntSpeed;

            Debug.Log("FireBall");
            IsShuntAttack = false;
        }
    }

    //Shield Effects
    public void ShieldUP()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && ShieldActivate == true && IsBoostUpActive == false )
        {
             myAudio.PlayOneShot(ShieldClip, 1);
            ActivateShield(20f);
            IsTimer = true;
            isShieldActive = true;
      
             
        }
       
     
        if (isShieldActive == true)
        {
           Timer();
            if (shieldTimer <= 0f)
            {
                DeactivateShield();
                
            }
        }

        
    }
    public void Timer()
    {
        if (IsTimer == true)
        {
            shieldActiveTimer();
        }
    }
    public void shieldActiveTimer()
    {
         shieldTimer -= Time.deltaTime;
        // float remainingTimeRatio = (shieldTimer / 20f )*Time.deltaTime;
        // int damageToApply = Mathf.CeilToInt(maxShieldDamage * (1f - remainingTimeRatio));
        // //Mathf.CeilToInt function is used to round up the damage amount to ensure that some damage is always applied
        //birdDamage.ShieldDamage(damageToApply);  


         
            // int numberOfDamageApplications = Mathf.FloorToInt((maxShieldDamage - shieldTimer) / maxShieldDamage) + 1;
            
            // for (int i = 0; i < numberOfDamageApplications; i++)
            // {
            //     birdDamage.ShieldDamage(5); // Apply shield damage
            // }
            
              
       
    }
    public void ActivateShield(float duration)
    {
    
            // activeShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
           
            activeShield.SetActive(true);
            shieldPrefab.SetActive(true);
            shieldTimer = duration;
        
       
    }
    private void DeactivateShield()
    {
        isShieldActive = false;
        ShieldActivate = false;
        IsTimer = false;
        shieldTimer = 0f;  
        myAudio.Stop();
        activeShield.SetActive(false);
        shieldPrefab.SetActive(false);
      
       
    }



    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Grounded")
        {
            Debug.Log("grounded Enter");
            grounded = true;
        }
        
        if (other.gameObject.tag == "Obstacle" && isShieldActive == false)
        {
            BirdAnimate.SetTrigger("Hit");
            if (birdDamage != null)
            {
                birdDamage.TakeDamage(2); // Decrease health by 10 (you can change the value as needed)
                BirdAnimate.SetTrigger("Hit");
                BirdDamage = BirdDamage - 2;
                StartCoroutine(DamageEffects());
                myCollider.enabled = false;
                myRigidbody.isKinematic = true;
                transform.Translate(0,0,0.4f);
                Debug.Log("Damages");
              

            }
            else
            {
                myCollider.enabled = true;
                myRigidbody.isKinematic = false;
                Debug.LogWarning("BirdDamage script not found on Bird GameObject.");
            }

            Debug.Log("Damage Applied");
           
        }
        
    }
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Grounded")
        {
            Debug.Log("grounded Exit");
            grounded = false;
        }
        
    }
    public void FirstAidPowerUp()
    {
        if ( Input.GetKeyDown(KeyCode.Alpha3) && FirstAidActivate == true && BirdDamage < 90 )
        {
            myAudio.PlayOneShot(FirstAidClip, 1);
            BirdDamage = 100;
            birdDamage.HealthIncreased();
            FirstAidActivate = false;
        }
        else
        {
            if ( Input.GetKeyDown(KeyCode.Alpha3) && FirstAidActivate == true && BirdDamage > 90)
            {
                string message = "Health is not to low";
                Color textColor = Color.green;
                StartCoroutine(AlertMessageDuration(alertMessage, message, textColor));
            }
        }
       
    }
    public void BoostUp()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4 ) &&  IsBoostUpActive ==  true && isShieldActive == false && IsShuntAttack == false )
        {
            StartCoroutine(BoostUpController());
        }
        //PlayerSpeedUp By Boostup
       
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Coins")
        {
            CoinScoreNum = CoinScoreNum + 1 ;  // Increment the coin score
            coinScore.text = ""+CoinScoreNum.ToString();
            myAudio.PlayOneShot(coinClip, 1);
            
         
        }if(other.gameObject.tag == "Diamond")
        {
            DiamondScoreNum = DiamondScoreNum + 1 ;  // Increment the coin score
            diamondScore.text = ""+DiamondScoreNum.ToString();
            myAudio.PlayOneShot(DimaondCLip, 1);
            
         
        }
        if(other.gameObject.tag == "BoostUp" && IsBoostUpActive == false)
        { 
            myAudio.PlayOneShot(PowerUpPickupClip, 1);
            IsBoostUpActive = true;
            
        }
        if(other.gameObject.tag == "FirstAidPowerUp" && FirstAidActivate == false)
        { 
            FirstAidActivate = true;
            myAudio.PlayOneShot(PowerUpPickupClip, 1);
            
          
        }
        if (other.gameObject.tag == "ShuntAttack" && IsShuntAttack ==  false)
        {
            myAudio.PlayOneShot(PowerUpPickupClip, 1);
            IsShuntAttack = true;
            Destroy(other.gameObject);
        }
        // if (other.gameObject.tag == "Magnet")
        // {
        //     myAudio.PlayOneShot(BoostupClip, 1);
        //     Destroy(other.gameObject);
        // }
        if (other.gameObject.tag == "Shield" && ShieldActivate == false)
        { 
            ShieldActivate = true; 
            birdDamage.SheildHealthIncreased();
           myAudio.PlayOneShot(PowerUpPickupClip, 1);    
            Debug.Log("Shield");  
        }
        
        
    }
    
    IEnumerator BoostUpController()
    {
       // IsBoostUp = true;
        IsBoostUpActive = true;
        yield return new WaitForSeconds (2);
        //IsBoostUp = false;
        IsBoostUpActive = false;
    }
    IEnumerator DamageEffects()
    {
        Feather1.SetActive(true);
        Feather2.SetActive(true);
        Feather3.SetActive(true);
        yield return new WaitForSeconds(1);
        Feather1.SetActive(false);
        Feather2.SetActive(false);
        Feather3.SetActive(false);
    }
    IEnumerator AlertMessageDuration(TMP_Text messageText , string messageToDisplay, Color textColor)
    {
        messageText.color = textColor;
        messageText.text = messageToDisplay;
        yield return new WaitForSeconds(4);
        alertMessage.text = "";

    }
   
}
