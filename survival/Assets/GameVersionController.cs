using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVersionController : MonoBehaviour
{
    // Start is called before the first frame update
    Text versionText;
    void Start()
    {
        versionText = GetComponent<Text>();
        versionText.text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
