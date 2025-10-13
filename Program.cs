// See https://aka.ms/new-console-template for more information
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;


namespace SCADA.Domain
{
    // Formula class to create formula objects:
     public class Formula
     {
      // Formula Table parameters
        private string formula_Code;
        private string Concrete_Grade;
        private float Cement_Portion;
        private float Sand_Portion;
        private float Gravel_Portion;
        private float Water_Portion;
        private float ADX1_Portion;
        private float ADX2_Portion;
        private float Ice_Portion;
        private float Color_Portion;                                    
        private DateTime Creation_Date; 
      //----------------------------------
      // Create Formula:
       public Formula()
        {
            
        }
       public Formula(string formula_Code, string concrete_Grade, float Cement_Portion, float Sand_Portion, float Gravel_Portion, float Water_Portion, float ADX1_Portion, float ADX2_Portion,  float Ice_Portion, float Color_Portion)
       {
            this.formula_Code = formula_Code;
            this.Concrete_Grade = concrete_Grade;
            this.Cement_Portion = Cement_Portion;
            this.Sand_Portion = Sand_Portion;
            this.Gravel_Portion = Gravel_Portion;
            this.Water_Portion = Water_Portion;
            this.ADX1_Portion = ADX1_Portion;
            this.ADX2_Portion = ADX2_Portion;
            this.Ice_Portion = Ice_Portion;
            Creation_Date = DateTime.Now;
       }
      //--------------------------------
      // Set Formula Parameters:
        public void setFormulaCode(string formula_code)
        {
            this.formula_Code = formula_code;
        }
        public void setconcrete_Grade(string Concrete_Grade)
        {
            this.Concrete_Grade = Concrete_Grade;
        }
        public void setCementPortion(float  cement_portion)
        {
            this.Cement_Portion = cement_portion;
        }
        public void setSandPortion(float sand_portion)
        {
            this.Sand_Portion = sand_portion;
        }
        public void setGravelPortion(float gravel_portion)
        {
            this.Gravel_Portion = gravel_portion;
        }
        public void setWaterPortion(float water_portion)
        {
            this.Water_Portion = water_portion;
        }
        public void setADX1Portion(float adx1_portion)
        {
            this.ADX1_Portion = adx1_portion;
        }
        public void setADX2Portion(float adx2_portion)
        {
            this.ADX2_Portion = adx2_portion;
        }
        public void setIcePortion(float Ice_Portion)
        {
            this.Ice_Portion = Ice_Portion;
        }
        public void setColorPortion(float Color_portion)
        {
            this.Color_Portion = Color_portion;
        }
      //-------------------------------------------------
      // return Formula Parameters:
        public string getFormulaCode()
        {
            return formula_Code;
        }
        public string getConcrete_Grade()
        {
            return Concrete_Grade;
        }
        public float getCementPortion()
        {
            return Cement_Portion; 
        }
        public float getSandtPortion()
        {
            return Sand_Portion;
        }
        public float getGravelPortion()
        {
            return Gravel_Portion;
        }
        public float getWaterPortion()
        {
            return Water_Portion;
        }
        public float getADX1Portion()
        {
            return ADX1_Portion;
        }
        public float getADX2Portion()
        {
            return ADX2_Portion;
        }
        public float getIcePortion()
        {
            return Ice_Portion;
        }
        public float getColorPortion()
        {
            return Color_Portion;
        }
        public DateTime getCreation_DatePortion()
        {
            return Creation_Date;
        }
      //-------------------------------------------------
    }
    //--------------------------------------------------
    // Client class to create client object:
    public class Client
    {
     // CLient parameters:
        private int ID; // Auto_Incremented
        private string Name;
        private int Phone_No;
        private string Email;
        private string Address;
        private string Company;
     //------------------------------
     // create Client object: 
       public  Client()
       {
       }
       public Client(string Name, int Phone_No, string Email, string Address, string company)
       {
            this.Name = Name;
            this.Phone_No = Phone_No;
            this.Email = Email;
            this.Address = Address;
            this.Company = company;
        }
     //--------------------------------------
     // Set & get Client parameters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setPhone_No(int phone_no)
        {
            this.Phone_No = phone_no;
        }
        public void setEmail(string email)
        {
            this.Email = email;
        }
        public void setAddress(string address)
        {
            this.Address = address;
        }
        public void setCompany(string company)
        {
            this.Company = company;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public int getPhone_No()
        {
            return Phone_No;
        }
        public string getEmail()
        {
            return Email;
        }
        public string getAddress()
        {
            return Address;
        }
        public string getCompany()
        {
            return Company;
        }
        //-----------------------------------------
    }
    //--------------------------------------------
    // Driver Class:
    public class Driver
    {
        // Driver data fields:
        private int ID; // Auto_Incremented
        private string Name;
        private int Phone_No;
        private string Address;
        private float salary;
        private int Age;
        private string Martial_State;
        private DateOnly Issue_Date;
        private DateOnly Expiry_Date;
        //---------------------
        // Create Driver object:
       public Driver()
       { 
       }
       public  Driver(string name, int phone_no, string address, float salary, int age, string martial_state, DateOnly issue_date, DateOnly expiry_date)
       {
            this.Name = name;
            this.Phone_No = phone_no;
            this.Address = address;
            this.salary = salary;
            this.Age = age;
            this.Martial_State = martial_state;
            this.Issue_Date = issue_date;
            this.Expiry_Date = expiry_date;
       }
        //-----------------------------
        // set & get Driver Parameters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setPhone_No(int phone_no)
        {
            this.Phone_No = phone_no;
        }
        public void setAddress(string address)
        {
            this.Address = address;
        }
        public void setSalary(float salary)
        {
            this.salary = salary;
        }
        public void setAge(int age)
        {
            this.Age = age;
        }
        public void setMartial_State(string martial_state)
        {
            this.Martial_State = martial_state;
        }
        public void setIssue_Date(DateOnly issue_date)
        {
            this.Issue_Date = issue_date;
        }
        public void setExpiry_Date(DateOnly expiry_date)
        {
            this.Expiry_Date = expiry_date;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public int getPhone_No()
        {
            return Phone_No;
        }
        public string getAddress()
        {
            return Address;
        }
        public float getSalary()
        {
            return salary;
        }
        public int getAge()
        {
            return Age;
        }
        public string getMartial_State()
        {
            return Martial_State;
        }
        public DateOnly getIssue_Date()
        {
            return Issue_Date;
        }
        public DateOnly getExpiry_Date()
        {
            return Expiry_Date;
        }
        //----------------------------------
    }
    //-------------------------------------------
    // Truck Class:
    public class Truck
    {
        // Truck data fields
        private int Truck_ID; // Auto_Incremented
        private string Truck_Model;
        private string Truck_Plate;
        private float Truck_Capacity;
        private DateOnly License_Issue_Date;
        private DateOnly License_Expiry_Date;
        private int Driver_ID; // foreign key
        //------------------------------------
        // Create Truck: 
       public Truck()
       {
       }
       public Truck(string truck_Model, string truck_Plate, float truck_Capacity, DateOnly license_Issue_Date, DateOnly license_Expiry_Date, int driver_ID)
       {
            this.Truck_Model = truck_Model;
            this.Truck_Plate = truck_Plate;
            this.Truck_Capacity = truck_Capacity;
            this.License_Issue_Date = license_Issue_Date;
            this.License_Expiry_Date = license_Expiry_Date;
            this.Driver_ID = driver_ID;
        }
        //------------------------------------
        // set & get truck parameters:
        public void setTruck_Model(string truck_model)
        {
            this.Truck_Model = truck_model;
        }
        public void setTruck_Plate(string truck_plate)
        {
            this.Truck_Plate = truck_plate;
        }
        public void setTruck_Capacity(float truck_capacity)
        {
            this.Truck_Capacity = truck_capacity;
        }
        public void setLicense_Issue_Date(DateOnly license_issue_date)
        {
            this.License_Issue_Date = license_issue_date;
        }
        public void setLicense_Expiry_Date(DateOnly license_expiry_date)
        {
            this.License_Expiry_Date = license_expiry_date;
        }
        public void setDriver_ID(int driver_id)
        {
            this.Driver_ID = driver_id;
        }
        public int getTruck_ID()
        {
            return Truck_ID;
        }
        public string getTruck_Model()
        {
            return Truck_Model;
        }
        public string getTruck_Plate()
        {
            return Truck_Plate;
        }
        public float getTruck_Capacity()
        {
            return Truck_Capacity;
        }
        public DateOnly getLicense_Issue_Date()
        {
            return License_Issue_Date;
        }
        public DateOnly getLicense_Expiry_Date()
        {
            return License_Expiry_Date;
        }
        public int getDriver_ID()
        {
            return Driver_ID;
        }
        //---------------------------------------------
    }
    //------------------------------------------------------
    // Componenets Class:
    public class Components
    {
        // Componenets data fields:
        private int ID; // Auto_Incremented
        private string Name;
        private float Cost;
        private string Type;
        private float Capacity;
        private string state;
        private DateOnly purchasing_Date;
        private int Supplier_Id; // foreign key
        private int Report_id; // foreign key
        //----------------------------------
        // Create Componenets object:
       public Components()
       {
       }
       public Components(string name, float cost, string type, float capacity, string state, DateOnly purchasing_date, int supplier_id, int report_id)
       {
            this.Name = name;
            this.Cost = cost;
            this.Type = type;
            this.Capacity = capacity;
            this.state = state;
            this.purchasing_Date = purchasing_date;
            this.Supplier_Id = supplier_id;
            this.Report_id = report_id;
       }
        //---------------------------------------
        // set & get Components Parameters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setCost(float cost)
        {
            this.Cost = cost;
        }
        public void setType(string type)
        {
            this.Type = type;
        }
        public void setCapacity(float capacity)
        {
            this.Capacity = capacity;
        }
        public void setState(string state)
        {
            this.state = state;
        }
        public void setPurchasing_Date(DateOnly purchasing_date)
        {
            this.purchasing_Date = purchasing_date;
        }
        public void setSupplier_ID(int supplier_id)
        {
            this.Supplier_Id = supplier_id;
        }
        public void setReport_ID(int report_id)
        {
            this.Report_id = report_id;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public float getCost()
        {
            return Cost;
        }
        public string getType()
        {
            return Type;
        }
        public float getCapacity()
        {
            return Capacity;
        }
        public string getState()
        {
            return state;
        }
        public DateOnly getPurchasing_Date()
        {
            return purchasing_Date;
        }
        public int getSupplier_Id()
        {
            return Supplier_Id;
        }
        public int getReport_id()
        {
            return Report_id;
        }
        //-----------------------------------------------
    }
    //----------------------------------------------------
    // Supplier Class:
    public class Supplier
    { 
        // Supplier data fields:
        private int ID; // Auto_Incremented
        private string Name;
        private string Location;
        private int Phone_No;
        private string Email;
        private string State;
        private DateOnly Contract_Date;
        private int Report_id; // foreign key
        //--------------------------------------
        // Create Supplier Object:
       public Supplier()
       {
       }
       public Supplier(string name, string location, int phone_no, string email, string state, DateOnly contract_date, int report_id)
       {
            this.Name = name;
            this.Location = location;
            this.Phone_No = phone_no;
            this.Email = email;
            this.State = state;
            this.Contract_Date = contract_date;
            this.Report_id = report_id;
       }
        //-------------------------------
        // Setters & Getters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setLocation(string location)
        {
            this.Location = location;
        }
        public void setPhone_No(int phone_no)
        {
            this.Phone_No = phone_no;
        }
        public void setEmail(string email)
        {
            this.Email = email;
        }
        public void setState(string state)
        {
            this.State = state;
        }
        public void setContract_Date(DateOnly contract_date)
        {
            this.Contract_Date = contract_date;
        }
        public void setReport_ID(int report_id)
        {
            this.Report_id = report_id;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public string getLocation()
        {
            return Location;
        }
        public int getPhone_No()
        {
            return Phone_No;
        }
        public string getEmail()
        {
            return Email;
        }
        public string getState()
        {
            return State;
        }
        public DateOnly getContract_Date()
        {
            return Contract_Date;
        }
        public int getReport_id()
        {
            return Report_id;
        }
        //-----------------------------------------
    }
    //-------------------------------------------------------
    // Employee Class:
    public class Employee
    {
        // Employee data fields:
        private int ID; // Auto_Incremented
        private string Name;
        private int Phone_No;
        private int Age;
        private string Address;
        private float salary;
        private string Work_Email;
        private string Martial_State;
        private string Job_Title;
        private float Bonus;
        private float Total_Salary;
        private string Status;
        //-----------------------------
        // Create Employee Object:
       public Employee()
       {
       }
       public Employee(string name, int phone_no, int age, string address, float salary, string work_email, string martial_state, string job_title, float bonus, string status)
        {
            this.Name = name;
            this.Phone_No = phone_no;
            this.Age = age;
            this.Address = address;
            this.salary = salary;
            this.Work_Email = work_email;
            this.Martial_State = martial_state;
            this.Job_Title = job_title;
            Bonus = bonus;
            Status = status;
        }
        //----------------------------------
        // Setters & Getters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setPhone_No(int phone_no)
        {
            this.Phone_No = phone_no;
        }
        public void setAge(int age)
        {
            this.Age = age;
        }
        public void setAddress(string address)
        {
            this.Address = address;
        }
        public void setSalary(float salary)
        {
            this.salary = salary;
        }
        public void setWork_Email(string work_email)
        {
            this.Work_Email = work_email;
        }
        public void setMartial_State(string martial_state)
        {
            this.Martial_State = martial_state;
        }
        public void setJob_Title(string job_title)
        {
            this.Job_Title = job_title;
        }
        public void setBonus(float bonus)
        {
            this.Bonus = bonus;
        }
        public void setStatus(string status)
        {
            this.Status = status;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public int getPhone_No()
        {
            return Phone_No;
        }
        public int getAge()
        {
            return Age;
        }
        public string getAddress()
        {
            return Address;
        }
        public float getSalary()
        {
            return salary;
        }
        public string getWork_Email()
        {
            return Work_Email;
        }
        public string getMartial_State()
        {
            return Martial_State;
        }
        public string getJob_Title()
        {
            return Job_Title;
        }
        public float getBonus()
        {
            return Bonus;
        }
        public float getTotal_Salary()
        {
            Total_Salary = salary + (Bonus*salary);
            return Total_Salary;
        }
        public string getStatus()
        {
            return Status;
        }
        //------------------------------------------
    }
    //--------------------------------------------------
    // Alarm Class:
    public class Alarms
    {
        // Alarm data fields:
        private int ID; // Auto_Incremented
        private string Name;
        private TimeOnly Occurance_Time;
        private DateOnly Occurance_Date;
        private int Report_ID; // foreign key
        //---------------------------
        // Create Alarm Object:
       public Alarms()
       {
       }
       public Alarms(string name, TimeOnly occurance_time, DateOnly occurance_date, int report_id)
       {
            this.Name = name;
            this.Occurance_Time = occurance_time;
            this.Occurance_Date = occurance_date;
            this.Report_ID = report_id;
       }
        //---------------------------------------
        // Setters & Getters:
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setOccurance_Time(TimeOnly occurance_time)
        {
            this.Occurance_Time = occurance_time;
        }
        public void setOccurance_Date(DateOnly occurance_date)
        {
            this.Occurance_Date = occurance_date;
        }
        public void setReport_ID(int report_id)
        {
            this.Report_ID = report_id;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public TimeOnly getOccurance_Time()
        {
            return Occurance_Time;
        }
        public DateOnly getOccurance_Date()
        {
            return Occurance_Date;
        }
        public int getReport_ID()
        {
            return Report_ID;
        }
        //-------------------------------------
    }
    //------------------------------------------------
    // Docket Class:
    public class DeliveryDocket
    {
        // Docket data fields:
        private int ID; // Auto_Incremented
        private int Shipment_ID; // foreign key
        private int printed_Copies;
        private string Driver_Name;
        private string Signature;
        private DateTime timestamp;
        //----------------------------------
        // Create Docket Object:
       public DeliveryDocket()
       {
       }
       public DeliveryDocket(int shipment_id, int printed_copies, string driver_name, string signature)
       {
            this.Shipment_ID = shipment_id;
            this.printed_Copies = printed_copies;
            this.Driver_Name = driver_name;
            this.Signature = signature;
            this.timestamp = DateTime.Now;
       }
        //-----------------------------------
        // Setters & Getters:
        public void setShipment_ID(int shipment_id)
        {
            this.Shipment_ID = shipment_id;
        }
        public void setPrinted_Copies(int printed_copies)
        {
            this.printed_Copies = printed_copies;
        }
        public void setDriver_Name(string driver_name)
        {
            this.Driver_Name = driver_name;
        }
        public void setSignature(string signature)
        {
            this.Signature = signature;
        }
        public void setTimestamp(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }
        public int getID()
        {
            return ID;
        }
        public int getShipment_ID()
        {
            return Shipment_ID;
        }
        public int getPrinted_Copies()
        {
            return printed_Copies;
        }
        public string getDriver_Name()
        {
            return Driver_Name;
        }
        public string getSignature()
        {
            return Signature;
        }
        public DateTime getTimestamp()
        {
            return timestamp;
        }
        //-------------------------------------
    }
    //-----------------------------------------------
    //Order Class:
    public class Order
    {
        // data fields:
        private int ID; // Auto_Incremented
        private DateTime Issue_Date;
        private float Requested_Volume;
        private DateTime Start_Time;
        private DateTime Finish_Time;
        private float Total_Quantity;
        private int Number_of_batches;
        private int Client_ID; // foreign key
        private float Rejected_Quantity;
        private float Remaining_Quantity;
        private string Order_State;
        private float Total_Price;
        //-------------------------------
        // Create Order
       public Order()
       {
       }
       public Order(DateTime issue_date, float requested_volume, DateTime start_time, DateTime finish_time, float total_quantity, int number_of_batches, int client_id, float rejected_quantity, float total_Price)
        {
            this.Issue_Date = issue_date;
            this.Requested_Volume = requested_volume;
            this.Start_Time = start_time;
            this.Finish_Time = finish_time;
            this.Total_Quantity = total_quantity;
            this.Number_of_batches = number_of_batches;
            this.Client_ID = client_id;
            this.Rejected_Quantity = rejected_quantity;
            this.Total_Price = total_Price; 
        }
        //-----------------------------------
        // Setters & Getters:
        public void setIssue_Date(DateTime issue_date)
        {
            this.Issue_Date = issue_date;
        }
        public void setRequested_Volume(float requested_volume)
        {
            this.Requested_Volume = requested_volume;
        }
        public void setStart_Time(DateTime start_time)
        {
            this.Start_Time = start_time;
        }
        public void setFinish_Time(DateTime finish_time)
        {
            this.Finish_Time = finish_time;
        }
        public void setTotal_Quantity(float total_quantity)
        {
            this.Total_Quantity = total_quantity;
        }
        public void setNumber_of_batches(int number_of_batches)
        {
            this.Number_of_batches = number_of_batches;
        }
        public void setClient_ID(int client_id)
        {
            this.Client_ID = client_id;
        }
        public void setRejected_Quantity(float rejected_quantity)
        {
            this.Rejected_Quantity = rejected_quantity;
        }
        public void setTotal_Price(float total_price)
        {
            this.Total_Price = total_price;
        }
        public int getID()
        {
            return ID;
        }
        public DateTime getIssue_Date()
        {
            return Issue_Date;
        }
        public float getRequested_Volume()
        {
            return Requested_Volume;
        }
        public DateTime getStart_Time()
        {
            return Start_Time;
        }
        public DateTime getFinish_Time()
        {
            return Finish_Time;
        }
        public float getTotal_Quantity()
        {
            return Total_Quantity;
        }
        public int getNumber_of_batches()
        {
            return Number_of_batches;
        }
        public int getClient_ID()
        {
            return Client_ID;
        }
        public float getRejected_Quantity()
        {
            return Rejected_Quantity;
        }
        public float getTotal_Price()
        {
            return Total_Price;
        }
        //---------------------------------------
    }
    //--------------------------------------------------
    // Order Lines Class:
    public class OrderLines
    {
        // data fields: 
        private int Order_Line_ID; // Auto_Incremented
        private int Destination_Id; // foreign key
        private float Requested_Quantity;
        private string Line_State;
        private DateOnly Start_Date;
        private DateOnly End_Date;
        private int Order_ID; // Foreign Key
        //-----------------
        // create Order Line Object:
        public OrderLines()
        {
        }
        public OrderLines(int destination_id, float requested_quantity, string line_state, DateOnly start_date, DateOnly end_date, int order_id)
        {
            this.Destination_Id = destination_id;
            this.Requested_Quantity = requested_quantity;
            this.Line_State = line_state;
            this.Start_Date = start_date;
            this.End_Date = end_date;
            this.Order_ID = order_id;
        }
        //--------------------------------------------
        // setters & getters:
        public void setOrder_ID(int Order_ID)
        {
            this.Order_ID = Order_ID;
        }
        public void setDestination_Id(int destination_id)
        {
            this.Destination_Id = destination_id;
        }
        public void setRequested_Quantity(float requested_quantity)
        {
            this.Requested_Quantity = requested_quantity;
        }
        public void setLine_State(string line_state)
        {
            this.Line_State = line_state;
        }
        public void setLine_Start_Date(DateOnly start_date)
        {
            this.Start_Date = start_date;
        }
        public void setLine_End_Date(DateOnly end_date)
        {
            this.End_Date = end_date;
        }
        public int getOrder_Line_ID()
        {
            return Order_Line_ID;
        }
        public int getOrder_ID()
        {
            return Order_ID;
        }
        public int getDestination_Id()
        {
            return Destination_Id;
        }
        public float getRequested_Quantity()
        {
            return Requested_Quantity;
        }
        public string getLine_State()
        {
            return Line_State;
        }
        public DateOnly getLine_Start_Date()
        {
            return Start_Date;
        }
        public DateOnly getLine_End_Date()
        {
            return End_Date;
        }
       //-----------------------------------------
    }
    //---------------------------------------------------
    // Shipments Class:
    public class Shipments
    {
        // Shipments data fields:
        private int Shipment_ID; // Auto_Incremented
        private int Truck_ID; // foreign key
        private int Product_Id; // foreign key
        private string Shipment_State;
        private float Planned_Quantity;
        private int No_of_batches_per_Shipment;
        private float Actual_Quantity;
        private DateTime Depature_Time;
        private DateTime Arrival_Time;
        private int Employee_ID; // foreign key
        private string Formula_Code; // foreign key
        private int Order_Line_ID; // Foreign Key
        //-------------------------
        // Create Shipment Object:
        public Shipments()
        {
        }
        public Shipments(int truck_id, int product_id, string state, float planned_quantity, int no_of_batches_per_shipment, float actual_quantity, DateTime depature_time, DateTime arrival_time, int employee_id, string formula_code, int order_line_id)
        {
            this.Truck_ID = truck_id;
            this.Product_Id = product_id;
            this.Shipment_State = state;
            this.Planned_Quantity = planned_quantity;
            this.No_of_batches_per_Shipment = no_of_batches_per_shipment;
            this.Actual_Quantity = actual_quantity;
            this.Depature_Time = depature_time;
            this.Arrival_Time = arrival_time;
            this.Employee_ID = employee_id;
            this.Formula_Code = formula_code;
            this.Order_Line_ID = order_line_id;
        }
        //----------------------------------
        // setters & getters:
        public void setTruck_ID(int truck_id)
        {
            this.Truck_ID = truck_id;
        }
        public void setProduct_Id(int product_id)
        {
            this.Product_Id = product_id;
        }
        public void setShipment_State(string shipment_state)
        {
            this.Shipment_State = shipment_state;
        }
        public void setPlanned_Quantity(float planned_quantity)
        {
            this.Planned_Quantity = planned_quantity;
        }
        public void setNo_of_batches_per_Shipment(int no_of_batches_per_shipment)
        {
            this.No_of_batches_per_Shipment = no_of_batches_per_shipment;
        }
        public void setActual_Quantity(float actual_quantity)
        {
            this.Actual_Quantity = actual_quantity;
        }
        public void setDepature_Time(DateTime depature_time)
        {
            this.Depature_Time = depature_time;
        }
        public void setArrival_Time(DateTime arrival_time)
        {
            this.Arrival_Time = arrival_time;
        }
        public void setEmployee_ID(int employee_id)
        {
            this.Employee_ID = employee_id;
        }
        public void setFormula_Code(string formula_code)
        {
            this.Formula_Code = formula_code;
        }
        public void setLine_ID(int order_line_id)
        {
            this.Order_Line_ID = order_line_id;
        }
        public int getShipment_ID()
        {
            return Shipment_ID;
        }
        public int getTruck_ID()
        {
            return Truck_ID;
        }
        public int getProduct_Id()
        {
            return Product_Id;
        }
        public string getShipment_State()
        {
            return Shipment_State;
        }
        public float getPlanned_Quantity()
        {
            return Planned_Quantity;
        }
        public int getNo_of_batches_per_Shipment()
        {
            return No_of_batches_per_Shipment;
        }
        public float getActual_Quantity()
        {
            return Actual_Quantity;
        }
        public DateTime getDepature_Time()
        {
            return Depature_Time;
        }
        public DateTime getArrival_Time()
        {
            return Arrival_Time;
        }
        public int getEmployee_ID()
        {
            return Employee_ID;
        }
        public string getFormula_Code()
        {
            return Formula_Code;
        }
        public int getLine_ID()
        {
            return Order_Line_ID;
        }
    }
    //----------------------------------------------------
    // Communication Class:
    public class CommunicationConfiguration
    {
        // data fields:
        private DateOnly Day_Date;
        private string Protocol;
        private TimeOnly Stablish_Time;
        private string Communication_State;
        private TimeOnly Cut_Time;
        private string Communication_Address;
        //------------------
        // Create Communication object:
       public CommunicationConfiguration()
       {
       }
       public CommunicationConfiguration(DateOnly day_date, string protocol, TimeOnly stablish_time, string communication_state, TimeOnly cut_time, string communication_address)
       {
            this.Day_Date = day_date;
            this.Protocol = protocol;
            this.Stablish_Time = stablish_time;
            this.Communication_State = communication_state;
            this.Cut_Time = cut_time;
            this.Communication_Address = communication_address;
       }
        //------------------------------
        // Setters & Getters:
        public void setDay_Date(DateOnly day_date)
        {
            this.Day_Date = day_date;
        }
        public DateOnly getDay_Date()
        {
            return Day_Date;
        }
        public void setProtocol(string protocol)
        {
            this.Protocol = protocol;
        }
        public string getProtocol()
        {
            return Protocol;
        }
        public void setStablish_Time(TimeOnly stablish_time)
        {
            this.Stablish_Time = stablish_time;
        }
        public TimeOnly getStablish_Time()
        {
            return Stablish_Time;
        }
        public void setCommunication_State(string communication_state)
        {
            this.Communication_State = communication_state;
        }
        public string getCommunication_State()
        {
            return Communication_State;
        }
        public void setCut_Time(TimeOnly cut_time)
        {
            this.Cut_Time = cut_time;
        }
        public TimeOnly getCut_Time()
        {
            return Cut_Time;
        }
        public void setCommunication_Address(string communication_address)
        {
            this.Communication_Address = communication_address;
        }
        public string getCommunication_Address()
        {
            return Communication_Address;
        }
        //------------------------------------------
    }
    //---------------------------------
    // Actuator Class:
    public class Actuator  // in Prototype: 4 motors, 2 vibrators , water pump, Water Valve, 4 pnuematic cylinders
                    // Standard: water pump, Adx1 pump , Adx2 pump , Water Valve, 10 Pneumatic cylinders, 3 vibrators, 11 Motors
    {
        // data fields:
        private int ID;
        private string Name;
        private bool State; // true for on , false for off 
        //-----------------------------
        // create actuator object:
       public Actuator()
       {
            State = false;
       }
       public Actuator(int id, string name)
       {
            this.ID = id;
            this.Name = name;
            this.State = false;
       }
        //-----------------------
        // Setters & Getters:
        public void setID(int id)
        {
            this.ID = id;
        }
        public void setName(string name)
        {
            this.Name = name;
        }
        public void setState(bool state)
        {
            this.State = state;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public bool getState()
        {
            return State;
        }
        //-----------------------------------
    }
    //--------------------------------------------
    // Sensors Class:
    public class Sensors  // prototype: wattmeter, 3 load cells, # IMU, 4 encoders
                   // standard: wattmeter, 7 load cells, pressure sensor, 11 encoders, # IMU 
    {
        // data fields:
        private int ID;
        private string Name;
        private float Reading;
        private bool state;
        private string Unit;
        //-------------------------
        // create sensor object:
       public Sensors()
       {
            state = false;
       }
       public Sensors(int id, string name, string unit)
       {
            this.ID = id;
            this.Name = name;
            this.Unit = unit;
            state = false;
       }
        //--------------------------
        // Setters & Getters:
        public void setID(int id)
        {
            this.ID = id;
        }
        public void setName(string name)
        {
            this.Name = name;
        }
        public void UpdateReading(float newReading)
        {
            this.Reading = newReading;
        }
        public void setUnit(string unit)
        {
            this.Unit = unit;
        }
        public void setSensor_State(bool state)
        {
            this.state = state;
        }
        public int getID()
        {
            return ID;
        }
        public string getName()
        {
            return Name;
        }
        public float getReading()
        {
            return Reading;
        }
        public string getUnit()
        {
            return Unit;
        }
        public bool getSensor_State()
        {
            return state;
        }
        //--------------------------------------
    }
    //--------------------------------------------------
    // Destination Class:
    public class Destination
    {
        // data fields:
        private int Destination_ID; // Auto_Incremented
        private int Client_ID; // foreign key
        private string LocationAddress;
        private TimeOnly Arrival_Time;
        private int Delivery_No;
        //-------------------------------
        // create destination object:
        public Destination()
        {
        }
        public Destination(int client_ID, string locationAddress, TimeOnly arrival_Time, int delivery_No)
        {
            Client_ID = client_ID;
            LocationAddress = locationAddress;
            Arrival_Time = arrival_Time;
            Delivery_No = delivery_No;
        }
        //----------------------------------------
        // Setters & Getters:
        public void setClient_ID(int client_id)
        {
            this.Client_ID = client_id;
        }
        public void setLocationAddress(string locationAddress)
        {
            this.LocationAddress = locationAddress;
        }
        public void setArrivalTime(TimeOnly arrival_time)
        {
            this.Arrival_Time = arrival_time;
        }
        public void setDeliveryNo(int delivery_no)
        {
            this.Delivery_No = delivery_no;
        }
        public int getDestination_ID()
        {
            return this.Destination_ID; 
        }
        public int getClient_ID()
        {
            return this.Client_ID;
        }
        public string getLocationAddress()
        {
            return this.LocationAddress;
        }
        public TimeOnly getArrival_Time()
        {
            return this.Arrival_Time;
        }
        public int getDelivery_No()
        {
            return this.Delivery_No;
        }
        //-----------------------------------------
    }
    //------------------------------------------------------
    // Weighing Modulde Class:
    public class WeighingModule
    {
        // data fields:
        private int Configuration_No; // Auto_Incremented
        private string Agg_Dosing_Mode;
        private string CEM_Dosing_Mode;
        private string Water_Dosing_Mode;
        private string ADX_Dosing_Mode;
        private string Color_Dosing_Mode;
        private string Ice_Dosing_Mode;
        private int Batch_Number;
        private int Agg_Scale_Delay;
        private int CEM_Scale_Delay;
        private int Water_Scale_Delay;
        private int ADX_Scale_Delay;
        private int Color_Scale_Delay;
        private int Ice_Scale_Delay;
        private float Agg_Preact_Value;
        private float CEM_Preact_Value;
        private float Water_Preact_Value;
        private float ADX_Preact_Value;
        private float Color_Preact_Value;
        private float Ice_Preact_Value;
        private float Weighing_Duration;
        private string Weighing_Module_State;
        private float Agg_Total_Target_Weight;
        private float CEM_Total_Target_Weight;
        private float Water_Total_Target_Weight;
        private float ADX1_Total_Target_Weight;
        private float ADX2_Total_Target_Weight;
        private float Color_Total_Target_Weight;
        private float ICE_Total_Target_Weight;
        private float Agg_Total_Actual_Weight;
        private float CEM_Total_Actual_Weight;
        private float Water_Total_Actual_Weight;
        private float ADX1_Total_Actual_Weight;
        private float ADX2_Total_Actual_Weight;
        private float Color_Total_Actual_Weight;
        private float ICE_Total_Actual_Weight;
        //--------------------------------------------
        // craete Weighing Module Object:
        public WeighingModule()
        {
        }
        public WeighingModule(string agg_Dosing_Mode, string cem_Dosing_Mode, string water_Dosing_Mode, string adx_Dosing_Mode, string color_Dosing_Mode, string ice_Dosing_Mode, int batch_Number, int agg_Scale_Delay, int cem_Scale_Delay, int water_Scale_Delay, int adx_Scale_Delay, int color_Scale_Delay, int ice_Scale_Delay, float agg_Preact_Value, float cem_Preact_Value, float water_Preact_Value, float adx_Preact_Value, float color_Preact_Value, float ice_Preact_Value, float weighing_Duration, string weighing_Module_State, float iCE_Total_Actual_Weight, float color_actual_weight, float adx2_actual_weight, float adx1_actual_weight, float water_actual_weight, float cem_actual_weight, float agg_actual_weight, float agg_target_weight, float cem_target_weight, float water_target_weight, float adx1_target_weight, float adx2_target_weight, float color_target_weight, float ice_target_weight)
        {
            this.Agg_Dosing_Mode = agg_Dosing_Mode;
            this.CEM_Dosing_Mode = cem_Dosing_Mode;
            this.Water_Dosing_Mode = water_Dosing_Mode;
            this.ADX_Dosing_Mode = adx_Dosing_Mode;
            this.Color_Dosing_Mode = color_Dosing_Mode;
            this.Ice_Dosing_Mode = ice_Dosing_Mode;
            this.Batch_Number = batch_Number;
            this.Agg_Scale_Delay = agg_Scale_Delay;
            this.CEM_Scale_Delay = cem_Scale_Delay;
            this.Water_Scale_Delay = water_Scale_Delay;
            this.ADX_Scale_Delay = adx_Scale_Delay;
            this.Color_Scale_Delay = color_Scale_Delay;
            this.Ice_Scale_Delay = ice_Scale_Delay;
            this.Agg_Preact_Value = agg_Preact_Value;
            this.CEM_Preact_Value = cem_Preact_Value;
            this.Water_Preact_Value = water_Preact_Value;
            this.ADX_Preact_Value = adx_Preact_Value;
            this.Color_Preact_Value = color_Preact_Value;
            this.Ice_Preact_Value = ice_Preact_Value;
            this.Weighing_Duration = weighing_Duration;
            this.Weighing_Module_State = weighing_Module_State;
            this.ICE_Total_Actual_Weight = iCE_Total_Actual_Weight;
            this.Color_Total_Actual_Weight = color_actual_weight;
            this.ADX2_Total_Actual_Weight = adx2_actual_weight;
            this.ADX1_Total_Actual_Weight= adx1_actual_weight;
            this.Water_Total_Actual_Weight = water_actual_weight;
            this.CEM_Total_Actual_Weight = cem_actual_weight;
            this.Agg_Total_Actual_Weight = agg_actual_weight;
            this.Agg_Total_Target_Weight = agg_target_weight;
            this.CEM_Total_Target_Weight = cem_target_weight;
            this.Water_Total_Target_Weight = water_target_weight;
            this.ADX1_Total_Target_Weight = adx1_target_weight;
            this.ADX2_Total_Target_Weight= adx2_target_weight;
            this.Color_Total_Target_Weight = color_target_weight;
            this.ICE_Total_Target_Weight = ice_target_weight;
        }
        //--------------------------------------------------
        // Setters & Getters:
        public void setAggMode(string dosing_mode)
        {
            this.Agg_Dosing_Mode = dosing_mode;
        }
        public void setCEMMode(string dosing_mode)
        {
            this.CEM_Dosing_Mode = dosing_mode;
        }
        public void setWaterMode(string dosing_Mode)
        {
            this.Water_Dosing_Mode = dosing_Mode;
        }
        public void setADXMode(string dosing_mode)
        {
            this.ADX_Dosing_Mode= dosing_mode;
        }
        public void setColorMode(string dosing_mode)
        {
            this.Color_Dosing_Mode = dosing_mode;
        }
        public void setIceMode(string dosing_mode)
        {
            this.Ice_Dosing_Mode = dosing_mode;
        }
        public void setBatchNumber(int batchNumber)
        {
            this.Batch_Number = batchNumber;
        }
        public void setAgg_Scale_Delay(int agg_scale_delay)
        {
            this.Agg_Scale_Delay = agg_scale_delay;
        }
        public void setCEM_Scale_Delay(int  cem_scale_delay)
        {
            this.CEM_Scale_Delay= cem_scale_delay;
        }
        public void setWater_Scale_Delay(int water_delay)
        {
            this.Water_Scale_Delay = water_delay;
        }
        public void setADX_Scale_Delay(int adx_delay)
        {
            this.ADX_Scale_Delay = adx_delay;
        }
        public void setColor_Scale_Delay(int color_scale_delay)
        {
            this.Color_Scale_Delay = color_scale_delay;
        }
        public void setIce_Scale_Delay(int ice_delay)
        {
            this.Ice_Scale_Delay = ice_delay;
        }
        public void setAgg_Preact_Value(float preact_value)
        {
            this.Agg_Preact_Value = preact_value;
        }
        public void setCEM_Preact_Value(float preact_value)
        {
            this.CEM_Preact_Value= preact_value;
        }
        public void setWater_Preact_Value(float preact_value)
        {
            this.Water_Preact_Value= preact_value;
        }
        public void setADX_Preact_Value(float preact_value)
        {
            this.ADX_Preact_Value = preact_value;
        }
        public void setColor_Preact_Value(float preact_value)
        {
            this.Color_Preact_Value = preact_value;
        }
        public void setIce_Preact_Value(float preact_value)
        {
            this.Ice_Preact_Value = preact_value;
        }
        public void setWeighing_Duration(float duration)
        {
            this.Weighing_Duration = duration;
        }
        public void setWeighing_State(string state)
        {
            this.Weighing_Module_State = state;
        }
        public void setAGG_Target_Weight(float target_weight)
        {
            this.Agg_Total_Target_Weight = target_weight;
        }
        public void setCEM_Target_Weight(float target_weight)
        {
            this.CEM_Total_Target_Weight = target_weight;
        }
        public void setWater_Target_Weight(float target_weight)
        {
            this.Water_Total_Target_Weight = target_weight;
        }
        public void setADX1_Target_Weight(float target_weight)
        {
            this.ADX1_Total_Target_Weight = target_weight;
        }
        public void setADX2_Target_Weight(float target_weight)
        {
            this.ADX2_Total_Target_Weight = target_weight;
        }
        public void setColor_Target_Weight(float target_weight)
        {
            this.Color_Total_Target_Weight = target_weight;
        }
        public void setICE_Target_Weight(float target_weight)
        {
            this.ICE_Total_Target_Weight = target_weight;
        }
        public void setAgg_Actual_Weight(float actual_weight)
        {
            this.Agg_Total_Actual_Weight = actual_weight;
        }
        public void setCEM_Actual_Weight(float actual_weight)
        {
            this.CEM_Total_Actual_Weight = actual_weight;
        }
        public void setWater_Actual_Weight(float actual_weight)
        {
            this.Water_Total_Actual_Weight = actual_weight;
        }
        public void setADX1_Actual_Weight(float actual_weight)
        {
            this.ADX1_Total_Actual_Weight = actual_weight;
        }
        public void setADX2_Actual_Weight(float actual_weight)
        {
            this.ADX2_Total_Actual_Weight= actual_weight;
        }
        public void setColor_Actual_Weight(float actual_weight)
        {
            this.Color_Total_Actual_Weight = actual_weight;
        }
        public void setICE_Actual_Weight(float actual_weight)
        {
            this.ICE_Total_Actual_Weight = actual_weight;
        }
        public int getConfiguration_No()
        {
            return this.Configuration_No;
        }
        public string getAggMode()
        {
            return this.Agg_Dosing_Mode;
        }
        public string getCEMMode()
        {
            return this.CEM_Dosing_Mode;
        }
        public string getWaterMode()
        {
            return this.Water_Dosing_Mode;
        }
        public string getADXMode()
        {
            return this.ADX_Dosing_Mode;
        }
        public string getColorMode()
        {
            return this.Color_Dosing_Mode;
        }
        public string getIceMode()
        {
            return this.Ice_Dosing_Mode;
        }
        public int getBatchNumber()
        {
            return this.Batch_Number;
        }
        public int getAgg_Scale_Delay()
        {
            return this.Agg_Scale_Delay;
        }
        public int getCEM_Scale_Delay()
        {
            return this.CEM_Scale_Delay;
        }
        public int getWater_Scale_Delay()
        {
            return this.Water_Scale_Delay ;
        }
        public int getADX_Scale_Delay()
        {
            return this.ADX_Scale_Delay;
        }
        public int getColor_Scale_Delay()
        {
            return this.Color_Scale_Delay;
        }
        public int getIce_Scale_Delay()
        {
            return this.Ice_Scale_Delay;
        }
        public float getAgg_Preact_Value()
        {
           return this.Agg_Preact_Value;
        }
        public float getCEM_Preact_Value()
        {
           return this.CEM_Preact_Value;
        }
        public float getWater_Preact_Value()
        {
            return this.Water_Preact_Value ;
        }
        public float getADX_Preact_Value()
        {
            return this.ADX_Preact_Value;
        }
        public float getColor_Preact_Value()
        {
            return this.Color_Preact_Value;
        }
        public float getIce_Preact_Value()
        {
            return this.Ice_Preact_Value;
        }
        public float getWeighing_Duration()
        {
            return this.Weighing_Duration;
        }
        public string getWeighing_State()
        {
            return this.Weighing_Module_State;
        }
        public float getAgg_Target_Weight()
        {
            return Agg_Total_Target_Weight;
        }
        public float getCEM_Target_Weight()
        {
            return CEM_Total_Target_Weight;
        }
        public float getWater_Target_Weight()
        {
            return Water_Total_Target_Weight;
        }
        public float getADX1_Target_Weight()
        {
            return ADX1_Total_Target_Weight;
        }
        public float getADX2_Target_Weight()
        {
            return ADX2_Total_Target_Weight;
        }
        public float getColor_Target_Weight()
        {
            return Color_Total_Target_Weight;
        }
        public float getICE_Target_Weight()
        {
            return ICE_Total_Target_Weight;
        }
        public float getAgg_Actual_Weight()
        {
            return Agg_Total_Actual_Weight;
        }
        public float getCEM_Actual_Weight()
        {
            return CEM_Total_Actual_Weight;
        }
        public float getWater_Actual_Weight()
        {
            return Water_Total_Actual_Weight;
        }
        public float getADX1_Actual_Weight()
        {
            return ADX1_Total_Actual_Weight;
        }
        public float getADX2_Actual_Weight()
        {
            return ADX2_Total_Actual_Weight;
        }
        public float getColor_Actual_Weight()
        {
            return Color_Total_Actual_Weight;
        }
        public float getICE_Actual_Weight()
        {
            return ICE_Total_Actual_Weight;
        }
        //-----------------------------------------
    }
    //-------------------------------------------------------
    // Discharge Module Class:
    public class DischargingModule
    {
        // data fields:
        private int Configuration_No; // Auto_Incremented
        private string Discharge_Mode;
        private int Batch_Number;
        private float Discharge_Duration;
        private string Discharge_Module_State;
        //------------------------------------------
        // Create Discharge Module Object:
        public DischargingModule()
        {
        }
        public DischargingModule(string mode, int batch_number, float duration, string state)
        {
            this.Discharge_Mode = mode;
            this.Batch_Number = batch_number;
            this.Discharge_Duration = duration;
            this.Discharge_Module_State = state;
        }
        //-----------------------------------------------------
        // Setters & Getters:
        public void setDischarge_Mode(string mode)
        {
            this.Discharge_Mode = mode;
        }
        public void setBatch_number(int batch_number)
        {
            this.Batch_Number = batch_number;
        }
        public void setDuration(float duration)
        {
            this.Discharge_Duration = duration;
        }
        public void setDischargeState(string state)
        {
            this.Discharge_Module_State= state;
        }
        public int getConfiguration_No()
        {
            return this.Configuration_No;
        }
        public string getDischargeMode()
        {
            return this.Discharge_Mode;
        }
        public int getBatchNumber()
        {
            return this.Batch_Number;
        }
        public float getDischarge_Duration()
        {
            return this.Discharge_Duration;
        }
        public string getDischargeState()
        {
            return this.Discharge_Module_State;
        }
        //------------------------------------------------
    }
    //------------------------------------------------------------------
    // Mixing Module Class:
    public class MixingModule
    {
        // data fields:
        private int Configuration_No; // Auto_Incremented
        private float Mixing_Duration;
        private int Batch_Number;
        private string Mixing_State;
        private string Concrete_Grade; // foreign key
        //---------------------------------------
        // Create Mixing Module Object:
        public MixingModule()
        {
        }
        public MixingModule(float mixing_duration, int batch_number, string state, string concrete_Grade)
        {
            this.Mixing_Duration = mixing_duration;
            this.Batch_Number = batch_number;
            this.Mixing_State = state;
            this.Concrete_Grade = concrete_Grade;
        }
        //----------------------------------------------
        // Setters & Getters:
        public void setMixing_Duration(float mixing_duration)
        {
            this.Mixing_Duration = mixing_duration;
        }
        public void setBatch_Number(int batch_number)
        {
            this.Batch_Number= batch_number;
        }
        public void setMixingState(string state)
        {
            this.Mixing_State = state;
        }
        public void setConcrete_Grade(string grade)
        {
            this.Concrete_Grade = grade;
        }
        public int getConfiguration_No()
        {
            return this.Configuration_No;
        }
        public float getMixing_Duration()
        {
            return this.Mixing_Duration;
        }
        public int getBatch_Number()
        {
            return this.Batch_Number;
        }
        public string getMixing_State()
        {
            return this.Mixing_State;
        }
        public string getConcrete_Grade()
        {
            return Concrete_Grade;
        }
        //-----------------------------------
    }
    //-----------------------------------------------
    // Product Class:
    public class Products
    {
        // data fields:
        private int Product_ID; // Auto_Incremented
        private string Product_Name;
        private string Formula_Code; // foreign key
        private int Client_ID; // foreign key
        private string Description;
        private string Specifications;
        private string Code;
        //---------------------------
        // create product object:
        public Products()
        {
        }
        public Products(string product_name, string formula_code, int client_id, string description, string specifications, string code)
        {
            this.Product_Name = product_name;
            this.Formula_Code = formula_code;
            this.Client_ID = client_id;
            Description = description;
            Specifications = specifications;
            this.Code = code;
        }
        //-------------------------------------------
        // setters & getters:
        public void setProduct_Name(string product_name)
        {
            this.Product_Name = product_name;
        }
        public void setFormula_Code(string formula_code)
        {
            this.Formula_Code = formula_code;
        }
        public void setClient_ID(int client_id)
        {
            this.Client_ID = client_id;
        }
        public void setDescription(string description)
        {
            this.Description = description;
        }
        public void setSpecifications(string specifications)
        {
            this.Specifications = specifications;
        }
        public void setCode(string code)
        {
            this.Code = code;
        }
        public int getProduct_ID()
        {
            return this.Product_ID; 
        }
        public string getProduct_Name()
        {
            return this.Product_Name;
        }
        public string getFormula_Code()
        {
            return this.Formula_Code;
        }
        public int getClient_ID()
        {
            return this.Client_ID;
        }
        public string getDescription()
        {
            return this.Description;
        }
        public string getSpecifications()
        {
            return this.Specifications;
        }
        public string getCode()
        {
            return this.Code;
        }
        //---------------------------------------------
    }
    //-------------------------------------------------------
    // Login Class:
    public class LoginForm
    {
        // data fields:
        private int Login_No; // Auto_Increment 
        private string Login_Email;
        private TimeOnly Login_Time;
        private TimeOnly Logout_Time;
        private DateOnly Login_Date;
        //----------------------------
        // create login object:
        public LoginForm()
        {
        }
        public LoginForm(string login_email, TimeOnly login_time,  TimeOnly logout_time, DateOnly login_date)
        {
            this.Login_Date = login_date;
            this.Login_Email = login_email;
            this.Login_Time = login_time;
            this.Logout_Time = logout_time;
        }
        //--------------------------------
        // setters & Getters:
        public void setEmail(string email)
        {
            this.Login_Email = email;
        }
        public void setLogin_Time(TimeOnly login_time)
        {
            this.Login_Time = login_time;
        }
        public void setLogin_Date(DateOnly login_date)
        {
            this.Login_Date = login_date;
        }
        public void setLogout_Time(TimeOnly logout_time)
        {
            this.Logout_Time=logout_time;
        }
        public int getLogin_No()
        {
            return Login_No; 
        }
        public string getLogin_Email()
        {
            return this.Login_Email;
        }
        public TimeOnly getLogin_Time()
        {
            return this.Login_Time;
        }
        public DateOnly getLogin_Date()
        {
            return this.Login_Date;
        }
        public TimeOnly getLogout_Time()
        {
            return this.Logout_Time;
        }
        //----------------------------------------
    }
    //----------------------------------------------------
    // Material Data Class:
    public class MaterialsData
    {
        // data fields:
        private int Material_ID; // Auto_Incremented
        private string Material_Name;
        private float Cost_Per_Unit;
        private string Unit;
        //----------------------------
        // create material object:
        public MaterialsData()
        {
        }
        public MaterialsData(string Material_Name, float Cost_Per_Unit, string unit)
        {
            this.Material_Name = Material_Name;
            this.Cost_Per_Unit = Cost_Per_Unit;
            this.Unit = unit;
        }
        //-------------------------------
        // setters & getters:
        public void setMaterial_Name(string Material_Name)
        {
            this.Material_Name = Material_Name;
        }
        public void setCost(float Cost)
        {
            this.Cost_Per_Unit = Cost;
        }
        public void setUnit(string Unit)
        {
            this.Unit = Unit;
        }
        public int getMaterial_ID()
        {
            return this.Material_ID;
        }
        public string getName()
        {
            return this.Material_Name;
        }
        public float getCost()
        {
            return this.Cost_Per_Unit;
        }
        public string getUnit()
        {
            return this.Unit;
        }
        //-------------------------
    }
    //--------------------------------------
    //Material Tracking Class:
    public class MaterialTracking
    {
        // data fields:
        private int Material_No; // Auto_Incremented
        private int Material_ID; // foreign key
        private float Container_Stored_Quantity;
        private float Stock_Stored_Quantity;
        private float Consumed_Quantity;
        private float Requested_Quantity;
        private float Received_Quantity;
        private DateOnly Request_Date;
        private DateOnly Receive_Date;
        private int Supplier_ID; // foreign key
        private string Formula_Code; // foreign key
        private int Report_ID; // foreign key
        //---------------------------
        // create tracking object:
        public MaterialTracking()
        {
        }
        public MaterialTracking(int Material_ID, float Container_Stored_Quantity, float Stock_Stored_Quantity, float Consumption_Rate, float Requested_Quantity, float Received_Quantity, DateOnly Request_Date, DateOnly Receive_Date, int Supplier_ID, string FOrmula_Code, int Report_ID)
        {
            this.Material_ID = Material_ID;
            this.Container_Stored_Quantity = Container_Stored_Quantity;
            this.Stock_Stored_Quantity= Stock_Stored_Quantity;
            this.Consumed_Quantity = Consumption_Rate;
            this.Requested_Quantity = Requested_Quantity;
            this.Received_Quantity = Received_Quantity;
            this.Request_Date = Request_Date;
            this.Receive_Date = Receive_Date;
            this.Supplier_ID = Supplier_ID;
            this.Formula_Code = FOrmula_Code;
            this.Report_ID = Report_ID;
        }
        //--------------------------------
        //setters & getters:
        public void setMaterialID(int Material_ID)
        {
            this.Material_ID = Material_ID;
        }
        public void setContainer_Stored_Quantity(float Container_Stored_Quantity)
        {
            this.Container_Stored_Quantity = Container_Stored_Quantity;
        }
        public void setStock_Stored_Quantity(float Stock_Stored_Quantity)
        {
            this.Stock_Stored_Quantity = Stock_Stored_Quantity;
        }
        public void setConsumed_Quantity(float Consumption_Quantity)
        {
            this.Consumed_Quantity = Consumption_Quantity;
        }
        public void setRequested_Quantity(float Requested_Quantity)
        {
            this.Requested_Quantity = Requested_Quantity;
        }
        public void setReceived_Quantity(float Received_Quantity)
        {
            this.Received_Quantity = Received_Quantity;
        }
        public void setRequest_Date(DateOnly request_date)
        {
            this.Request_Date = request_date;
        }
        public void setReceive_Date(DateOnly receive_date)
        {
            this.Receive_Date = receive_date;
        }
        public void setSupplier_ID(int Supplier_ID)
        {
          this.Supplier_ID = Supplier_ID;
        }
        public void setFormulaCode(String formulaCode)
        {
            this.Formula_Code = formulaCode;
        }
        public void setReport_ID(int Report_ID)
        {
            this.Report_ID = Report_ID;
        }
        public int getMaterial_No()
        {
            return this.Material_No;
        }
        public int getMaterialID()
        {
            return this.Material_ID;
        }
        public float getContainer_Stored_Quantity()
        {
            return this.Container_Stored_Quantity;
        }
        public float getStock_Stored_Quantity()
        {
            return this.Stock_Stored_Quantity;
        }
        public float getConsumed_Quantity()
        {
            return this.Consumed_Quantity;
        }
        public float getRequested_Quantity()
        {
            return this.Requested_Quantity;
        }
        public float getReceived_Quantity()
        {
            return this.Received_Quantity;
        }
        public DateOnly getRequest_Date()
        {
            return this.Request_Date;
        }
        public DateOnly getReceive_Date()
        {
            return this.Receive_Date;
        }
        public int getSupplier_ID()
        {
            return this.Supplier_ID;
        }
        public string getFormulaCode()
        {
            return this.Formula_Code;
        }
        public int getReport_ID()
        {
            return this.Report_ID;
        }
        //----------------------------
    }
    //--------------------------------------
  // Classes For Reports Generation 
    // Client DTO class:
    public class ClientOrderReportDTOs
    {
        // clients Data:
        public Client Clients { get; set; }
        //----------------------
        // orders Data:
        public List<Order> Orders { get; set; } = new();
        public List<OrderLines> Lines { get; set; } = new();
        public List<Shipments> Shipments { get; set; } = new();
        //---------------------------
        // Destinations Data:
        public List<Destination> Destinations { get; set; } = new();
        //----------------------------
        // trucks Data:
        public List<Truck> Trucks { get; set; } = new();
        //--------------------
        // Employees Data:
        public List<Employee> Employees { get; set; } = new();
        //--------------------------
        // Drivers Data:
        public List<Driver> Drivers { get; set; } = new();
        //-----------------
        //MaterialTracking Data:
        public List<Formula> Formulas { get; set; } = new();
        //------------------------
        // Products Data:
        public List<Products> Products { get; set; } = new();
       //------------------------------
       // Null values handling:
       public List<string> NullValues { get; set; } = new();
      //--------------------------------
    }
    //-----------------------------------------------------
    // Material DTO class:
    public class MaterialReportDTOs
    {
        // Materials Data:
        public int Material_ID { get; set; }   
        public string Material_Name { get; set; } 
        public string Unit { get; set; }
        public float Cost_Per_Unit { get; set; }
        public float Current_Stock_Quantity { get; set; } 
        public int Usage_Count { get; set; }
        public float Average_Consumption_Rate { get; set; }
        public float Average_Consumed_Quantity { get; set; }
        //---------------------------------------------
        // Supplier Info:
        public string Supplier_Name { get; set; }
        public string Supplier_Address { get; set; }
        public string Supplier_Email { get; set; }
        public int Supplier_Phone { get; set; }
        //--------------------------------
    }
    //---------------------------------------------
    // Truck DTO class:
    public class TruckReportDTOs
    {
        // Trucks Data:
        public int Truck_ID { get; set; }
        public string Truck_Plate { get; set; }
        public string Truck_Model { get; set; }
        public float Truck_Capacity { get; set; }
        public DateOnly License_Issue_Date { get; set; }
        public DateOnly License_Expiry_Date { get; set; }
        public int Number_of_Uses { get; set; }
        //---------------------------------------------
        // Driver Info:
        public int Driver_ID { get; set; } 
        public string Driver_Name { get; set; }
        public DateOnly Driver_License_Expiry_Date { get; set; }
        public DateOnly Driver_License_Issue_Date { get; set; }
        public int Driver_Phone { get; set; }
        public string Driver_Address { get; set; }
        //--------------------------------
    }
    //--------------------------------------------
    // Product DTO class:
    public class  ProductReportDTOs
    {
        // Products Data:
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Code { get; set; }
        public String Product_Description { get; set; }
        public string Product_Specifications { get; set; }
        public int Number_of_Requests { get; set; }
        //---------------------------------------------
        // Client Info:
        public int Client_ID { get; set; }
        public string Client_Name { get; set; }
        public string Client_Email { get; set; }
        public string Client_Company { get; set; }
        //-----------------------------------------
        // Formula Info:
        public string Formula_Code { get; set; }
        public string Concrete_Grade { get; set; }
        //-------------------------------------------
    }
    //-------------------------------------------------------
    // Components DTO class:
    public class ComponentDTOs
    {
        // Components Data:
        public int Component_ID { get; set; }
        public string Component_Name { get; set; }
        public float Component_Cost { get; set; }
        public string Component_State { get; set; }
        public DateOnly Purchasing_Date { get; set; }
        //---------------------------------------------
        // Supplier Info:
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Location { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_State { get; set; }
        //--------------------------------
    }
    //------------------------------------------------------
    // Employee DTO class:
    public class EmployeeReportDTOs
    {
        // Employees Data:
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public int Employee_Age { get; set; }
        public string Employee_Work_Email { get; set; }
        public string Employee_Role { get; set; }
        public string Employee_Address { get; set; }
        public int Employee_Phone { get; set; }
        public float Employee_Salary { get; set; }
        public float Employee_Bonus { get; set; }
        public float Employee_Total_Salary { get; set; }
        public string Employee_Status { get; set; }
        public int Total_Orders_Handled { get; set; }
        //---------------------------------------------
        // Login Info:
        public DateOnly Last_Login_Date { get; set; }
        public TimeOnly Last_Login_Time { get; set; }
        public int Total_Logins { get; set; }
        //--------------------------------
    }
    //------------------------------------------------
    // Alarm DTO class:
    public class  AlarmReportDTOs
    {
        // Alarm data:
        public int Alarm_ID { get; set; }
        public string Alarm_Name { get; set; }
        public DateOnly Alarm_Date { get; set; }
        public TimeOnly Alarm_Time { get; set; }
        //---------------------------------------
    }
    //------------------------------------------------
}

