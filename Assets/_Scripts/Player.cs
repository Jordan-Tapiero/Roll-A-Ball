using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 12f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;
    private int count;
    private int score;



    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void SetCountText()
    {
        countText.text = "Count:" + score.ToString();
        if (score >= 35)
        {
            winTextObject.SetActive(true);
            FindObjectOfType<GameManager>().EndGame();

        }
    }


    //FixedUpade is called once every physics update  (it is reliable so it is in sync regardless of the frequency of the computer)
    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);


        rigidbodyComponent.AddForce(movement * speed*2);



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = (int)other.GetComponent<PickUps>().PickUpsPoints;
            score += count;
            SetCountText();
        }


    }

}