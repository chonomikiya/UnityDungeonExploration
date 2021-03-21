using UnityEngine;
using System;
using System.Collections.Generic;

namespace DungeonExploration.Maze{
    public class TresureInfo : MazeInfo {
        SpriteRenderer myicon = null;
        List<DataRow> tresure;
        [SerializeField] int prefix_id,item_id;
        [SerializeField] int myid;
        [SerializeField] string myitem;
        [SerializeField] int mysell;
        ObtainedItem m_obtainedItem;
        GameSoundManage gameSoundManage;
        protected override void Awake()
        {
            base.Awake();    
            GetComponentIconSprite();
        }
        public void SetTresureList(List<DataRow> _mlist){
            this.tresure = _mlist;
            ListToParse();
        }
        public void ListToParse(){
            foreach(DataRow dr in tresure){
                myid = (int)dr["id"];
                myitem = dr["item"].ToString();
                mysell = (int)dr["sell"];
            }
        }
        public string GetTresureItem(){
            return this.myitem;
        }
        public List<DataRow> GetTresureList(){
            return tresure;
        }
        public void SetObtainedScript(ObtainedItem _obtaineditem){
            this.m_obtainedItem = _obtaineditem;
        }
        public void PassToItemList(){
            m_obtainedItem.AddItemList(GetTresureList());
        }
        //ItemとPrefixのId値を格納するの関数を呼び出す
        public void ItemuIdSet(int _itemid,int _prefixid){
            SetItemId(_itemid);
            SetPrefixId(_prefixid);
        }
        public void SetGameSoundReference(GameSoundManage _gamesoundmanage){
            this.gameSoundManage = _gamesoundmanage;
        }
        public void OpenSound_Play(){
            gameSoundManage.BoxOpen_Play();
        }
        public void SetItemId(int _itemId){
            this.item_id = _itemId;
        }
        public void SetPrefixId(int _prefixId){
            this.prefix_id = _prefixId;
        }
        public override void SetMapSprite(Sprite _sprite)
        {
            base.SetMapSprite(_sprite);
        }
        public void SetIcon(Sprite _sprite){
            this.myicon.sprite = _sprite;
        }
        public void LookWorldRotation_South(GameObject _gameopbject){
            Vector3 tmp = _gameopbject.transform.eulerAngles;
            tmp.y = 0;
            _gameopbject.transform.eulerAngles = tmp;
        }
        private void GetComponentIconSprite(){
            this.myicon = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
        }
        
        
        public override void ChangeMapSprite(){
            //Tresureの部屋はQuaternionで向きを操作しているかつ入口が一つな為miniMapの画像は北で固定
            SetMapSprite(GetComponentMapUI().GetMapSprite(Map.S));
            SetIcon(base.GetComponentMapUI().GetIcon(GetMazeType()));
            LookWorldRotation_South(myicon.gameObject);
        }
        
    }
}