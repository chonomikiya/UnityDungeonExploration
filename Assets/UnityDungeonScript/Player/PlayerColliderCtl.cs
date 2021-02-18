using System;
using UnityEngine;
using DungeonExploration.Maze;

namespace DungeonExploration.Player{
    public class PlayerColliderCtl : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if(other.tag == "Path"){
                if(!other.gameObject.GetComponent<MazeInfo>().GetBoolMapView()){
                    other.gameObject.GetComponent<MazeInfo>().ViewMiniMap();
                }
            }
            if(other.tag == "Tresure"){
                if(!other.gameObject.GetComponent<TresureInfo>().GetBoolMapView()){
                    other.gameObject.GetComponent<TresureInfo>().ViewMiniMap();
                }
            }
        }
    }
}