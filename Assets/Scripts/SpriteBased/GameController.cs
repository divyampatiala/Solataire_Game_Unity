using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject cards_holder;
    public int cards_left;
    public int initial_card;
    public Sprite card_back,card_back_side_pivot;
    public Vector2 initial_position;
    public float move_speed;
    public int slot1_count, slot2_count, slot3_count, slot4_count, slot5_count, slot6_count, slot7_count;
    public Transform[] designated_position;
    public GameObject card_prefab;
    public GameObject card_prefab_side_holder;
    public GameObject card_prefab_holder;
    public int iteration;
    public int sorting_order = 1;
    private void Start()
    {
        iteration = 1;
        slot1_count=0;
        slot2_count = 0;
        slot3_count = 0;
        slot4_count = 0;
        slot5_count = 0;
        slot6_count = 0;
        slot7_count = 0;
        initial_card =23;
        for (int i = 0; i < 24; i++)
        {
            GameObject go = Instantiate(card_prefab_side_holder);
            go.transform.SetParent(cards_holder.transform);
            go.transform.localPosition = new Vector3(-1.26f,0f,0f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        for (int i=0;i<1;i++)
        {
            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f,4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 7;
            go.GetComponent<CardMovement>().move_speed = 6;
            go.GetComponent<CardMovement>().position = 1.5f;
            go.name = "CardBack";
        }
        for (int i = 1; i < 3; i++)
        {
            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 6;
            go.GetComponent<CardMovement>().move_speed =6;
            go.GetComponent<CardMovement>().position = 1.25f;
            go.name = "CardBack";
        }
        for (int i = 3; i <6; i++)
        {
            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 5;
            go.GetComponent<CardMovement>().move_speed = 6;
            go.GetComponent<CardMovement>().position = 1f;
            go.name = "CardBack";
        }
        for (int i = 6; i < 10; i++)
        {
            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 4;
            go.GetComponent<CardMovement>().move_speed = 6;
            go.GetComponent<CardMovement>().position = 0.75f;
            go.name = "CardBack";
        }
        for (int i = 10; i <15; i++)
        {
            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 3;
            go.GetComponent<CardMovement>().move_speed = 6;
            go.GetComponent<CardMovement>().position = 0.5f;
            go.name = "CardBack";
        }
        for (int i = 15; i < 21; i++)
        {

            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 2;
            go.GetComponent<CardMovement>().move_speed = 6;
            go.GetComponent<CardMovement>().position = 0.25f;
            go.name = "CardBack";
        }
        for (int i = 21; i < 28; i++)
        {

            GameObject go = Instantiate(card_prefab);
            go.transform.SetParent(cards_holder.transform);
            go.transform.position = new Vector2(2.75f, 4.25f);
            go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            go.GetComponent<CardMovement>().layer_number = 1;
            go.GetComponent<CardMovement>().move_speed =6;
            go.GetComponent<CardMovement>().position = 0f;
            go.name = "CardBack";
        }
        cards_left = 23;
        initial_position = cards_holder.transform.GetChild(0).transform.position;
    }
    private void Update()
    {
        StartCoroutine(MoveToDesignatedPosition());
    }
    public void CallOpenCards()
    {
        StartCoroutine(OpenCards());
    }
    private IEnumerator MoveToDesignatedPosition()
    {
        int dp = 0;
        bool allow_animation = true;
        int position =0;
        int sorting_order=1;
        int num;
        for (int i =cards_holder.transform.childCount-1; i> cards_holder.transform.childCount - 29; i--)
        {
            
            cards_holder.transform.GetChild(i).GetComponent<CardMovement>().layer_number = sorting_order;
            if (allow_animation == true)
            {
                //cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("rotate_forward", true);
          
                cards_holder.transform.GetChild(i).GetComponent<CardMovement>().apply_scale_change = true;

               // cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("rotate_forward", true);
              // cards_holder.transform.GetChild(i).transform.rotation=Vector3.RotateTowards()
                yield return new WaitForSeconds(0.1f);
                
                cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + 1);
                //yield return new WaitForSeconds(0.1f);
                cards_holder.transform.GetChild(i).transform.localScale = new Vector3(0.6f, -0.6f, 0.6f);
                allow_animation = false;
                
              

            }
            
            cards_holder.transform.GetChild(i).gameObject.GetComponent<CardMovement>().designated_position = designated_position[dp];
            cards_holder.transform.GetChild(i).gameObject.GetComponent<CardMovement>().start_moving = true;
            

            yield return new WaitForSeconds(0.2f);


            dp++;
            if (dp == 7)
            {
                allow_animation = true;
                position += 1;
                sorting_order += 1;
                dp = position;
                yield return new WaitForSeconds(0.01f);

            }
        }
    }

    private IEnumerator OpenCards()
    {
        if (initial_card>0)
        {
            int item = 2;


            for (int i = initial_card; i > (initial_card - 3); i--)
            {
                //cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("allow_flip", true);
                //cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().diff_by = (0.25f * item);
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().move_speed=0.625f;
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding = true;
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding_reverse = false;
                yield return new WaitForSeconds(0.25f);
                //cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_slide = true;
                //cards_holder.transform.GetChild(i).transform.localPosition= new Vector3(cards_holder.transform.GetChild(i).transform.localPosition.x- 0.25f * item, cards_holder.transform.GetChild(i).transform.localPosition.y, cards_holder.transform.GetChild(i).transform.localPosition.z);
                cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = sorting_order;
                //cards_holder.transform.GetChild(i).transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
                yield return new WaitForSeconds(0.2f);
                cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CardsPivot/"+1);
                //yield return new WaitForSeconds(0.1f);
                //yield return new WaitForSeconds(0.25f);

                item--;
                sorting_order++;
               
            }
            initial_card -= 3;
            
        }
        else if (initial_card ==-1)
        {
           
            for (int i = 0 ; i<=23; i++)
            {
                //cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("allow_flip", false);

                //cards_holder.transform.GetChild(i).transform.localPosition = new Vector3(-1.26f,0,0);
                //  yield return new WaitForSeconds(0.005f);
                            //cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().diff_by = (0.25f * item);
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().move_speed = 3f;
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().sprite_order = (i + 1);
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding = false;
                cards_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding_reverse = true;

                yield return new WaitForSeconds(0.015f);
                //cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (i + 1);

            }


            cards_holder.transform.GetChild(23).GetComponent<SpriteRenderer>().sprite = card_back_side_pivot;
            initial_card = 0;
        }
    }
    public void OnReplayPressed()
    {
        SceneManager.LoadScene("SpriteModeScene");
    }
   
}
