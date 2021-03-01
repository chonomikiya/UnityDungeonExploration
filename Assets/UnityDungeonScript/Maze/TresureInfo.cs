using UnityEngine;


namespace DungeonExploration.Maze{
    public class TresureInfo : MazeInfo {
        SpriteRenderer myicon = null;
        MazeType mymazetype;
        [SerializeField] int prefix_id,item_id;
        [SerializeField] string tresurename;

        protected override void Awake()
        {
            base.Awake();    
            GetComponentIconSprite();
            mymazetype = MazeType.Tresure;
        }
        //ItemとPrefixのId値を格納するの関数を呼び出す
        public void ItemuIdSet(int _itemid,int _prefixid){
            SetItemId(_itemid);
            SetPrefixId(_prefixid);
        }
        public void SetItemId(int _itemId){
            this.item_id = _itemId;
        }
        public void SetPrefixId(int _prefixId){
            this.prefix_id = _prefixId;
        }
        public void SetTresureItem(string _tresure){
            this.tresurename = _tresure;
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
            SetIcon(base.GetComponentMapUI().GetIcon(mymazetype));
            LookWorldRotation_South(myicon.gameObject);
        }
    }
}