using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class ToMoveVisualizer : MonoBehaviour
    {
        public GameObject toMoveSprite;
        
        public List<GameObject> toMoveSprites = new List<GameObject>();
    

        public List<GameObject> createToMoveSprite(List<PositionToMove> positionToMoves)
        {
            List<GameObject> res = new List<GameObject>();
            int len = positionToMoves.Count;
            for (int i = 0; i < len; i++)
            {
                res.Add(Instantiate(toMoveSprite, new Vector3(transform.position.x + positionToMoves[i].posX,transform.position.y + positionToMoves[i].posY), Quaternion.identity));
            }

            return res;
        }

        public void destroyToMoveObjects()
        {
            foreach (var x in toMoveSprites)
            {
                Destroy(x);
            }
            toMoveSprites.Clear();
        }
    }
}