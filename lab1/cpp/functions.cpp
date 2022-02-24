#include "functions.h"

void inputFile(string fileName) {
    ofstream file(fileName);
    string inputText;
//    getline(cin, inputText);
    char key = 7;
    while (true) {
        getline(cin, inputText);
        if (inputText[0] == key) {
            break;
        }
        else {
            file << inputText << endl;
        }
    }
    file.close();
}


void outputFile(string fileName) {
    ifstream file(fileName);
    string line;
    while (!file.eof()) {
        getline(file, line);
        cout << line << endl;
    }
    file.close();
}

void editFile(string firstFile, string secondFile) {

    ofstream second(secondFile);
    ifstream first(firstFile);

    string line;
    int count = 0;
    while (!first.eof()) {
        count++;
        getline(first, line);
        if (first.eof()) {
            break;
        }
        second << line.length() << " " << line << " " << count << endl;
    }
    second.close();
    first.close();
}
