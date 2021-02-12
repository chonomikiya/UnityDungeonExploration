using UnityEngine;


namespace DungeonExploration.Maze{
    public class TresureInfo : MonoBehaviour {
        Map map;
        public Map GetMapType(){
            return this.map;
        }
        public void SetMapType(Map _map){
            this.map = _map;
        }

    }
}