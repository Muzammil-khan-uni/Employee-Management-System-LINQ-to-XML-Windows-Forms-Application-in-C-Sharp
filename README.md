# Employee Management System LINQ to XML (Windows Forms Application in C#)

1.	LOAD XML

![image alt](https://github.com/Muzammil-khan-uni/Employee-Management-System-LINQ-to-XML--Windows-Forms-Application-in-C--/blob/main/Output%20SS/LOAD%20XML.png)

2.	ADD EMPLOYEE

![image alt](https://github.com/Muzammil-khan-uni/Employee-Management-System-LINQ-to-XML--Windows-Forms-Application-in-C--/blob/main/Output%20SS/ADD%20EMPLOYEE.png)

3.	UPDATE EMPLOYEE

![image alt](https://github.com/Muzammil-khan-uni/Employee-Management-System-LINQ-to-XML--Windows-Forms-Application-in-C--/blob/main/Output%20SS/UPDATE%20EMPLOYEE.png)

4.	DELETE EMPLOYEE

![image alt](https://github.com/Muzammil-khan-uni/Employee-Management-System-LINQ-to-XML--Windows-Forms-Application-in-C--/blob/main/Output%20SS/DELETE%20EMPLOYEE.png) 

5.	SAVE XML

 ![image alt](https://github.com/Muzammil-khan-uni/Employee-Management-System-LINQ-to-XML--Windows-Forms-Application-in-C--/blob/main/Output%20SS/SAVE%20XML.png)

This project is a Windows Forms Application developed in C# (.NET Framework) that demonstrates how to perform CRUD operations (Create, Read, Update, Delete) on an XML file using LINQ to XML. It is designed to manage employee records in a simple and user-friendly way, using an XML file (employees.xml) as the storage medium instead of a traditional database.

🎯 Project Objectives:

To practice and demonstrate the use of LINQ to XML for data manipulation.

To build a simple and lightweight employee management system.

To develop an interactive and functional GUI using Windows Forms.

To store, retrieve, update, and delete data persistently using an XML file.

⚙️ Key Functionalities:

1. Load XML File:

On clicking the “Load XML” button, the application attempts to load the employees.xml file.

If the file does not exist, it automatically creates a new one with a root <Employees> element.

2. Display Employees:

The employees are fetched using a LINQ query from the XML file and displayed in a DataGridView.

The fields include: ID, Name, Age, Salary, Designation, and Company.

3. Add New Employee:

Users can input new employee data in textboxes and click “Add” to insert a new <Employee> element into the XML file.

The UI is updated automatically to reflect the new record.

4. Update Existing Employee:

Users can select a record from the DataGridView to populate the input fields.

After editing the fields, clicking “Update” will modify the corresponding employee data in the XML file.

5. Delete Employee:

Users can delete an employee by providing their ID and clicking the “Delete” button.

The employee node is removed from the XML, and the grid is updated.

6. Save XML:

The “Save XML” button explicitly saves the current state of the XML file to disk.

7. Clear Inputs:

The “Clear” button clears all input fields for ease of use.

🗂️ Technologies Used:

| Technology             | Purpose                                |
| ---------------------- | -------------------------------------- |
| **C# (Windows Forms)** | Building the GUI and application logic |
| **LINQ to XML**        | XML file querying and manipulation     |
| **XML**                | Data storage format                    |
| **Visual Studio**      | IDE for development                    |

🧠 What You Will Learn from This Project:

How to read/write and manipulate XML using LINQ in C#.

How to build a responsive GUI with Windows Forms.

Best practices for data validation, exception handling, and user interaction.

Structuring and working with data in a non-database (XML-based) system.

✅ Advantages of Your Project:

No database required – everything is stored in an XML file.

Easy to understand for beginners learning file handling, LINQ, and C# UI development.

Great introduction to CRUD operations in a .NET environment.


