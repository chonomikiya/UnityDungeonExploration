using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

namespace DungeonExploration.Maze{
    public class MapUI : MonoBehaviour {
        [SerializeField] Sprite N,E,S,W,NE,NES,NESW,NEW,NS,NSW,NW,ES,ESW,EW,SW,Block;
        [SerializeField] Sprite icon_tresure,icon_door;
        private void Start() {
            
        }
        private void Update() {
            
        }
        public Sprite GetIcon(MazeType _mazetype){
            Sprite _icon = null;
            switch(_mazetype){
                case MazeType.Tresure:
                    _icon = icon_tresure;
                    break;
                case MazeType.Door:
                    _icon = icon_door;
                    break;
                default:
                    Debug.Log("MapUI.GetIcon() switch(mazetype) err");
                    break;
            }
            return _icon;
        }
        //intではなくenumを使って分かりやすいswitch文を作るべき
        //作った
        public Sprite GetMapSprite(Map _map){
            Sprite spritetype = null;
            switch(_map){
                case Map.NESW:
                    spritetype = NESW;
                    break;
                case Map.NES:
                    spritetype = NES;
                    break;
                case Map.NEW:
                    spritetype = NEW;
                    break;
                case Map.NE:
                    spritetype = NE;
                    break;
                case Map.NSW:
                    spritetype = NSW;
                    break;
                case Map.NS:
                    spritetype = NS;
                    break;
                case Map.NW:
                    spritetype = NW;
                    break;
                case Map.N:
                    spritetype = N;
                    break;
                case Map.ESW:
                    spritetype = ESW;
                    break;
                case Map.ES:
                    spritetype = ES;
                    break;
                case Map.EW:
                    spritetype = EW;
                    break;
                case Map.E:
                    spritetype = E;
                    break;
                case Map.SW:
                    spritetype = SW;
                    break;
                case Map.S:
                    spritetype = S;
                    break;
                case Map.W:
                    spritetype = W;
                    break;
                case Map.Block:
                    spritetype = Block;
                    break;
                default:
                    Debug.Log("miniMapSprite Switch script err");
                    break;
            }
            return spritetype;
        }
    }
}