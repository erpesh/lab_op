#include "functions.h"

void inputFile(string fileName) {
    ofstream file(fileName);
    string inputText;
    getline(cin, inputText);
    while (inputText.length() > 0) {
        file << inputText << endl;
        getline(cin, inputText);

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
        if (line.empty()) break;
        second << line.length() << " " << line << " " << count << endl;
    }
    second.close();
    first.close();
}