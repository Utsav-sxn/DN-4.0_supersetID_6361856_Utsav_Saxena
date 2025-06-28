--Question 1. - Define the stored procedure with a parameter for DepartmentID

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.DepartmentID,
        e.Salary,
        e.JoinDate
    FROM 
        Employees e
    WHERE 
        e.DepartmentID = @DepartmentID;
END;



--Question 2. - Write the SQL query to select employee details based on the DepartmentID

Exec sp_GetEmployeesByDepartment @DepartmentID =2;


/*
--Question 3. - . Create a stored procedure named `sp_InsertEmployee` with the following code:
CREATE PROCEDURE sp_InsertEmployee
 @FirstName VARCHAR(50),
 @LastName VARCHAR(50),
 @DepartmentID INT,
 @Salary DECIMAL(10,2),
 @JoinDate DATE
AS
BEGIN
 INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
 VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
*/

CREATE PROCEDURE sp_InsertEmployee
 @EmployeeID INT,
 @FirstName VARCHAR(50),
 @LastName VARCHAR(50),
 @DepartmentID INT,
 @Salary DECIMAL(10,2),
 @JoinDate DATE
AS
BEGIN
 INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
 VALUES (@EmployeeID,@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;


Execute sp_InsertEmployee 5,Utsav,Saxena,2,6361856,'2025-06-28'; 






/*
TABLE CREATION QUERIES

CREATE TABLE Departments (
 DepartmentID INT PRIMARY KEY,
 DepartmentName VARCHAR(100)
);


CREATE TABLE Employees (
 EmployeeID INT PRIMARY KEY,
 FirstName VARCHAR(50),
 LastName VARCHAR(50),
 DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
 Salary DECIMAL(10,2),
 JoinDate DATE
);


INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');



INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, 
JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');
*/
