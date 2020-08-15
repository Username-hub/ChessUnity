using UnityEngine;

namespace DefaultNamespace
{
    public class MoveTracker : MonoBehaviour
    {
        public GameObject MoveToTilePrefab;
        public GameObject MoveFromTilePrefab;
        
        private GameObject MoveToTile;
        private GameObject MoveFromTile;

        public void UpdateMoveTracker(MoveRecord moveRecord)
        {
            MoveToTile.transform.position = new Vector3(moveRecord.toX, moveRecord.toY);
            MoveFromTile.transform.position = new Vector3(moveRecord.fromX, moveRecord.fromY);
        }

        public void InitializeToMoveTracker()
        {
            MoveToTile = Instantiate(MoveToTilePrefab, new Vector3(1000, 1000, 0), Quaternion.identity);
            MoveFromTile = Instantiate(MoveFromTilePrefab, new Vector3(1000, 1020, 0), Quaternion.identity);
        }
    }
}