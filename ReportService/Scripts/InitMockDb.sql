CREATE TABLE deps (
                             id SERIAL PRIMARY KEY,
                             name VARCHAR(255) NOT NULL,
                             active BOOLEAN NOT NULL
);

CREATE TABLE emps (
                           id SERIAL PRIMARY KEY,
                           name VARCHAR(255) NOT NULL,
                           inn VARCHAR(20) NOT NULL,
                           departmentid INTEGER NOT NULL,
                           FOREIGN KEY (departmentid) REFERENCES deps(id)
);

INSERT INTO deps (name, active) VALUES
                                             ('ФинОтдел', TRUE),
                                             ('Бухгалтерия', TRUE),
                                             ('ИТ', TRUE);

INSERT INTO emps (name, inn, departmentId) VALUES
                                                    ('Андрей Сергеевич Бубнов', '1', (SELECT Id FROM deps WHERE Name = 'ФинОтдел')),
                                                    ('Григорий Евсеевич Зиновьев', '2', (SELECT Id FROM deps WHERE Name = 'ФинОтдел')),
                                                    ('Яков Михайлович Свердлов', '3', (SELECT Id FROM deps WHERE Name = 'ФинОтдел')),
                                                    ('Алексей Иванович Рыков', '4', (SELECT Id FROM deps WHERE Name = 'ФинОтдел'));

INSERT INTO emps (name, inn, departmentId) VALUES
                                                    ('Василий Васильевич Кузнецов', '5', (SELECT Id FROM deps WHERE Name = 'Бухгалтерия')),
                                                    ('Демьян Сергеевич Коротченко', '6', (SELECT Id FROM deps WHERE Name = 'Бухгалтерия')),
                                                    ('Михаил Андреевич Суслов', '7', (SELECT Id FROM deps WHERE Name = 'Бухгалтерия'));

INSERT INTO emps (name, inn, departmentId) VALUES
                                                    ('Фрол Романович Козлов', '8', (SELECT Id FROM deps WHERE Name = 'ИТ')),
                                                    ('Дмитрий Степанович Полянски', '9', (SELECT Id FROM deps WHERE Name = 'ИТ')),
                                                    ('Андрей Павлович Кириленко', '10', (SELECT Id FROM deps WHERE Name = 'ИТ')),
                                                    ('Арвид Янович Пельше', '11', (SELECT Id FROM deps WHERE Name = 'ИТ'));

