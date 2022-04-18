using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Button> buttons;
    int count = 0;

    public List<Text> itemsEditted;
    public List<string> WinningConditions = new List<string> { "1,2,3", "3,6,9", "7,8,9", "1,4,7", "1,5,9", "7,5,3", "8,5,2", "4,5,6" };

    private void Start()
    {

        foreach (var item in buttons)
        {
            itemsEditted.Add(item.GetComponentInChildren<Text>());
        }
    }

    public void OnClickingThisButton(Button button)
    {
        foreach (var item in buttons)
        {
            if (item == button)
            {
                if (count % 2 == 0)
                {
                    item.GetComponentInChildren<Text>().text = "X";
                    count++;
                    break;
                }
                else
                {
                    item.GetComponentInChildren<Text>().text = "O";
                    count--;
                    break;
                }
            }
        }
    }

    public void CheckIfWhichPlayerWins()
    {
        for (int i = 0; i < WinningConditions.Count; i++)
        {
            var asd = WinningConditions[i].Split(',');
            if (itemsEditted[int.Parse(asd[0]) - 1].text == "X" && itemsEditted[int.Parse(asd[1]) - 1].text == "X" && itemsEditted[int.Parse(asd[2]) - 1].text == "X")
            {
                Debug.Log("X Wins");
                ClearTextFields();
                break;
            }
            else if (itemsEditted[int.Parse(asd[0]) - 1].text == "O" && itemsEditted[int.Parse(asd[1]) - 1].text == "O" && itemsEditted[int.Parse(asd[2]) - 1].text == "O")
            {
                Debug.Log("O Wins");
                ClearTextFields();
                break;
            }
        }
    }

    void ClearTextFields()
    {
        count = 0;
        StartCoroutine(enumerator());
        IEnumerator enumerator()
        {
            foreach (var item in buttons)
                item.interactable = false;
            
            yield return new WaitForSeconds(2);

            foreach (var item in buttons)
            {
                item.interactable = true;
                item.GetComponentInChildren<Text>().text = "";
            }
        }
    }

}
