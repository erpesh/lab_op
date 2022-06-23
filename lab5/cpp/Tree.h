#pragma once
#include <iostream>
#include <stack>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

struct Item {
    string name;
    int number;
};

struct Node {
    Item* data;
    Node* left;
    Node* right;
};

class Tree {
private:
    Node* root;

    void addElement(Node*&, Item*);
    void printTree(Node*, int);
    void printInOrder(Node*);

public:
    Tree();
    void addElement(Item*);
    void printTree();
};
