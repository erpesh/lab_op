#include "functions.h"

int main() {
    setlocale(LC_CTYPE, "");
    string firstFile = "first file.txt";
    string secondFile = "second file.txt";

    cout << "Введдіть текст: " << endl;
    inputFile(firstFile);
    editFile(firstFile, secondFile);
    cout << "Змінений текст: " << endl;
    outputFile(secondFile);
    return 0;
}