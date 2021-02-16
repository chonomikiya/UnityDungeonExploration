using UnityEngine;


namespace DungeonExploration.Maze{
    public class TresureInfo : MazeInfo {
        SpriteRenderer myicon = null;
        MazeType mymazetype;
        protected override void Awake()
        {
            base.Awake();    
            GetComponentIconSprite();
            mymazetype = MazeType.Tresure;
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