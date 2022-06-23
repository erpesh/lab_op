#include "operations.h"

void fileOutput(string name) {
    ifstream file(name);
    while (!file.eof()) {
        string str;
        getline(file, str);
        cout << str << endl;
    }
}

void readFile(string name) {
    Tree tree;
    ifstream file(name);
    while (!file.eof()) {
        string str;
        getline(file, str);
        bool isWord = false;
        bool isInsideString = false;
        string newWord = "";
        for (char i : str){
            if (isQuote(i)) {
                isInsideString = !isInsideString;
            }
            if ((isalpha(i) || i == '_') && !isWord && !isInsideString){
                isWord = true;
            }
            if (isWord && !isInsideString){
                if (isStillWord(i)){
                    newWord += i;
                }else{
                    if (!isKeyWord(newWord)){
                        Item* newItem = new Item;
                        newItem->name = newWord;
                        newItem->number = 1;
                        tree.addElement(newItem);
                    }
                    newWord = "";
                    isWord = false;
                }
            }
        }
    }
    tree.printTree();
    file.close();
}

vector<string> getKeyWords(){
    vector<string> keywords;
    ifstream file("keywords.txt");
    while (!file.eof()) {
        string word;
        getline(file, word);
        word = word.substr(0, word.length()-1);
        keywords.push_back(word);
    }
    file.close();
    return keywords;
}

bool isKeyWord(string word) {
    vector<string> keywords = getKeyWords();
    return find(keywords.begin(), keywords.end(), word) != keywords.end();
}

bool isQuote(char chr) {
    return chr == '"' || chr == char(39); // char(39) - одинарна кавичка
}

bool isStillWord(char chr) {
    return isalpha(chr) || isdigit(chr) || chr == '_';
}


