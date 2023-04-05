using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MobileJoyStick joystickInput;
    public Transform playerObject;
    public GameObject beeBasePos;
    public GameObject beeSprite;
    public GameObject beeBaseRot;
    public float speed = 9;

    public void getMult(int mult)
    {
        float multf = (float) mult;
        speed = 9 * ((multf/100)+0.5f);
    }

    private void Start()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void Update()
    {
        if (this.transform.position.x < -7.25 || this.transform.position.x > 7.25)
        {
            transform.position = new Vector3(0f, -4.85f, 0f);
        }

        if (this.transform.position.y > -4.86 || this.transform.position.y < 4.86)
        {
            transform.position = new Vector3(this.transform.position.x, -4.85f, 0f);
        }
    }

    public bool outOfBounds()
    {
        return false;
    }

    public void moveChar2(Vector2 offset)
    {
        offset.y *= 0;

        Quaternion q = new Quaternion(0,0,15,0);

        if (offset.x < -0.1) { beeSprite.transform.rotation = Quaternion.Euler(0, 0, 15); }
        else if (offset.x > 0.1) { beeSprite.transform.rotation = Quaternion.Euler(0, 0, -15); }
        else { beeSprite.transform.rotation = Quaternion.Euler(0, 0, 0); }

        playerObject.Translate(offset * speed * Time.deltaTime);
    }
}
