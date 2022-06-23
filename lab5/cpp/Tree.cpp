#include "Tree.h"

Tree::Tree() {
    root = NULL;
}

// public addElement
void Tree::addElement(Item *element) {
    this->addElement(root, element);
}

// private addElement
void Tree::addElement(Node *&node, Item *element) {
    if (!node) {
        node = new Node;
        node->left = NULL;
        node->right = NULL;
        node->data = element;
        return;
    }
    if (element->name == node->data->name){
        node->data->number++;
    }
    if (element->name > node->data->name){
        addElement(node->right, element);
    }
    if (element->name < node->data->name){
        addElement(node->left, element);
    }
}
// public printTree
void Tree::printTree() {
    cout << "Identifiers tree: " << endl;
    printTree(this->root, 0);
    cout << endl << "Identifiers in order:" << endl;
    printInOrder(this->root);
}

//private printTree
void Tree::printTree(Node *node, int a) {
    if (!node) {
        return;
    }
    printTree(node->right, ++a);

    for (int i = 1; i < a; i++) {
        cout << "\t";
    }
    cout << node->data->name << " : " << node->data->number << endl;

    this->printTree(node->left, a);
}

void Tree::printInOrder(Node * node) {
    if (!node) {
        return;
    }
    printInOrder(node->left);
    cout << node->data->name << " : " << node->data->number << endl;
    printInOrder(node->right);
}

