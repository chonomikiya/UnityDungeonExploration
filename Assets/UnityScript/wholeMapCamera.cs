using UnityEngine;

public class wholeMapCamera : MonoBehaviour {
    [SerializeField] Transform wholemapcamera = null;
    [SerializeField] float height = 150;

    private void Start() {
        
    }
    private void Update() {
        
    }
    public void SetWholePos(Vector3 _vector3){
        this.transform.position = new Vector3(_vector3.x,height,_vector3.z);
    }
}