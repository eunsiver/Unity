using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
  private GameObject[] characters;
  public int selectedCharacter = 0;
  private void Start()
  {
    characters = new GameObject[transform.childCount];
    for (int i = 0; i < transform.childCount; i++)
    {
      characters[i] = transform.GetChild(i).gameObject;

    }

  }
  // Start is called before the first frame update
  public void NextCharacter()
  {
    characters[selectedCharacter].SetActive(false);
    selectedCharacter = (selectedCharacter + 1) % characters.Length;
    characters[selectedCharacter].SetActive(true);
  }
  public void PreviousCharacter()
  {
    characters[selectedCharacter].SetActive(false);
    selectedCharacter--;
    if (selectedCharacter < 0)
    {
      selectedCharacter += characters.Length;
    }
    characters[selectedCharacter].SetActive(true);
    ;

  }

  // Update is called once per frame
  public void StartGame()
  {
    PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    LevelLoader.LoadScene("Main-내부");
  }
}
