import pickle


def file_input(file_name):
    with open(file_name, 'wb') as file:
        universities = {}

        while True:
            name = input("\nВведіть назву ВНЗ: ")

            university = {'Місто': input("Введіть назву міста: "),
                          'Рівень акредитації': int(input('Введіть рівень акредитації: ')),
                          'Кількість факультетів': int(input("Введіть кількість факультетів: "))}
            faculties = {}
            for _ in range(university['Кількість факультетів']):
                faculty_name = input("Введіть назву факультету: ")
                faculties[faculty_name] = int(input(f"Введіть к-сть студентів на {faculty_name}: "))

            university["Факультети"] = faculties

            universities[name] = university

            users_answer = input("Бажаєте продовжити? ('н' якщо ні): ")
            if users_answer.lower() == 'н':
                break

        pickle.dump(universities, file)


def find_faculty(city, file_name):
    universities = {}
    with open(file_name, 'rb') as file:
        universities = pickle.load(file)

    biggest_faculty = {'Назва ВНЗ': None, 'Факультет': None, 'К-сть студентів': 0}
    for univ in universities.keys():
        if universities[univ]['Місто'] == city:
            for faculty in universities[univ]['Факультети'].keys():
                num_of_students = universities[univ]["Факультети"][faculty]
                if num_of_students > biggest_faculty['К-сть студентів']:
                    biggest_faculty['К-сть студентів'] = num_of_students
                    biggest_faculty["Назва ВНЗ"] = univ
                    biggest_faculty['Факультет'] = faculty

    print(
        f'\n{biggest_faculty["К-сть студентів"]} учнів на факультеті {biggest_faculty["Факультет"]} в {biggest_faculty["Назва ВНЗ"]}\n')


def create_second_file(first_file, second_file):
    new_universities = {}
    with open(first_file, 'rb') as file:
        universities = pickle.load(file)

    with open(second_file, 'wb') as file:
        for univ in universities.keys():
            acr_level = universities[univ]['Рівень акредитації']
            if acr_level == 3 or acr_level == 4:
                new_universities[univ] = {'Рівень акредитації': acr_level, 'Місто': universities[univ]['Місто']}

        pickle.dump(new_universities, file)


def output_first_file(file_name):
    with open(file_name, 'rb') as file:
        universities = pickle.load(file)

        for univ in universities.keys():
            print(
                f'Назва: {univ}, місто: {universities[univ]["Місто"]}, рів. акр: {universities[univ]["Рівень акредитації"]}, к-сть факультетів: {universities[univ]["Кількість факультетів"]}')
            for faculty in universities[univ]["Факультети"]:
                print(f"  {faculty}: {universities[univ]['Факультети'][faculty]} студентів")
    print()


def output_second_file(file_name):
    with open(file_name, 'rb') as file:
        universities = pickle.load(file)

        for univ in universities.keys():
            print(
                f'Назва: {univ}, місто: {universities[univ]["Місто"]}, рівень акредитації: {universities[univ]["Рівень акредитації"]}')
