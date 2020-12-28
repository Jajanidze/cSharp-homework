CREATE TABLE Teacher (
  id bigint(20) NOT NULL, 
  name varchar(40) NOT NULL,
  lastname varchar(40) NOT NULL,
  sex varchar(40) NOT NULL,
  subject varchar(128),
  PRIMARY KEY (id)
);



CREATE TABLE Pupil(
    id bigint(20) NOT NULL,
    name varchar(40) NOT NULL,
    lastname varchar(40) NOT NULL,
    sex varchar(40) NOT NULL,
    class int NOT NULL,
    PRIMARY KEY (id)
);


CREATE TABLE Teacher_Pupil(
    teacher_id bigint(20) NOT NULL,
    pupil_id bigint(20) NOT NULL,
    
    FOREIGN KEY (teacher_id) REFERENCES Teacher (id),
    FOREIGN KEY (pupil_id) REFERENCES Pupil (id),
    
    PRIMARY KEY (teacher_id, pupil_id)
);


INSERT INTO Teacher VALUES (1, 'Nino', 'Nabakhteveli', 'Female','Mathematics');
INSERT INTO Teacher VALUES (2, 'Emzar', 'Khmaladze', 'Male',"Linear Algebra");


INSERT INTO Pupil VALUES (1,'Luka','Jajanidze','Male',10);
INSERT INTO Pupil VALUES (2,'Giorgi','Gabelaia','Male',10);
INSERT INTO Pupil VALUES (3,'Giorgi','Jajanidze','Male',9);


INSERT INTO Teacher_Pupil VALUES(2,1);
INSERT INTO Teacher_Pupil VALUES(1,2);
INSERT INTO Teacher_Pupil VALUES(1,3);

SELECt Teacher.name, Teacher.lastname
FROM Teacher
JOIN Teacher_Pupil on (Teacher.id=Teacher_Pupil.teacher_id)
JOIN Pupil on (Pupil.id=Teacher_Pupil.pupil_id)
WHERE Pupil.name == 'Giorgi';




















