--Question 1.Define the stored procedure with a parameter for DepartmentID.
-- QUestion 2.AND Write the SQL query to count the number of employees in the specified department

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        @DepartmentID As DeptID,COUNT(*) AS TotalEmployees
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO

--Question 3.Save the stored procedure by executing the Stored procedure content.
EXECUTE sp_GetEmployeeCountByDepartment 2;
Select * from Employees;