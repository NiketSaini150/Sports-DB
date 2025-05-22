-- Insert Data for Tbl_Sports
INSERT INTO Tbl_Sports (Sports_Name) VALUES
('Football'), ('Basketball'), ('Cricket'), ('Tennis'), ('Baseball'),
('Rugby'), ('Hockey'), ('Golf'), ('Badminton'), ('Boxing'),
('Swimming'), ('Cycling'), ('Table Tennis'), ('Athletics'), ('Netball'),
('Volleyball'), ('Squash'), ('Fencing'), ('Handball'), ('Wrestling'),
('Rowing'), ('Sailing'), ('Surfing'), ('Skiing'), ('Snowboarding'),
('Lacrosse'), ('Rugby League'), ('Curling'), ('Karate'), ('Taekwondo'),
('Archery'), ('Motor Racing'), ('Equestrian'), ('Softball'), ('Kickboxing'),
('Polo'), ('CrossFit'), ('Dodgeball'), ('Weightlifting'), ('Track and Field'), ('Billiards'), ('Chess'),
('Horseback Riding'), ('Paragliding'), ('Rock Climbing'), ('Wushu'), ('Judo'),
('Boxercise'), ('Bowling'), ('Ice Hockey'), ('Paintball'), ('Bocce'),
('Archer'), ('Billiards'), ('Chess'), ('Horseback Riding'), ('Paragliding'),
('Rock Climbing'), ('Wushu'), ('Judo'), ('Boxercise'), ('Bowling');

-- Insert Data for Tbl_Players
INSERT INTO Tbl_Players (First_Name, Last_Name, Age, Gender, Experience, Injury_Status, Sports_ID) VALUES
('John', 'Doe', 25, 'Male', 5, 'Healthy', 1), 
('Jane', 'Smith', 23, 'Female', 3, 'Injured', 2),
('Michael', 'Johnson', 28, 'Male', 7, 'Healthy', 3),
('Emily', 'Davis', 22, 'Female', 2, 'Healthy', 4),
('Chris', 'Brown', 30, 'Male', 8, 'Healthy', 5),
('Olivia', 'Martinez', 24, 'Female', 4, 'Healthy', 6),
('James', 'Wilson', 26, 'Male', 6, 'Injured', 7),
('Sophia', 'Moore', 29, 'Female', 6, 'Healthy', 8),
('David', 'Taylor', 31, 'Male', 10, 'Healthy', 9),
('Isabella', 'Anderson', 27, 'Female', 5, 'Healthy', 10),
('Ethan', 'Thomas', 20, 'Male', 1, 'Injured', 11),
('Mia', 'Jackson', 23, 'Female', 3, 'Healthy', 12),
('Lucas', 'White', 25, 'Male', 4, 'Healthy', 13),
('Charlotte', 'Harris', 32, 'Female', 9, 'Healthy', 14),
('Henry', 'Martin', 21, 'Male', 2, 'Healthy', 15),
('Amelia', 'Garcia', 22, 'Female', 3, 'Injured', 16),
('Sebastian', 'Rodriguez', 24, 'Male', 4, 'Healthy', 17),
('Harper', 'Lewis', 28, 'Female', 5, 'Healthy', 18),
('Aiden', 'Walker', 27, 'Male', 6, 'Injured', 19),
('Lily', 'Young', 25, 'Female', 4, 'Healthy', 20),
('Jack', 'King', 29, 'Male', 7, 'Healthy', 21),
('Ella', 'Scott', 22, 'Female', 2, 'Healthy', 22),
('Ben', 'Green', 24, 'Male', 3, 'Healthy', 23),
('Zoe', 'Adams', 26, 'Female', 5, 'Healthy', 24),
('Matthew', 'Baker', 30, 'Male', 6, 'Injured', 25),
('Layla', 'Gonzalez', 23, 'Female', 4, 'Healthy', 26),
('Joshua', 'Nelson', 28, 'Male', 8, 'Healthy', 27),
('Chloe', 'Carter', 27, 'Female', 5, 'Healthy', 28),
('Ryan', 'Mitchell', 31, 'Male', 9, 'Healthy', 29),
('Ava', 'Perez', 24, 'Female', 4, 'Injured', 30),
('Daniel', 'Roberts', 33, 'Male', 10, 'Healthy', 31),
('Madison', 'Gomez', 26, 'Female', 5, 'Healthy', 32),
('Luke', 'Phillips', 29, 'Male', 6, 'Healthy', 33),
('Victoria', 'Martinez', 22, 'Female', 2, 'Healthy', 34),
('Jackson', 'Garcia', 27, 'Male', 5, 'Healthy', 35),
('Samantha', 'Jackson', 32, 'Female', 8, 'Healthy', 36),
('Oliver', 'Miller', 25, 'Male', 3, 'Healthy', 37),
('Riley', 'Davis', 26, 'Female', 6, 'Healthy', 38),
('Mason', 'Lopez', 30, 'Male', 7, 'Injured', 39),
('Lucas', 'Taylor', 24, 'Male', 4, 'Healthy', 40),
('Hannah', 'Clark', 25, 'Female', 5, 'Injured', 41),
('Jacob', 'Rodriguez', 28, 'Male', 7, 'Healthy', 42),
('Charlotte', 'Walker', 23, 'Female', 3, 'Healthy', 43),
('Evan', 'Young', 27, 'Male', 6, 'Injured', 44),
('Ella', 'Sanchez', 22, 'Female', 2, 'Healthy', 45),
('Gabriel', 'Mitchell', 29, 'Male', 8, 'Healthy', 46),
('Madeline', 'Perez', 24, 'Female', 4, 'Healthy', 47),
('Sebastian', 'Taylor', 31, 'Male', 6, 'Injured', 48),
('Nora', 'Wilson', 20, 'Female', 1, 'Healthy', 49),
('George', 'Moore', 23, 'Male', 3, 'Healthy', 50)
;

-- Insert Data for Tbl_Player_Sports
INSERT INTO Tbl_Player_Sports (Player_ID, Sports_ID) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20),
(21, 21), (22, 22), (23, 23), (24, 24), (25, 25),
(26, 26), (27, 27), (28, 28), (29, 29), (30, 30),
(31, 31), (32, 32), (33, 33), (34, 34), (35, 35),
(36, 36), (37, 37), (38, 38), (39, 39), (40, 40),
(41, 41), (42, 42), (43, 43), (44, 44), (45, 45),
(46, 46), (47, 47), (48, 48), (49, 49), (50, 50),
(51, 1), (52, 2), (53, 3), (54, 4), (55, 5),
(56, 6), (57, 7), (58, 8), (59, 9), (60, 10);

-- Insert Data for Tbl_Coach_Type
INSERT INTO Tbl_Coach_Type (Coach_Type_Name) VALUES
('Head Coach'), ('Assistant Coach'), ('Goalkeeper Coach'), ('Fitness Coach'), ('Technical Coach'),
('Tactical Coach'), ('Mental Coach'), ('Defensive Coach'), ('Offensive Coach'), ('Strength Coach'),
('Conditioning Coach'), ('Youth Coach'), ('Academy Coach'), ('Scout'), ('Development Coach'),
('Team Manager'), ('Speed Coach'), ('Nutrition Coach'), ('Skills Coach'), ('Team Captain'),
('Reserve Coach'), ('Position Coach'), ('Trainer'), ('Performance Coach'), ('Recovery Coach'),
('Football Coach'), ('Basketball Coach'), ('Cricket Coach'), ('Tennis Coach'), ('Baseball Coach'),
('Rugby Coach'), ('Hockey Coach'), ('Golf Coach'), ('Badminton Coach'), ('Boxing Coach'),
('Swimming Coach'), ('Cycling Coach'), ('Table Tennis Coach'), ('Athletics Coach'), ('Netball Coach'),
('Volleyball Coach'), ('Squash Coach'), ('Fencing Coach'), ('Handball Coach'), ('Wrestling Coach');

INSERT INTO Tbl_Coaches (First_Name, Last_Name, Experience, Coach_Type_ID) VALUES
('John', 'Doe', 5, 1), 
('Jane', 'Smith', 3, 2),
('Michael', 'Johnson', 7, 3),
('Emily', 'Davis', 2, 4),
('Chris', 'Brown', 8, 5),
('Olivia', 'Martinez', 4, 6),
('James', 'Wilson', 6, 1),
('Sophia', 'Taylor', 3, 2),
('Benjamin', 'Moore', 10, 3),
('Emma', 'Jackson', 1, 4),
('Liam', 'Thompson', 9, 5),
('Ava', 'White', 4, 6),
('William', 'Harris', 5, 1),
('Isabella', 'Clark', 2, 2),
('Ethan', 'Lewis', 8, 3),
('Mia', 'Roberts', 6, 4),
('Alexander', 'Walker', 7, 5),
('Charlotte', 'Hall', 3, 6),
('Henry', 'Allen', 9, 1),
('Amelia', 'Young', 2, 2),
('Jack', 'King', 10, 3),
('Ella', 'Scott', 1, 4),
('Noah', 'Adams', 6, 5),
('Madison', 'Baker', 4, 6),
('Lucas', 'Gonzalez', 7, 1),
('Harper', 'Nelson', 8, 2),
('Oliver', 'Carter', 3, 3),
('Leah', 'Mitchell', 5, 4),
('Daniel', 'Perez', 2, 5),
('Zoe', 'Robinson', 1, 6),
('Matthew', 'Sanchez', 9, 1),
('Aiden', 'Miller', 6, 2),
('Scarlett', 'Davis', 4, 3),
('Sebastian', 'Martinez', 3, 4),
('Victoria', 'Bennett', 7, 5),
('Grayson', 'Perez', 8, 6),
('Chloe', 'Murphy', 1, 1),
('Michael', 'King', 2, 2),
('Madeline', 'Wright', 10, 3),
('Eleanor', 'Garcia', 5, 4),
('Lucas', 'Scott', 4, 5),
('Lily', 'Ramirez', 6, 6),
('Joshua', 'Morris', 8, 1),
('Jameson', 'Watson', 3, 2),
('Caroline', 'Gray', 7, 3),
('Oliver', 'Bennett', 9, 4),
('Jack', 'Hernandez', 2, 5),
('Grace', 'Lopez', 10, 6),
('Daniel', 'Hill', 5, 1),
('Sophie', 'Gonzalez', 4, 2),
('Jacob', 'Parker', 6, 3);

INSERT INTO Tbl_Coach_Sports (Coach_ID, Sports_ID) VALUES
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5), 
(6, 6), 
(7, 7), 
(8, 8), 
(9, 9), 
(10, 10);

INSERT INTO Tbl_Trainings (Coach_ID, Sports_ID, Training_Date, Start_Time, End_Time)
VALUES
(1, 1, '2025-03-28', '10:00:00', '11:00:00'),
(2, 2, '2025-03-29', '12:00:00', '13:00:00'),
(1, 3, '2025-03-30', '09:00:00', '10:00:00'),
(2, 4, '2025-03-31', '14:00:00', '15:00:00'),
(1, 5, '2025-04-01', '16:00:00', '17:00:00'),
(2, 6, '2025-04-02', '10:30:00', '11:30:00'),
(1, 7, '2025-04-03', '12:00:00', '13:00:00'),
(2, 8, '2025-04-04', '13:30:00', '14:30:00'),
(1, 9, '2025-04-05', '15:00:00', '16:00:00'),
(2, 10, '2025-04-06', '11:00:00', '12:00:00'),
(1, 11, '2025-04-07', '09:00:00', '10:00:00'),
(2, 12, '2025-04-08', '16:00:00', '17:00:00'),
(1, 13, '2025-04-09', '14:30:00', '15:30:00'),
(2, 14, '2025-04-10', '11:30:00', '12:30:00'),
(1, 15, '2025-04-11', '13:00:00', '14:00:00'),
(2, 16, '2025-04-12', '12:00:00', '13:00:00'),
(1, 17, '2025-04-13', '10:30:00', '11:30:00'),
(2, 18, '2025-04-14', '09:00:00', '10:00:00'),
(1, 19, '2025-04-15', '14:00:00', '15:00:00'),
(2, 20, '2025-04-16', '16:30:00', '17:30:00'),
(1, 21, '2025-04-17', '15:00:00', '16:00:00'),
(2, 22, '2025-04-18', '14:00:00', '15:00:00'),
(1, 23, '2025-04-19', '13:00:00', '14:00:00'),
(2, 24, '2025-04-20', '10:00:00', '11:00:00'),
(1, 25, '2025-04-21', '09:00:00', '10:00:00');

INSERT INTO Tbl_Player_Trainings (Player_ID, Trainings_ID)
VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20),
(21, 21), (22, 22), (23, 23), (24, 24), (25, 25),
(26, 26), (27, 27), (28, 28), (29, 29), (30, 30),
(31, 31), (32, 32), (33, 33), (34, 34), (35, 35),
(36, 36), (37, 37), (38, 38), (39, 39), (40, 40),
(41, 41), (42, 42), (43, 43), (44, 44), (45, 45),
(46, 46), (47, 47), (48, 48), (49, 49), (50, 50);

INSERT INTO Tbl_Coach_Type (Coach_Type_Name) 
VALUES 
    ('Head Coach'),
    ('Assistant Coach'),
    ('Fitness Coach'),
    ('Goalkeeping Coach'),
    ('Defensive Coach'),
    ('Offensive Coach'),
    ('Strength and Conditioning Coach'),
    ('Technical Coach'),
    ('Tactical Coach'),
    ('Mental Coach'),
    ('Youth Development Coach'),
    ('Skill Development Coach'),
    ('Specialist Coach'),
    ('Team Manager'),
    ('Physiotherapist Coach'),
    ('Sports Psychologist'),
    ('Nutritionist Coach'),
    ('Club Coach'),
    ('Academy Coach'),
    ('Player Development Coach'),
    ('Match Analyst Coach'),
    ('Referee Coach'),
    ('Reserve Team Coach'),
    ('First Team Coach'),
    ('Youth Team Coach'),
    ('Fitness Trainer'),
    ('Sport Rehabilitation Coach'),
    ('Leadership Coach'),
    ('Motivational Coach'),
    ('Tactical Analyst Coach'),
    ('Team Captain Coach'),
    ('Mental Skills Coach'),
    ('Technical Director Coach'),
    ('Assistant Manager Coach'),
    ('Director of Football'),
    ('Performance Coach'),
    ('Strength Coach'),
    ('Shooting Coach'),
    ('Passing Coach'),
    ('Dribbling Coach'),
    ('Defending Coach'),
    ('Attacking Coach'),
    ('Game Preparation Coach'),
    ('Preseason Coach'),
    ('Postseason Coach'),
    ('Advanced Skills Coach'),
    ('Resilience Coach'),
    ('Injury Prevention Coach'),
    ('Speed Coach');

 INSERT INTO Tbl_Player_Sports (Player_ID, Sports_ID)
VALUES 
(1, 1),
(2, 2),
(3, 1),
(3, 3),
(1, 2),
(2, 1),
(3, 2),
(1, 3),
(2, 3),
(3, 1),
(1, 1),
(2, 2),
(3, 3),
(1, 2),
(2, 1),
(3, 2),
(1, 3),
(2, 3),
(3, 1),
(1, 1),
(2, 2),
(3, 3),
(1, 2),
(2, 1),
(3, 2),
(1, 3),
(2, 3),
(3, 1),
(1, 1),
(2, 2),
(3, 3),
(1, 2),
(2, 1),
(3, 2),
(1, 3),
(2, 3),
(3, 1),
(1, 1),
(2, 2),
(3, 3),
(1, 2),
(2, 1),
(3, 2),
(1, 3),
(2, 3),
(3, 1);

INSERT INTO Tbl_Sports (Sports_Name) VALUES
('Football'),
('Basketball'),
('Cricket'),
('Tennis'),
('Rugby');

-- Insert data into Tbl_Players
INSERT INTO Tbl_Players (Sports_ID, First_Name, Last_Name, Age, Gender, Experience, Injury_Status) VALUES
(1, 'Jack', 'Robinson', 20, 'Male', 2, 'Healthy'),
(2, 'Sophia', 'Williams', 22, 'Female', 3, 'Injured'),
(3, 'Liam', 'Harris', 25, 'Male', 4, 'Healthy'),
(4, 'Olivia', 'Martinez', 18, 'Female', 1, 'Healthy');

-- Insert data into Tbl_Player_Sports
INSERT INTO Tbl_Player_Sports (Player_ID, Sports_ID) VALUES
(1, 1),  -- Player 1 plays Football
(1, 2),  -- Player 1 also plays Basketball
(2, 3),  -- Player 2 plays Cricket
(3, 4),  -- Player 3 plays Tennis
(4, 5);  -- Player 4 plays Rugby

-- Insert data into Tbl_Coach_Type
INSERT INTO Tbl_Coach_Type (Coach_Type_Name) VALUES
('Head Coach'),
('Assistant Coach'),
('Goalkeeper Coach'),
('Fitness Coach');

-- Insert data into Tbl_Coaches
INSERT INTO Tbl_Coaches (First_Name, Last_Name, Experience, Coach_Type_ID) VALUES
('John', 'Doe', 10, 1),  -- Head Coach, 10 years of experience
('Jane', 'Smith', 5, 2),  -- Assistant Coach, 5 years of experience
('Mike', 'Johnson', 8, 3),  -- Goalkeeper Coach, 8 years of experience
('Emma', 'Brown', 3, 4);  -- Fitness Coach, 3 years of experience

-- Insert data into Tbl_Coach_Sports
INSERT INTO Tbl_Coach_Sports (Coach_ID, Sports_ID) VALUES
(1, 1),  -- Coach 1 coaches Football
(2, 2),  -- Coach 2 coaches Basketball
(3, 3),  -- Coach 3 coaches Cricket
(4, 4);  -- Coach 4 coaches Tennis

-- Insert data into Tbl_Trainings
INSERT INTO Tbl_Trainings (Coach_ID, Sports_ID, Training_Date, Start_Time, End_Time) VALUES
(1, 1, '2025-04-01', '09:00', '10:30'),  -- Football training by Coach 1
(2, 2, '2025-04-02', '10:00', '11:30'),  -- Basketball training by Coach 2
(3, 3, '2025-04-03', '11:00', '12:30'),  -- Cricket training by Coach 3
(4, 4, '2025-04-04', '08:30', '10:00');  -- Tennis training by Coach 4

-- Insert data into Tbl_Player_Trainings
INSERT INTO Tbl_Player_Trainings (Player_ID, Trainings_ID) VALUES
(1, 1),  -- Player 1 attends Football training
(2, 2),  -- Player 2 attends Basketball training
(3, 3),  -- Player 3 attends Cricket training
(4, 4);  -- Player 4 attends Tennis training