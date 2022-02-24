def input_file(name):
    print('Введіть текст: ')
    key = chr(7)
    with open(name, 'w') as file:
        while True:
            line_text = input() + ' '
            if line_text[0] != key:
                line_text += "\n"
                file.write(line_text)
            else:
                break

def print_text(name):
    print(f'Текст із файлу {name}: ')
    with open(name) as file:
        text = file.read()
        print(text)

def edit_file(first_file, second_file):
    with open(first_file) as first, open(second_file, 'w') as second:
        text = first.readlines()

        counter = 0
        for line in text:
            line = line.rstrip()
            counter += 1
            new_line = f'{len(line)} {line} {str(counter)}\n'
            second.write(new_line)


