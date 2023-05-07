using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPaused;

   [SerializeField] private float speed;
   [SerializeField] private float RunSpeed;

    private Player_itens Player_itens;

    private Rigidbody2D rig;

    private float InitialSpeed;   
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isCutting; 
    private bool _isRolling; 
    private bool _isDigging; 
    private bool _isWatering;
    
    [HideInInspector]public int handlingObj;
    internal Vector3 position;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }

    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }

    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    public bool isDigging
    {
        get { return _isDigging ; }
        set { _isDigging = value; }
    } 
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }
    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; } // ou public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    }

    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Player_itens = GetComponent<Player_itens>();
        InitialSpeed = speed; 
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }


            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDig();
            OnWatering();

        }

    }


    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
       
    }

    #region Movement 
    void OnInput()
    {
        _direction  = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }
    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = RunSpeed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = InitialSpeed;
            _isRunning = false;
        }
       

    }
    void OnCutting()
    {
        if(handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = InitialSpeed;
               
            }
        }
        else
        {
           isCutting = false;
        }

      
    }

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && Player_itens.currentWater > 0)
            {
               
                isWatering = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0) || Player_itens.currentWater < 0)
            {
                isWatering = false;
                speed = InitialSpeed;
            }

            if (isWatering)
            {
                Player_itens.currentWater -= 0.01f;
            }
        }
        else
        {
            isWatering = false;
        }


    }


    void OnDig()
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDigging = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDigging = false;
                speed = InitialSpeed;
            }

        }
        else
        {
            isDigging = false;
        }

       
    }
        
    
    
    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }


    }  
    #endregion
}
