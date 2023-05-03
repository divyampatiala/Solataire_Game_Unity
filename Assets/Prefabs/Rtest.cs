using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rtest : MonoBehaviour
{
    public GameObject go_prefab;
    public GameObject prefab_holder;
    public int initial_card;
    public List<CardClass> all_cards_list;
    public Stack<CardClass> all_cards;
    public Stack<CardClass> slot1;
    public Stack<CardClass> slot2;
    public Stack<CardClass> slot3;
    public Stack<CardClass> slot4;
    public Stack<CardClass> slot5;
    public Stack<CardClass> slot6;
    public Stack<CardClass> slot7;
    public Vector3[] to_positions_array;
    public Texture back_card;
    public CardClass this_card;
    public CardClass collided_card;
    public GameObject all_slots_holder;
    public GameObject top_4_slots_holder;
    public Texture glow_sprite_texture;
    float base_z_height = 0;
    public int render_position_flip;
    private void Awake()
    {
        render_position_flip = 0;
        for(int i=0;i<top_4_slots_holder.transform.childCount;i++)
        {
            top_4_slots_holder.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetTexture("_MainTex", glow_sprite_texture);
        }
        to_positions_array = new Vector3[] { new Vector3(-2.766f, 2.25f, 0f), new Vector3(-1.856f, 2.25f, 0f), new Vector3(-0.961f, 2.25f, 0f), new Vector3(-0.05f, 2.25f, 0f), new Vector3(0.86f, 2.25f, 0f), new Vector3(1.79f, 2.25f, 0f), new Vector3(2.71f, 2.25f, 0f) };
        //Fix The Slots
        for(int i=0;i<all_slots_holder.transform.childCount;i++)
        {
            all_slots_holder.transform.GetChild(i).transform.position = to_positions_array[i];
        }
        //Initialize the list
        all_cards_list = new List<CardClass>();
        //Fill In The List with all the cards
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 1, card_name = "1" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 2, card_name = "2" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 3, card_name = "3" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 4, card_name = "4" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 5, card_name = "5" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 6, card_name = "6" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 7, card_name = "7" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 8, card_name = "8" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 9, card_name = "9" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 10, card_name = "10" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 11, card_name = "11" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 12, card_name = "12" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 13, card_name = "13" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 1, card_name = "14" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 2, card_name = "15" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 3, card_name = "16" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 4, card_name = "17" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 5, card_name = "18" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 6, card_name = "19" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 7, card_name = "20" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 8, card_name = "21" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 9, card_name = "22" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 10, card_name = "23" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 11, card_name = "24" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 12, card_name = "25" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Spade, number_on_card = 13, card_name = "26" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 1, card_name = "27" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 2, card_name = "28" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 3, card_name = "29" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 4, card_name = "30" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 5, card_name = "31" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 6, card_name = "32" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 7, card_name = "33" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 8, card_name = "34" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 9, card_name = "35" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 10, card_name = "36" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 11, card_name = "37" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 12, card_name = "38" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Diamond, number_on_card = 13, card_name = "39" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 1, card_name = "40" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 2, card_name = "41" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 3, card_name = "42" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 4, card_name = "43" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 5, card_name = "44" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 6, card_name = "45" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 7, card_name = "46" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 8, card_name = "47" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 9, card_name = "48" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 10, card_name = "49" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 11, card_name = "50" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 12, card_name = "51" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Red, card_type = CardType.Heart, number_on_card = 13, card_name = "52" });
        //Shuffle The Cards
        Utils.Shuffle(all_cards_list);
        //Initialize all the stacks
        all_cards = new Stack<CardClass>();
        for (int i = 0; i < all_cards_list.Count; i++)
        {
            all_cards.Push(all_cards_list[i]);
        }
        slot1 = new Stack<CardClass>();
        slot2 = new Stack<CardClass>();
        slot3 = new Stack<CardClass>();
        slot4 = new Stack<CardClass>();
        slot5 = new Stack<CardClass>();
        slot6 = new Stack<CardClass>();
        slot7 = new Stack<CardClass>();
    }
    private void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            GameObject go = Instantiate(go_prefab);
            go.transform.SetParent(prefab_holder.transform);
            go.transform.position = new Vector3(2.55f, 4.25f, -3);
            go_prefab.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
            go.name = "CardParent";
            go.transform.GetChild(0).transform.localPosition = new Vector3(0.5f, 0, 0);
            go.GetComponent<CardMoventSide>().card_allow_dragging = false;
            go.GetComponent<CardMoventSide>().card_name = all_cards.Peek().card_name;
            all_cards.Pop();
            //go.transform.GetChild(0).transform.Find("CardPlanePrefabFront").GetComponent<MeshRenderer>().material.SetTexture("_MainTex",Resources.Load<Texture>("Cards/3"));
        }
        for (int i = 0; i < 28; i++)
        {
            GameObject go = Instantiate(go_prefab);
            go.transform.SetParent(prefab_holder.transform);
            go.transform.position = new Vector3(2.55f, 4.25f, -3);
            go_prefab.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
            go.name = "CardParent";
            go.transform.GetChild(0).transform.localPosition = new Vector3(0.5f, 0, 0);
            go.GetComponent<CardMoventSide>().GetComponent<PressableButton>().enabled = false;
            go.GetComponent<CardMoventSide>().card_name = all_cards.Peek().card_name;
            all_cards.Pop();
        }
        initial_card = 23;
        StartCoroutine(DistributeCards());
    }
    private IEnumerator DistributeCards()
    {
        int position = 0;
        int ap = 0;
        bool show_face = true;
        for(int i=51;i>=24;i--)
        {
            if(position<7)
            {
               
                GameObject go = prefab_holder.transform.GetChild(i).gameObject;
                go.transform.SetParent(all_slots_holder.transform.GetChild(position).gameObject.transform);
                go.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0f);
                go.GetComponent<BoxCollider>().enabled = show_face;
                go.GetComponent<CardMoventSide>().allow_forward_movement = true;
                go.GetComponent<CardMoventSide>().allow_sliding = false;
                go.GetComponent<CardMoventSide>().allow_sliding_reverse = false;
                go.GetComponent<CardMoventSide>().StartAnimation();
                go.transform.GetChild(0).transform.Find("CardPlanePrefabFront").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", show_face == true ? Resources.Load<Texture>("Cards/" + go.GetComponent<CardMoventSide>().card_name) : back_card);
                go.transform.GetChild(0).transform.Find("CardPlanePrefabBack").GetComponent<MeshRenderer>().material.SetTexture("_MainTex",back_card );
                go.GetComponent<CardMoventSide>().designated_position = new Vector3(0,0,0);
                //prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().designated_position = new Vector3(0,0-(0.05f*ap),0);
                go.GetComponent<CardMoventSide>().revert_to_position = new Vector3(0, 0 - (0.05f * position),0 - (0.025f * position));
                go.GetComponent<CardMoventSide>().move_speed = 5f;
                go.GetComponent<CardMoventSide>().position = ap;
                go.GetComponent<CardMoventSide>().pos = position;
          
                go.transform.Rotate(Vector3.right);
            
                
                //go.GetComponent<CardMoventSide>().card_name = all_cards.Peek().card_name;
                go.GetComponent<CardMoventSide>().card_allow_dragging = show_face;
                //all_cards.Pop();

                position++;
                show_face = false;
                if (position == 7)
                {
                    ap++;
                    position = ap;
                    show_face = true;
                    //  dp = ap; 
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
        //for (int i = prefab_holder.transform.childCount - 1; i >= prefab_holder.transform.childCount  - 27; i--)
        //{
        //    if (position < 7)
        //    {
        //        //Debug.Log("Value:" + i + " " + "Position:" + position);
                
        //        prefab_holder.transform.GetChild(i).transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().designated_position = to_positions_array[position];
        //        //prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().designated_position = new Vector3(0,0-(0.05f*ap),0);
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().revert_to_position = new Vector3(to_positions_array[position].x, to_positions_array[position].y - (0.05f * position), to_positions_array[position].z - (0.025f * position));
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().move_speed = 5f;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().position = ap;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().pos = position;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_forward_movement = true;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding = false;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().allow_sliding_reverse = false;
        //        prefab_holder.transform.GetChild(i).transform.Rotate(Vector3.right);
        //        prefab_holder.transform.GetChild(i).transform.GetChild(0).transform.Find("CardPlanePrefabFront").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", back_card);
        //        prefab_holder.transform.GetChild(i).transform.GetChild(0).transform.Find("CardPlanePrefabBack").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", show_face == true ? Resources.Load<Texture>("Cards/" + all_cards.Peek().card_name) : back_card);
        //        prefab_holder.transform.GetChild(i).GetComponent<BoxCollider>().enabled = show_face;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().card_name = all_cards.Peek().card_name;
        //        prefab_holder.transform.GetChild(i).GetComponent<CardMoventSide>().card_allow_dragging = show_face;
        //        all_cards.Pop();

        //        position++;
        //        show_face = false;
        //        if (position == 7)
        //        {
        //            ap++;
        //            position = ap;
        //            show_face = true;
        //            //  dp = ap; 
        //        }
        //    }
        //    yield return new WaitForSeconds(0.25f);
        //}
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenTheCards());
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("CardsTD");
        }
    }
    public void CallOpenCards()
    {
        StartCoroutine(OpenTheCards());
    }
    private IEnumerator OpenTheCards()
    {
        if (initial_card > -1)
        {
            int item = 2;

            for (int i = initial_card; i > (initial_card - 3); i--)
            {
                GameObject go = prefab_holder.transform.GetChild(i).gameObject;

                go.transform.position += Vector3.forward*0.06f*(i%3);
                go.GetComponent<PressableButton>().allowPressing = false;
                Transform t = go.transform;
                
                if (item == 2)
                {
                    base_z_height = 0;
                    go.GetComponent<CardMoventSide>().target_pos = new Vector3(0.75f,4,base_z_height);
                }
                else if(item==1)
                {
                    base_z_height += 0.05f;
                    go.GetComponent<CardMoventSide>().target_pos = new Vector3(0.5f, 4,base_z_height);
                }
                else if(item==0)
                {
                    base_z_height += 0.05f;
                    go.GetComponent<CardMoventSide>().target_pos = new Vector3(0.25f,4, base_z_height);
                }
                //go.GetComponent<CardMoventSide>().diff_by =item*((i%3)*0.05f)+0.2f;
                go.GetComponent<CardMoventSide>().move_speed = 0.625f;
                go.GetComponent<CardMoventSide>().allow_sliding = true;
                go.GetComponent<CardMoventSide>().allow_sliding_reverse = false;
                go.GetComponent<CardMoventSide>().allow_forward_movement = false;
                go.GetComponent<CardMoventSide>().card_allow_dragging = true;
                go.transform.GetChild(0).transform.Find("CardPlanePrefabFront").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>("Cards/"+go.GetComponent<CardMoventSide>().card_name));

                go.transform.Find("Card").transform.Find("CardPlanePrefabFront").GetComponent<ApplyCardMat>().front_card_material.renderQueue = (3000+render_position_flip);
                render_position_flip++;
                yield return new WaitForSeconds(0.25f);
                item--;
                if(item<0)
                {
                    item=2;
                }
            }
            initial_card -= 3;
        }
         else if (initial_card == -1)
        {
            for (int i = 0; i <= 23; i++)
            {
                GameObject go = prefab_holder.transform.GetChild(i).gameObject;
                go.GetComponent<PressableButton>().allowPressing = true;
                go.transform.GetChild(0).transform.localPosition = new Vector3(0.5f, 0, 0);
                go.GetComponent<CardMoventSide>().move_speed = 2f;
                go.GetComponent<CardMoventSide>().allow_sliding = false;
                go.GetComponent<CardMoventSide>().allow_sliding_reverse = true;
                go.GetComponent<CardMoventSide>().allow_forward_movement = false;
                go.GetComponent<CardMoventSide>().card_allow_dragging = false;
                yield return new WaitForSeconds(0.05f);
            }
            initial_card = 23;
        }
    }

}
