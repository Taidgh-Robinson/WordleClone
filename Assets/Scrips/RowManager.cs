using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager: MonoBehaviour {
  // Start is called before the first frame update
  void Start() {

}

  // Update is called once per frame
  void Update() {

}

  void SetValue(object[] o) {
    char c = (char) o[0];
    int i = (int) o[1];
    transform.GetChild(i).gameObject.SendMessage("setValueCell", c);
  }

  void setCorrect(object[] o) {
    bool b = (bool) o[0];
    int i = (int) o[1];
    transform.GetChild(i).gameObject.SendMessage("setCorrectCell", b);
  }

  void setMid(object[] o) {
    bool b = (bool) o[0];
    int i = (int) o[1];
    transform.GetChild(i).gameObject.SendMessage("setMidCell", b);
  }

}