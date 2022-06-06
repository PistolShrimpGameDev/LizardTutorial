using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    public Animator lizardAnimator;
    public GameObject target;
    public float speed = 0.5f;
    public SpriteRenderer lizardSprite;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player") as GameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < 10.0f
            && Vector3.Distance(target.transform.position, this.transform.position) > 0.5f)
        {
            StartMoving();
        } else {
            StopMoving();
        }
    }

    public void StartMoving()
    {
        lizardAnimator.SetBool("Walking", true);
        if (target.transform.position.x > this.transform.position.x)
        {
            //lizard is to the left of the target, we want to move to the right.
            lizardSprite.flipX = true;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (target.transform.position.x < this.transform.position.x)
        {
            //lizard is to the right of the target, we want to move to the left.
            lizardSprite.flipX = false;
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
    }

    public void StopMoving()
    {
        lizardAnimator.SetBool("Walking", false);
    }
}
