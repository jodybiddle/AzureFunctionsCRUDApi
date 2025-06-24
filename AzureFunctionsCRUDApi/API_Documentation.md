# API Documentation

This document describes all available API endpoints for the AzureFunctionsCRUDApi project. All endpoints are HTTP-triggered Azure Functions.
The Endpoints are all publicly accessible and do not require authentication.
Endpoint https://azurefunctionscrudapi.azurewebsites.net
---

## Employee APIs

### Get All Employees
- **Method:** GET
- **Route:** /api/GetEmployees
- **Description:** Returns a list of all employees ordered by name.
- **Response:** `200 OK` – Array of Employee objects

### Get Employee by ID
- **Method:** GET
- **Route:** /api/GetEmployee/{id}
- **Description:** Returns a single employee by ID.
- **Response:** 
  - `200 OK` – Employee object
  - `404 Not Found` if employee doesn't exist

### Create Employee
- **Method:** POST
- **Route:** /api/CreateEmployee
- **Description:** Creates a new employee.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "salary": "number",
  "skill": "string",
- "comment": "string","
  }- **Response:** `200 OK` – Created employee ID

### Update Employee
- **Method:** PUT
- **Route:** /api/UpdateEmployee
- **Description:** Updates an existing employee.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "salary": "number",
  "skill": "string",
- "comment": "string","
  }- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if employee doesn't exist

### Delete Employee
- **Method:** DELETE
- **Route:** /api/DeleteEmployee/{id}
- **Description:** Deletes an employee by ID.
- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if employee doesn't exist

---

## Job APIs

### Get All Jobs
- **Method:** GET
- **Route:** /api/GetJobs
- **Description:** Returns a list of all jobs ordered by name.
- **Response:** `200 OK` – Array of Job objects

### Get Job by ID
- **Method:** GET
- **Route:** /api/GetJob/{id}
- **Description:** Returns a single job by ID.
- **Response:** 
  - `200 OK` – Job object
  - `404 Not Found` if job doesn't exist

### Create Job
- **Method:** POST
- **Route:** /api/CreateJob
- **Description:** Creates a new job.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "budget": "number",
  "comment": "string"
  }- **Response:** `200 OK` – Created job ID

### Update Job
- **Method:** PUT
- **Route:** /api/UpdateJob
- **Description:** Updates an existing job.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "budget": "number",
  "comment": "string"
  }- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if job doesn't exist

### Delete Job
- **Method:** DELETE
- **Route:** /api/DeleteJob/{id}
- **Description:** Deletes a job by ID.
- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if job doesn't exist

---

## EmployeeJob APIs

### Get All EmployeeJobs
- **Method:** GET
- **Route:** /api/GetEmployeeJobs
- **Description:** Returns a list of all employee-job assignments.
- **Response:** `200 OK` – Array of EmployeeJob objects

### Get EmployeeJob by ID
- **Method:** GET
- **Route:** /api/GetEmployeeJob/{id}
- **Description:** Returns a single employee-job assignment by ID.
- **Response:** 
  - `200 OK` – EmployeeJob object
  - `404 Not Found` if assignment doesn't exist

### Create EmployeeJob
- **Method:** POST
- **Route:** /api/CreateEmployeeJob
- **Description:** Assigns an employee to a job.
- **Request Body:**{
  "id": "string",
  "employeeId": "string",
  "jobId": "string",
  }- **Response:** `200 OK` – Created EmployeeJob ID

### Update EmployeeJob
- **Method:** PUT
- **Route:** /api/UpdateEmployeeJob
- **Description:** Updates an employee-job assignment.
- **Request Body:**{
  "id": "string",
  "employeeId": "string",
  "jobId": "string",
  }- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if assignment doesn't exist

### Delete EmployeeJob
- **Method:** DELETE
- **Route:** /api/DeleteEmployeeJob/{id}
- **Description:** Deletes an employee-job assignment by ID.
- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if assignment doesn't exist

### Get Employees With JobId
- **Method:** GET
- **Route:** /api/GetEmployeesWithJobId/{Id}
- **Description:** Returns all employees assigned to a specific job.
- **Response:** `200 OK` – Array of Employee objects with additional fields

### Get Jobs With EmployeeId
- **Method:** GET
- **Route:** /api/GetJobsWithEmployeeId/{Id}
- **Description:** Returns all jobs assigned to a specific employee.
- **Response:** `200 OK` – Array of Job objects

---

## Product APIs

### Get All Products
- **Method:** GET
- **Route:** /api/GetProducts
- **Description:** Returns a list of all products.
- **Response:** `200 OK` – Array of Product objects

### Get Product by ID
- **Method:** GET
- **Route:** /api/GetProduct/{id}
- **Description:** Returns a single product by ID.
- **Response:** 
  - `200 OK` – Product object
  - `404 Not Found` if product doesn't exist

### Create Product
- **Method:** POST
- **Route:** /api/CreateProduct
- **Description:** Creates a new product.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "category": "string",
  "price": "number"
  }- **Response:** `200 OK` – Created product ID

### Update Product
- **Method:** PUT
- **Route:** /api/UpdateProduct
- **Description:** Updates an existing product.
- **Request Body:**{
  "id": "string",
  "name": "string",
  "category": "string",
  "price": "number"
  }- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if product doesn't exist

### Delete Product
- **Method:** DELETE
- **Route:** /api/DeleteProduct/{id}
- **Description:** Deletes a product by ID.
- **Response:** 
  - `204 No Content` if successful
  - `404 Not Found` if product doesn't exist
