using Assets.Scripts.Menu.WorldSelection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelection : MonoBehaviour
{
    public GameObject WorldSelectionBox;

    public List<WorldData> worlds;

    private GameObject worldsText;
    private RectTransform worldsTextRect;
    public GameObject WorldsContainer;

    void Awake()
    {
        worlds = SaveLoadManager.GetWorlds();
        worldsText = GameObject.Find("Worlds");
        worldsTextRect = worldsText.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int multiplier = 0;
        for(int i = 0; i < worlds.Count; i++)
        {
            GameObject worldSelectionBox = (GameObject)Instantiate(WorldSelectionBox, new Vector3(0, 0, 0), Quaternion.identity, WorldsContainer.gameObject.transform);
            worldSelectionBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, worldsTextRect.anchoredPosition.y - 50 - (multiplier > 0 ? i * 150 : 0), 0);
            worldSelectionBox.GetComponent<WorldSelectionBox>().worldId = worlds[i].Id;
            Text text = worldSelectionBox.GetComponentInChildren<Text>();
            text.text = worlds[i].Name;
            worldSelectionBox.gameObject.name = worlds[i].Name;
            multiplier++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
