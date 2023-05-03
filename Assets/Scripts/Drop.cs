using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drop : MonoBehaviour, IDropHandler
{
    public string input;
    public string currentGameCategory;
    public bool dropped;
    public bool is_correct;
    public GameObject solataire_game_controller;
    public GameObject questions_holder;
    public string[] congrats_audio_strings = { "Congratulations", "GreatJob", "WellDone" };
    private void Awake()
    {
        is_correct = false;
        dropped = false;
        solataire_game_controller = GameObject.FindGameObjectWithTag("SolataireGameController");
    }
    public void OnDrop(PointerEventData ped)
    {
        List<CardClass> acl = solataire_game_controller.GetComponent<SolitaireGameController>().all_cards_list;
        input = ped.pointerDrag.GetComponent<Image>().sprite.name;
        CardClass dragged_card = acl.Find(e => e.card_name == input);
        CardClass dropped_card = acl.Find(e => e.card_name == this.GetComponent<Image>().sprite.name);

        if(dropped_card.card_color!=dragged_card.card_color)
        {
            if (dropped_card.number_on_card-dragged_card.number_on_card==1)
            {
                GameObject parent_go = ped.pointerDrag.gameObject.transform.parent.gameObject;
                ped.pointerDrag.gameObject.transform.SetParent(this.transform.parent.transform);
                ped.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, this.transform.parent.transform.GetChild(this.transform.parent.transform.childCount-1).GetComponent<RectTransform>().anchoredPosition.y-50, 0);
                PushingPoppingSlots(parent_go.name, this.transform.parent.gameObject.name,dragged_card);

            }
        }
        else
        {

        }
      
    }
    private void PushingPoppingSlots(string dragged_slot_name,string dropped_slot_name,CardClass _card_to_push)
    {
        //Popping
        switch(dragged_slot_name)
        {
            case "Slot1":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot1.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot1_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot1_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot1_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot1.Peek().card_name);
                }
                break;
            case "Slot2":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot2.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot2_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot2_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot2_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot2.Peek().card_name);
                }
                break;
            case "Slot3":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot3.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot3_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot3_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot3_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot3.Peek().card_name);
                }
                break;
            case "Slot4":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot4.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot4_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot4_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot4_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot4.Peek().card_name);
                }
                break;
            case "Slot5":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot5.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot5_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot5_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot5_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot5.Peek().card_name);
                }
                break;
            case "Slot6":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot6.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot6_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot6_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot6_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot6.Peek().card_name);
                }
                break;
            case "Slot7":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot7.Pop();
                if (solataire_game_controller.GetComponent<SolitaireGameController>().slot7_gameObject.transform.childCount > 0)
                {
                    solataire_game_controller.GetComponent<SolitaireGameController>().slot7_gameObject.transform.GetChild(solataire_game_controller.GetComponent<SolitaireGameController>().slot7_gameObject.transform.childCount - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/" + solataire_game_controller.GetComponent<SolitaireGameController>().slot7.Peek().card_name);
                }
                break;
        }
        //Pushing
        switch(dropped_slot_name)
        {
            case "Slot1":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot1.Push(_card_to_push);
                break;
            case "Slot2":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot2.Push(_card_to_push);
                break;
            case "Slot3":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot3.Push(_card_to_push);
                break;
            case "Slot4":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot4.Push(_card_to_push);
                break;
            case "Slot5":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot5.Push(_card_to_push);
                break;
            case "Slot6":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot6.Push(_card_to_push);
                break;
            case "Slot7":
                solataire_game_controller.GetComponent<SolitaireGameController>().slot7.Push(_card_to_push);
                break;
        }
    }
    private void CheckFromToDestination()
    {

    }
    private IEnumerator CheckForSlotAvaialbility()
    {
        yield return new WaitForSeconds(2.0f);
        int active_count = 0;
        for(int i=0;i<questions_holder.transform.childCount;i++)
        {
            if(questions_holder.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                active_count++;
            }
        }
        //if(active_count==0)
        //{
        //    if (alpha_match_game_controller != null)
        //    {
        //        if (alpha_match_game_controller.GetComponent<AlphaMatchController>().current_index < alpha_match_game_controller.GetComponent<AlphaMatchController>().words_list.Count - 1)
        //        {
        //            alpha_match_game_controller.GetComponent<AlphaMatchController>().ShowQuestion();
        //        }
        //        else
        //        {
        //            alpha_match_game_controller.GetComponent<AlphaMatchController>().game_over_panel.SetActive(true);
        //        }
        //    }
        //    if(sorting_controller!=null)
        //    {
        //        sorting_controller.GetComponent<SortingController>().ShowQuestion();
        //    }
        //}
    }
    //private IEnumerator PutSomeDelayForNextSortingQuestion()
    //{
    //    yield return new WaitForSeconds(4.0f);
    //    if (sortingManager.GetComponent<SortingManager>().currentIndex < sortingManager.GetComponent<SortingManager>().sortingClassList.Count - 1)
    //    {
    //        sortingManager.GetComponent<SortingManager>().currentIndex++;
    //        sortingManager.GetComponent<SortingManager>().ClearAll();
    //        sortingManager.GetComponent<SortingManager>().LoadTheSlot();
    //    }
    //    else
    //    {
    //        sortingManager.GetComponent<SortingManager>().gameOverPanel.SetActive(true);
    //        ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //    }
    //}
    //private IEnumerator BlockAllRaycastsAgain()
    //{
    //    if(is_correct==true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if(is_correct==false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    for (int i = 0; i < sortingManager.GetComponent<SortingManager>().allQuestionsHolder.transform.childCount; i++)
    //    {
    //        sortingManager.GetComponent<SortingManager>().allQuestionsHolder.transform.transform.GetChild(i).GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
    //    }
    //}
    //private IEnumerator BlockAllRaycastsAgainShadowMatch()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    for (int i = 0; i < shadowMatchManager.GetComponent<ShadowMatchManager>().originalImageArray.Length; i++)
    //    {
    //        shadowMatchManager.GetComponent<ShadowMatchManager>().originalImageArray[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
    //    }
    //}
    //public void ManageSound(string name)
    //{
    //    if (PlayerPrefs.GetInt("Sound") == 1)
    //    {
    //        AudioManager.audioManagerInstance.RaiseVolume(name);
    //        AudioManager.audioManagerInstance.Play(name);
    //    }
    //    else if (PlayerPrefs.GetInt("Sound") == 0)
    //    {
    //        AudioManager.audioManagerInstance.ReduceVolume(name);
    //    }
    //}
    //private IEnumerator ChangeTheSlot()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if(is_correct==false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (oddOneOutManager.GetComponent<OddOneOutManager>().currentQuestionIndex < oddOneOutManager.GetComponent<OddOneOutManager>().oddOneOutClassList.Count-1)
    //    {
    //        oddOneOutManager.GetComponent<OddOneOutManager>().currentQuestionIndex++;
    //        oddOneOutManager.GetComponent<OddOneOutManager>().ClearAll();
    //        oddOneOutManager.GetComponent<OddOneOutManager>().LoadTheSlot();
    //    }
    //    else
    //    {
    //        if (oddOneOutManager.GetComponent<OddOneOutManager>().scores >= 7)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        oddOneOutManager.GetComponent<OddOneOutManager>().gameOverPanel.SetActive(true);
    //    }
    //}
    //private IEnumerator ChangeTheSlotForMissingPictures()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (missingPicturesManager.GetComponent<MissingPicturesManager>().currentIndex < missingPicturesManager.GetComponent<MissingPicturesManager>().questionArray.Length - 1)
    //    {
    //        missingPicturesManager.GetComponent<MissingPicturesManager>().currentIndex++;
    //        missingPicturesManager.GetComponent<MissingPicturesManager>().ClearAll();
    //        missingPicturesManager.GetComponent<MissingPicturesManager>().LoadTheSlot();
            
    //    }
    //    else
    //    {
    //        if (missingPicturesManager.GetComponent<MissingPicturesManager>().currentScores >= 7)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        missingPicturesManager.GetComponent<MissingPicturesManager>().gameOverPanel.SetActive(true);
    //    }
    //}
    //private IEnumerator ChangeTheSlotForPicturePuzzle()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (picturePuzzleManager.GetComponent<PicturePuzzleManager>().currentIndex < picturePuzzleManager.GetComponent<PicturePuzzleManager>().picturePuzzleClassList.Count-1)
    //    {
    //        picturePuzzleManager.GetComponent<PicturePuzzleManager>().currentIndex++;
    //        picturePuzzleManager.GetComponent<PicturePuzzleManager>().ClearAll();
    //        picturePuzzleManager.GetComponent<PicturePuzzleManager>().LoadTheSlot();
    //    }
    //    else
    //    {
    //        if (picturePuzzleManager.GetComponent<PicturePuzzleManager>().currentScores >= 7)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        picturePuzzleManager.GetComponent<PicturePuzzleManager>().gameOverPanel.SetActive(true);
            
    //    }
    //}
    //private IEnumerator LoadThePictureLetterNextSlot()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().currentSlotIndex < pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().picture_letter_match_list.Count - 1)
    //    {
    //        pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().currentSlotIndex++;
    //        pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().ClearAll();
    //        pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().LoadTheSlot();
    //    }
    //    else
    //    {
    //        if (pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().currentScores >= 7)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        pictureLetterMatchManager.GetComponent<PictureLetterMatchManager>().gameOverPanel.SetActive(true);
    //    }
    //}
    //private IEnumerator LoadNextSlotColorPuzzle()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (colorPuzzleManager.GetComponent<ColorPuzzleManager>().currentIndex<colorPuzzleManager.GetComponent<ColorPuzzleManager>().color_puzzle_list.Count-1)
    //    {
    //        colorPuzzleManager.GetComponent<ColorPuzzleManager>().ClearAll();
    //        colorPuzzleManager.GetComponent<ColorPuzzleManager>().currentIndex++;
    //        colorPuzzleManager.GetComponent<ColorPuzzleManager>().LoadNextSlot();
    //    }
    //    else
    //    {
    //        if (colorPuzzleManager.GetComponent<ColorPuzzleManager>().scores >= 4)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        colorPuzzleManager.GetComponent<ColorPuzzleManager>().gameOverPanel.SetActive(true);
    //    }
    //}
    //private IEnumerator PutSomeDelayForWorldAroundUsSlot()
    //{
    //    if (is_correct == true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //    }
    //    else if (is_correct == false)
    //    {
    //        yield return new WaitForSeconds(3.0f);
    //    }
    //    if (world_around_us_manager.GetComponent<WorldAroundUsManager>().current_index < world_around_us_manager.GetComponent<WorldAroundUsManager>().world_around_us_class_list.Count - 1)
    //    {
    //        world_around_us_manager.GetComponent<WorldAroundUsManager>().current_index++;
    //        world_around_us_manager.GetComponent<WorldAroundUsManager>().ClearAll();
    //        world_around_us_manager.GetComponent<WorldAroundUsManager>().LoadTheSlot();
    //    }
    //    else
    //    {
    //        if (world_around_us_manager.GetComponent<WorldAroundUsManager>().current_scores >= 3)
    //        {
    //            ManageSound(congrats_audio_strings[UnityEngine.Random.Range(0, 3)]);
    //        }
    //        else
    //        {
    //            ManageSound("GreatJobDoTryAgain");
    //        }
    //        world_around_us_manager.GetComponent<WorldAroundUsManager>().game_over_panel.SetActive(true);
    //    }
    //}
    //public void ChangeTheColor(string color_received,Image img_to_be_colored)
    //{
    //    switch (color_received)
    //    {
    //        case "Red":
    //            img_to_be_colored.color = new Color(1.0f, 0, 0, 1.0f);
    //            break;
    //        case "Yellow":
    //            img_to_be_colored.color = new Color(1.0f, 1.0f, 0, 1.0f);
    //            break;
    //        case "Blue":
    //            img_to_be_colored.color = new Color(0, 0.7294118f,1, 1.0f);
    //            break;
    //        case "Green":
    //            img_to_be_colored.color = new Color(0.2078432f, 0.6745098f, 0.1137255f, 1.0f);
    //            break;
    //        case "Pink":
    //            img_to_be_colored.color = new Color(0.9529412f, 0.5333334f, 0.9254903f, 1.0f);
    //            break;
    //        case "Orange":
    //            img_to_be_colored.color = new Color(1f, 0.7294118f, 0f, 1.0f);
    //            break;
    //    }
    //    this.gameObject.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    //}
    //public void SortingManagerAudio(string input_string)
    //{

    //            if(input_string.Contains("Alphabet"))
    //            {
    //                string new_string = input_string.Remove(0,8);
                  
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //                    sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //                    sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //                //return new_string;
    //            }
    //            if (input_string.Contains("Apparel"))
    //            {
    //                string new_string = input_string.Remove(0,7);
                  
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("Number"))
    //            {
    //                string new_string = input_string.Remove(0,6);
                  
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("Bathroom"))
    //            {
    //                string new_string = input_string.Remove(0, 8);
                
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("Kitchen"))
    //            {
    //                string new_string = input_string.Remove(0,7);
                
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("School"))
    //            {
    //                string new_string = input_string.Remove(0, 6);
                
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("Play"))
    //            {
    //                string new_string = input_string.Remove(0,4);
                
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
    //            if (input_string.Contains("Food"))
    //            {
    //                string new_string = input_string.Remove(0, 4);
                    
    //                if (PlayerPrefs.GetInt("Sound") == 1)
    //                {
    //            sortingManager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("AudioFiles/" + new_string);
    //            sortingManager.GetComponent<AudioSource>().Play();
    //                }
    //            }
        
    //}
    
}
