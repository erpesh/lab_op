#include <fstream>
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include "Tree.h"

using namespace std;

void fileOutput(string);
void readFile(string);
vector<string> getKeyWords();
bool isKeyWord(string);
bool isQuote(char);
bool isStillWord(char);