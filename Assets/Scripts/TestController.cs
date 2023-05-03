using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public GameObject cards_holder;
    public Sprite back_card_sprite;
    private void Start()
    {
        StartCoroutine(OpenCards());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenCards());
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(PlayReverseCard());
        }
    }
    private IEnumerator OpenCards()
    {
        int pivot = 3;
        for(int i=0;i<3;i++)
        {
            cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("allow_flip", true);
            
            
             yield return new WaitForSeconds(0.2f);
            cards_holder.transform.GetChild(i).transform.position = new Vector3(cards_holder.transform.GetChild(i).transform.position.x-(0.25f*pivot), cards_holder.transform.GetChild(i).transform.position.y, cards_holder.transform.GetChild(i).transform.position.z);
            cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (i + 1);
            pivot--;
            yield return new WaitForSeconds(0.075f);
            cards_holder.transform.GetChild(i).transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CardsPivot/" + Random.Range(1, 27));

            //}
            //for (int i = 0; i < 3; i++)
            //{

        }
    }
    private IEnumerator PlayReverseCard()
    {
        int pivot = 3;
        for (int i = 2; i >= 0; i--)
        {
            cards_holder.transform.GetChild(i).GetComponent<Animator>().SetBool("allow_flip", false);
            yield return new WaitForSeconds(0.15f);
            cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = pivot;
            yield return new WaitForSeconds(0.15f);
            cards_holder.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = back_card_sprite;
            cards_holder.transform.GetChild(i).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cards_holder.transform.GetChild(i).transform.position = Vector3.zero;
            pivot--;
        }

    }
}
