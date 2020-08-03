using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class RandomCharacter : MonoBehaviour
    {
        private Body body;
        private Hair hair;

        void Start()
        {
            body = GetComponentInChildren<Body>();
            hair = GetComponentInChildren<Hair>();
        }

        public void GenerateRandomCharacter()
        {
            body.selectedGender = Random.Range(0, body.Sprites.Length);
            body.selectedColor = Random.Range(0, body.SkinColors.Length);
            body.SetSprite();
            body.SetColor();
            hair.selectedHair = Random.Range(0, hair.Hairs.Length);
            hair.selectedHairColor = Random.Range(0, hair.HairColors.Length);
            hair.SetHair();
            hair.SetHairColor();
        }
    }
}
