using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public Transform designated_position;
    public bool start_moving;
    public float move_speed;
    public float position;
    public int num;
    public int layer_number;
    public bool apply_scale_change;
    public bool allow_horiontal_animation;
    public float rotation_speed;
    private void Start()
    {
        designated_position = null;
        apply_scale_change = false;
        start_moving = false;
        num = Random.Range(1, 53);
        allow_horiontal_animation = false;
    }
    private void Update()
    {
        if(start_moving==true)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = layer_number;

            if (this.transform.position == designated_position.position)
            {
                move_speed = 0;
              
                //this.transform.position = new Vector2(designated_position.position.x, (designated_position.position.y - position * 0.25f));
                //if (apply_scale_change == true)
                //{
                //    this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + num);
                //    this.transform.localScale = new Vector3(0.6f, -0.6f, 0.6f);
                //}
                //  this.GetComponent<SpriteRenderer>().sortingOrder = layer_number;
                //this.transform.SetParent(null);
                start_moving = false;
    
            }
            
            else
            {
                if (designated_position != null)
                {
                    this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(designated_position.position.x, (designated_position.position.y - position * 0.25f)), move_speed * Time.deltaTime);
                   StartCoroutine(ChangeOnSprite());
                   
                } 
            }
        }
    }
    private IEnumerator ChangeOnSprite()
    {
        yield return new WaitForSeconds(0.0f);
        if (apply_scale_change == true)
        {
            this.GetComponent<Animator>().SetBool("rotate_forward", true);
            yield return new WaitForSeconds(0.2f);
            this.transform.localScale = new Vector3(0.6f, -0.6f, 0.6f);
           this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + 1);
            apply_scale_change = false;
        }
    }
}
