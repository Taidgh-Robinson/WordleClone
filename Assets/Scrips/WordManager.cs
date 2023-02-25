using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager: MonoBehaviour {

  string word;
  string target;
  bool[] hits = new bool[6];
  int activeRow;
  WordList wordlist;

  bool isActive;
  public Text notAWord;
  public Text youWin;
  public Text youLose;
  public Text theWord;

  // Start is called before the first frame update
  void Start() {
    word = "";
    activeRow = 0;
    wordlist = new WordList();
    target = wordlist.getRandomWord().ToLower();
    notAWord.gameObject.SetActive(false);
    youWin.gameObject.SetActive(false);
    youLose.gameObject.SetActive(false);
    theWord.gameObject.SetActive(false);
    isActive = true;

  }

  // Update is called once per frame
  void Update() {
    if (isActive) {
      handleLetterpress();

      if (Input.GetKeyDown(KeyCode.Backspace) && word.Length > 0) {
        deleteChar();
      }

      if (Input.GetKeyDown(KeyCode.Return) && word.Length == 6) {
        checkWord();
      }
    }
  }

  void handleLetterpress() {
    if (Input.GetKeyDown("a") && word.Length < 6) {
      addCharToWord('a');
    }
    if (Input.GetKeyDown("b") && word.Length < 6) {
      addCharToWord('b');
    }
    if (Input.GetKeyDown("c") && word.Length < 6) {
      addCharToWord('c');
    }
    if (Input.GetKeyDown("d") && word.Length < 6) {
      addCharToWord('d');
    }
    if (Input.GetKeyDown("e") && word.Length < 6) {
      addCharToWord('e');
    }
    if (Input.GetKeyDown("f") && word.Length < 6) {
      addCharToWord('f');
    }
    if (Input.GetKeyDown("g") && word.Length < 6) {
      addCharToWord('g');
    }
    if (Input.GetKeyDown("h") && word.Length < 6) {
      addCharToWord('h');
    }
    if (Input.GetKeyDown("i") && word.Length < 6) {
      addCharToWord('i');
    }
    if (Input.GetKeyDown("j") && word.Length < 6) {
      addCharToWord('j');
    }
    if (Input.GetKeyDown("k") && word.Length < 6) {
      addCharToWord('k');
    }
    if (Input.GetKeyDown("l") && word.Length < 6) {
      addCharToWord('l');
    }
    if (Input.GetKeyDown("m") && word.Length < 6) {
      addCharToWord('m');
    }
    if (Input.GetKeyDown("n") && word.Length < 6) {
      addCharToWord('n');
    }
    if (Input.GetKeyDown("o") && word.Length < 6) {
      addCharToWord('o');
    }
    if (Input.GetKeyDown("p") && word.Length < 6) {
      addCharToWord('p');
    }
    if (Input.GetKeyDown("q") && word.Length < 6) {
      addCharToWord('q');
    }
    if (Input.GetKeyDown("r") && word.Length < 6) {
      addCharToWord('r');
    }
    if (Input.GetKeyDown("s") && word.Length < 6) {
      addCharToWord('s');
    }
    if (Input.GetKeyDown("t") && word.Length < 6) {
      addCharToWord('t');
    }
    if (Input.GetKeyDown("u") && word.Length < 6) {
      addCharToWord('u');
    }
    if (Input.GetKeyDown("v") && word.Length < 6) {
      addCharToWord('v');
    }
    if (Input.GetKeyDown("w") && word.Length < 6) {
      addCharToWord('w');
    }
    if (Input.GetKeyDown("x") && word.Length < 6) {
      addCharToWord('x');
    }
    if (Input.GetKeyDown("y") && word.Length < 6) {
      addCharToWord('y');
    }
    if (Input.GetKeyDown("z") && word.Length < 6) {
      addCharToWord('z');
    }

  }

  void addCharToWord(char c) {
    word += c;
    int i = word.Length - 1;
    object[] o = new object[2];
    o[0] = c;
    o[1] = i;
    transform.GetChild(activeRow).gameObject.SendMessage("SetValue", o);
  }

  void deleteChar() {
    int i = word.Length - 1;
    word = word.Substring(0, word.Length - 1);

    object[] o = new object[2];
    o[0] = ' ';
    o[1] = i;
    transform.GetChild(activeRow).gameObject.SendMessage("SetValue", o);
  }

  //TODO: Make less sloppy, will never happen
  void checkWord() {
    if (wordlist.contains(word.ToUpper())) {
      //First find all the letters in the right spot
      for (int i = 0; i < 6; i++) {
        hits[i] = false;
        if (word[i] == target[i]) {
          hits[i] = true;
          object[] o = new object[2];
          o[0] = true;
          o[1] = i;
          transform.GetChild(activeRow).gameObject.SendMessage("setCorrect", o);
        } else {
          object[] o = new object[2];
          o[0] = false;
          o[1] = i;
          transform.GetChild(activeRow).gameObject.SendMessage("setCorrect", o);
        }
      }

      //check for win
      bool win = true;
      foreach(bool b in this.hits) {
        win = win & b;
      }

      if (win) {
        isActive = false;
        StartCoroutine(cleanUpRows(win));
        return;
      }

      LinkedList < char > nonHits = new LinkedList < char > ();
      //Then find all the letters in the word in the wrong spot
      for (int i = 0; i < 6; i++) {
        if (!hits[i]) {
          nonHits.AddLast(target[i]);
        }
      }

      for (int i = 0; i < 6; i++) {
        if (!hits[i] && nonHits.Contains(word[i])) {
          object[] o = new object[2];
          o[0] = true;
          o[1] = i;
          transform.GetChild(activeRow).gameObject.SendMessage("setMid", o);
          nonHits.Remove(word[i]);

        }
      }

      word = "";
      activeRow += 1;
      notAWord.gameObject.SetActive(false);
      if (activeRow == 6) {
        StartCoroutine(cleanUpRows(false));
      }
    } else {

      notAWord.text = this.word + " is not a word!";
      notAWord.gameObject.SetActive(true);
    }

  }

  IEnumerator cleanUpRows(bool win) {

    for (int i = 0; i < 6; i++) {
      transform.GetChild(i).gameObject.SetActive(false);
      yield
      return new WaitForSeconds(0.5f);
    }

    if (win) {
      youWin.gameObject.SetActive(true);
    } else {
      youLose.gameObject.SetActive(true);
      theWord.text = "The word was " + this.target;
      theWord.gameObject.SetActive(true);
    }

  }
}