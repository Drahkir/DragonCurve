using UnityEngine;

namespace Assets.Scripts
{
    public class Grid : MonoBehaviour
    {
        public int NumberOfColumns = 8;
        public int NumberOfRows = 5;
        private float _tileSizeX;
        private float _tileSizeY;
        public GameObject CurvedTile;
        public GameObject StraightTile;

        // Use this for initialization
        void Start()
        {
            CreateTiles();
        }

        private void CreateTiles()
        {
            _tileSizeX = StraightTile.renderer.bounds.size.x;
            _tileSizeY = StraightTile.renderer.bounds.size.y;

            var numberOfTiles = NumberOfColumns * NumberOfRows;
            float xOffsetInit = 0.0f - (float)NumberOfColumns / 2;
            float yOffsetInit = 0.0f - (float)NumberOfColumns / 2;
            float xOffset = xOffsetInit;
            float yOffset = yOffsetInit;

            for (var tilesCreated = 0; tilesCreated < numberOfTiles; tilesCreated++)
            {
                if (tilesCreated % NumberOfColumns == 0)
                {
                    yOffset += _tileSizeY;
                    xOffset = xOffsetInit;
                }
                xOffset += _tileSizeX;
                Instantiate(CurvedTile, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation);
            }
        }
    }
}
