using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum CardColor
{
    Red,
    Black
};
public enum CardType
{
    Heart,
    Spade,
    Diamond,
    Club
};
[System.Serializable]
public class CardClass
{
    public CardColor card_color;
    public CardType card_type;
    public int number_on_card;
    public string card_name;
}
public class SolitaireGameController : MonoBehaviour
{
    public List<CardClass> all_cards_list;
    public Stack<CardClass> main_deck;
    public Stack<CardClass> open_deck;
    public Stack<CardClass> slot1;
    public Stack<CardClass> slot2;
    public Stack<CardClass> slot3;
    public Stack<CardClass> slot4;
    public Stack<CardClass> slot5;
    public Stack<CardClass> slot6;
    public Stack<CardClass> slot7;
    public GameObject slot1_gameObject;
    public GameObject slot2_gameObject;
    public GameObject slot3_gameObject;
    public GameObject slot4_gameObject;
    public GameObject slot5_gameObject;
    public GameObject slot6_gameObject;
    public GameObject slot7_gameObject;
    public GameObject card1, card2, card3;
    public Sprite common_sprite;
    #region Unity Methods
    private void Awake()
    {
        card1.GetComponent<Animator>().enabled = false;
        card2.GetComponent<Animator>().enabled = false;
        card3.GetComponent<Animator>().enabled = false;
        //Populate The Card List
        all_cards_list.Add(new CardClass {card_color=CardColor.Black,card_type=CardType.Club,number_on_card=1,card_name="1" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 2, card_name = "2" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card = 3, card_name = "3" });
        all_cards_list.Add(new CardClass { card_color = CardColor.Black, card_type = CardType.Club, number_on_card =4, card_name = "4" });
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
        //Initialize the main deck
        main_deck = new Stack<CardClass>();
        //Initialize the open deck
        open_deck = new Stack<CardClass>();
        //Fill in the main deck
        for(int i=0;i<all_cards_list.Count;i++)
        {
            main_deck.Push(all_cards_list[i]);
        }
        //Initialize All The Slots
        slot1 = new Stack<CardClass>();
        slot2 = new Stack<CardClass>();
        slot3 = new Stack<CardClass>();
        slot4 = new Stack<CardClass>();
        slot5 = new Stack<CardClass>();
        slot6 = new Stack<CardClass>();
        slot7 = new Stack<CardClass>();
        //Fill In All The Slots Initially
        for(int i=0;i<1;i++)
        {
            CardClass cc = main_deck.Peek();
            slot1.Push(cc);
            main_deck.Pop();
        }
        slot1_gameObject.transform.GetChild(slot1_gameObject.transform.childCount-1).GetComponent<Image>().sprite=Resources.Load<Sprite>("Cards/"+slot1.Peek().card_name);
        for (int i = 0; i < 2; i++)
        {
            CardClass cc = main_deck.Peek();
            slot2.Push(cc);
            main_deck.Pop();
        }
        slot2_gameObject.transform.GetChild(slot2_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot2.Peek().card_name);
        for (int i = 0; i < 3; i++)
        {
            CardClass cc = main_deck.Peek();
            slot3.Push(cc);
            main_deck.Pop();
        }
        slot3_gameObject.transform.GetChild(slot3_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot3.Peek().card_name);
        for (int i = 0; i < 4; i++)
        {
            CardClass cc = main_deck.Peek();
            slot4.Push(cc);
            main_deck.Pop();
        }
        slot4_gameObject.transform.GetChild(slot4_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot4.Peek().card_name);
        for (int i = 0; i < 5; i++)
        {
            CardClass cc = main_deck.Peek();
            slot5.Push(cc);
            main_deck.Pop();
        }
        slot5_gameObject.transform.GetChild(slot5_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot5.Peek().card_name);
        for (int i = 0; i < 6; i++)
        {
            CardClass cc = main_deck.Peek();
            slot6.Push(cc);
            main_deck.Pop();
        }
        slot6_gameObject.transform.GetChild(slot6_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot6.Peek().card_name);
        for (int i = 0; i < 7; i++)
        {
            CardClass cc = main_deck.Peek();
            slot7.Push(cc);
            main_deck.Pop();
        }
        slot7_gameObject.transform.GetChild(slot7_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + slot7.Peek().card_name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ExecuteAnimationOfCardFlipping());
        }
    }
    private IEnumerator ExecuteAnimationOfCardFlipping()
    {
        card3.GetComponent<Animator>().enabled = true;
        card3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + main_deck.Peek().card_name);
        //card3.transform.localScale = new Vector3(-1, 1, 1);
        open_deck.Push(main_deck.Peek());
        main_deck.Pop();
        yield return new WaitForSeconds(0.075f);
        
        card2.GetComponent<Animator>().enabled = true;
        card2.GetComponent<RectTransform>().anchoredPosition = new Vector3(card2.GetComponent<RectTransform>().anchoredPosition.x - 50, card2.GetComponent<RectTransform>().anchoredPosition.y, 0);
        card2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + main_deck.Peek().card_name);
        //card2.transform.localScale = new Vector3(-1, 1, 1);
        open_deck.Push(main_deck.Peek());
        main_deck.Pop();
        yield return new WaitForSeconds(0.075f);
     
        card1.GetComponent<Animator>().enabled = true;
        card1.GetComponent<RectTransform>().anchoredPosition = new Vector3(card3.GetComponent<RectTransform>().anchoredPosition.x - 100, card3.GetComponent<RectTransform>().anchoredPosition.y, 0);
        card1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + main_deck.Peek().card_name);
        //card1.transform.localScale = new Vector3(-1, 1, 1);
        open_deck.Push(main_deck.Peek());
        main_deck.Pop();
    }
    #endregion
    #region Private Methods
    private void UpdateTheUI()
    {

    }
    #endregion
}
