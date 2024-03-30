using System.Collections.Generic;

namespace Assets._Code.Infrastructure.SaveLoadSystem
{
    [System.Serializable]
    public class WorldData
    {
        public float x, y;
        public float Health;
        public List<int> Items;
    }
}