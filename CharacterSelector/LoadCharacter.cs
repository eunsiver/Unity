using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
  public GameObject[] characterPrefabs;
  public Transform spawnPoint;
  int selectedCharacter;
  public static Rigidbody Character_rigidbody;
  public static Animation Character_anim;
  public static Transform ChacterPo;
  [SerializeField] private GameObject CharacterParent;

	void Start() {
		LoadC();
	}

  // Start is called before the first frame update
  public void LoadC()
  {
    selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    Debug.Log(selectedCharacter);
    GameObject prefab = characterPrefabs[selectedCharacter];
    GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    
    clone.transform.SetParent(CharacterParent.transform, false);
    Character_rigidbody = clone.GetComponent<Rigidbody>();
    Character_anim = clone.GetComponent<Animation>();
    clone.transform.position=new Vector3(0,0,0);

  }

}
