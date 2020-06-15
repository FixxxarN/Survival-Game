using Assets.Scripts.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu.WorldSelection
{
    public class WorldSelectionBox : MonoBehaviour
    {
        global::WorldSelection worldSelection;
        public int worldId;

        void Start()
        {
            worldSelection = FindObjectOfType<global::WorldSelection>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DeleteWorld()
        {
            SaveLoadManager.RemoveWorld(worldId);
            Destroy(gameObject);
        }

        public void SelectWorld()
        {
            WorldGenerator.chunks = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Chunks;
            SceneManager.LoadScene("Ingame");
        }
    }
}
