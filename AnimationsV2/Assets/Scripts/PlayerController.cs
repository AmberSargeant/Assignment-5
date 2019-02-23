using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera thirdCamera;
    private int count;
    public GameObject key;
    private bool open;
    public GameObject onigiri;
    public Animator door;
    ParticleSystem particles;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        count = 0;
        open = false;


    }
    //fixed update goes before any physics code
    //unlike update
    private void Update()
    {
        //grabs the input from our player through the keyboard
        //float variables record input on the horizontal and vertical axis
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);*/
        float x; float y;
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Vector3 rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        float side = Input.GetAxis("Horizontal");   
        float fwd = Input.GetAxis("Vertical");
        Vector3 moveValue = new Vector3(side, 0, fwd);
        rb.MovePosition(transform.position + moveValue * Time.deltaTime * 20);
        if (fwd != 0 || side != 0)
        {

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);


        }
       
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("First"))
        {
            firstCamera.enabled = true;
            secondCamera.enabled = false;
            thirdCamera.enabled = false;
        }
        else if (other.gameObject.CompareTag("Second"))
        {
            firstCamera.enabled = false;
            secondCamera.enabled = true;
            thirdCamera.enabled = false;
        }
        else if (other.gameObject.CompareTag("Third"))
        {
            firstCamera.enabled = false;
            secondCamera.enabled = false;
            thirdCamera.enabled = true;
            LoadByIndex(0);
        }
        if (other.gameObject.CompareTag("Onigiri"))
        {
            other.gameObject.SetActive(false);
            count++;
            RecieveKey();
         
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            count++;
            RecieveKey();
        }
        if (other.gameObject.CompareTag("DoorOpen"))
        {
            if (open){
                door.SetBool("open", true);
            }
            // door.SetBool("open", false);
        }
        if (other.gameObject.CompareTag("DoorClose"))
        {
            door.SetBool("open", false);
        }
    }

    void RecieveKey()
    {
        if (count == 3)
        {
            key.SetActive(true);

        }
        if (count == 4)
        {
            open = true;
        }
    }
    void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
