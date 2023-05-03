using System.Collections;
using UnityEngine;

public class CardMoventSide : MonoBehaviour
{
    public bool allow_sliding;
    public bool allow_sliding_reverse;
    public bool allow_forward_movement;
    public Vector3 designated_position;
    public float move_speed;
    public Vector3 target_pos;
    public int sprite_order;
    public int position;
    public int pos;
    public string card_name;
    public bool card_allow_dragging;
    public bool card_held;
    public float mouse_move_speed;
    public Vector3 mousePosition;
    public Vector3 revert_to_position;
    public GameObject card_game_controller;
    

    private void Start()
    {
        allow_sliding = false;
        card_allow_dragging = false;
        card_held = false;
        card_game_controller = GameObject.FindGameObjectWithTag("CardGameController");
    }
    private void Update()
    {
        if (allow_sliding == false && allow_sliding_reverse == false && allow_forward_movement == true)
        {
            if (this.GetComponent<BoxCollider>().enabled == true)
            {
                if (this.transform.eulerAngles.x<=180)
                {

                    this.transform.Rotate(Vector3.right);
                this.transform.localScale = new Vector3(-0.55f, -0.55f,0.55f); 
                }
                else
                {
                    this.transform.rotation = Quaternion.Euler(new Vector3(-180, 0, 0));
                }
            }
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(designated_position.x, designated_position.y - (position * 0.05f), designated_position.z - (position * 0.025f)), move_speed * Time.deltaTime);
            //this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(designated_position.x, designated_position.y - (position * 0.05f), designated_position.z - 1), move_speed * Time.deltaTime);
            //}
            StartCoroutine(StopForwardMovement());
        }
        if (allow_sliding == true && allow_sliding_reverse == false && allow_forward_movement == false)
        {
            if (this.transform.eulerAngles != new Vector3(0f, 180f, 0))
            {

                this.transform.Rotate(Vector3.up);
                //this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,new Vector3( target_pos.x,this.transform.position.y,target_pos.z), move_speed * Time.deltaTime);
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x -target_pos.x , 4.25f,-3), move_speed * Time.deltaTime);
            }
        }
        if (allow_sliding == false && allow_sliding_reverse == true && allow_forward_movement == false)
        {
            //if (this.transform.eulerAngles != new Vector3(0, 0, 0))
            if (this.transform.eulerAngles != new Vector3(0, 0, 0))
            {

                this.transform.Rotate(-Vector3.up);
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(2.55f, this.transform.localPosition.y, this.transform.localPosition.z), 3 * Time.deltaTime);
                //  this.GetComponent<SpriteRenderer>().sortingOrder = sprite_order;
            }
        }

        //  card.transform.SetPositionAndRotation(new Vector3(-0.75f, card.transform.position.y, card.transform.position.z), Quaternion.Euler(0, 180, 0));
    }
    public void StartAnimation()
    {
        if (allow_sliding == false && allow_sliding_reverse == false && allow_forward_movement == true)
        {
            if (this.GetComponent<BoxCollider>().enabled == true)
            {
                Debug.Log(Time.time);
            }
        }
    }
    public Vector3 GetMousePosition()
    {
        if (card_allow_dragging == true)
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }
        else
        {
            return Vector3.zero;
        }
    }
    private void OnMouseDown()
    {
        if (card_allow_dragging == true)
        {
            mousePosition = Input.mousePosition - GetMousePosition();
        }
    }
    private void OnMouseDrag()
    {
        if (card_allow_dragging == true)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            //if(Input.GetMouseButtonDown(0))
            //{
            //    card_held = true;
            //}
            //if(card_held==true)
            //{
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            //}
        }
    }
    private void OnMouseUp()
    {
        if (card_allow_dragging == true)
        {
            card_held = false;
            this.transform.localPosition = revert_to_position;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private IEnumerator StopForwardMovement()
    {
        yield return new WaitForSeconds(5.0f);
        allow_forward_movement = false;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            //Debug.Log(collision.gameObject.GetComponent<CardMoventSide>().card_name);
            string c_n = collision.gameObject.GetComponent<CardMoventSide>().card_name;
            GameObject go = collision.gameObject;
           
            card_game_controller.GetComponent<Rtest>().this_card = card_game_controller.GetComponent<Rtest>().all_cards_list.Find(e => e.card_name == this.card_name);
            card_game_controller.GetComponent<Rtest>().collided_card = card_game_controller.GetComponent<Rtest>().all_cards_list.Find(e => e.card_name == c_n);
            if (!string.Equals(card_game_controller.GetComponent<Rtest>().this_card.card_color, card_game_controller.GetComponent<Rtest>().collided_card.card_color))
            {
                if (card_game_controller.GetComponent<Rtest>().collided_card.number_on_card - card_game_controller.GetComponent<Rtest>().this_card.number_on_card == 1)
                {
                    Debug.Log("Allowed");
                    GameObject parent_go = this.transform.parent.gameObject;
                    this.transform.SetParent(go.transform);
                    //revert_to_position = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y - 0.25f, go.transform.localPosition.z - 0.05f);
                    //this.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y - 0.25f, go.transform.localPosition.z - 0.05f);
                    revert_to_position = new Vector3(0,-0.75f,-0.05f);
                    parent_go.transform.GetChild(parent_go.transform.childCount-1).transform.GetChild(0).transform.Find("CardPlanePrefabBack").GetComponent<MeshRenderer>().material.SetTexture("_MainTex",Resources.Load<Texture>("Cards/"+ parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<CardMoventSide>().card_name));
                    parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<BoxCollider>().enabled = true;
                    parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<CardMoventSide>().card_allow_dragging = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="FinalCard")
        {

            GameObject parent_go = this.transform.parent.gameObject;
            GameObject go = collider.gameObject;
            Debug.Log("Fisrt Card");
            Debug.Log(go.transform.childCount);
            if (go.transform.childCount == 0)
            {
                if (this.GetComponent<CardMoventSide>().card_name == "1" || this.GetComponent<CardMoventSide>().card_name == "14" || this.GetComponent<CardMoventSide>().card_name =="27" || this.GetComponent<CardMoventSide>().card_name == "52")
                {
                    this.transform.SetParent(go.transform);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localScale = go.transform.localScale;
                    switch(card_game_controller.GetComponent<Rtest>().all_cards_list.Find(e => e.card_name == this.GetComponent<CardMoventSide>().card_name).card_type)
                    {
                        case CardType.Club:
                            go.name = "Club";
                            break;
                        case CardType.Spade:
                            go.name = "Spade";
                            break;
                        case CardType.Heart:
                            go.name = "Heart";
                            break;
                        case CardType.Diamond:
                            go.name = "Diamond";
                            break;
                    }
                }
            }
            parent_go.transform.GetChild(parent_go.transform.childCount - 1).transform.GetChild(0).transform.Find("CardPlanePrefabBack").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>("Cards/" + parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<CardMoventSide>().card_name));
            parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<BoxCollider>().enabled = true;
            parent_go.transform.GetChild(parent_go.transform.childCount - 1).GetComponent<CardMoventSide>().card_allow_dragging = true;
        }
    }
}
