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
            worldSelection.worlds.RemoveAt(worldId);
            worldSelection.RenderWorldSelectionBoxes();
            SaveLoadManager.RemoveWorld(worldId);
            Destroy(gameObject);
        }

        public void SelectWorld()
        {
            WorldGenerator.world = new global::World()
            {
                Id = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Id,
                Name = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Name,
                Size = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Size,
                Chunks = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Chunks,
                PlayerPositionX = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).PlayerPositionX,
                PlayerPositionY = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).PlayerPositionY
            };

            WorldGenerator.chunks = worldSelection.worlds.FirstOrDefault(w => w.Id == worldId).Chunks;
            SceneManager.LoadScene("Ingame");
        }
    }
}
