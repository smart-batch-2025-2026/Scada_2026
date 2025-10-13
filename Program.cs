// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using SCADA.Domain;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
namespace SCADA.Application
{
    // there will be an interface to define the functions that read and write values from/to the Tia Portal DataBlocks.
    // PLC Interface: (PLC <--> SCADA)
    public interface plcInterface
    {
      // implemented later  
    }
    //-----------------------------------------
    // Sensor Interface: (PLC <--> SCADA)
    public interface SensorInterface
    {
        float ReadValue(Sensors s); // read the value of the given sensor from tia portal datablock.
        void Calibrate(Sensors s); // calibrate the given sensor.
        bool IsOperational(Sensors s); // check if the given sensor is operational or not.
    }
    //------------------------------------
    // Actuator Interface: (PLC <--> SCADA)
    public interface ActuatorInterface
    {
        void Activate(Actuator a);   // turn actuator on.
        void Deactivate(Actuator a); // turn actuator off.
        bool IsActive(Actuator a);  // check actuator state.
    }
    //-----------------------------------------------------
    // ALarm Interface: (PLC <--> SCADA), (Database <--> SCADA)
    public interface AlarmInterface
    {
        bool CheckAlarmStatus(int id); // check if the alarm with the given id is active or not. by reading it from tia portal datablock
        Alarms GetActiveAlarm(int id); // returns active alarm from the tia portal datablock.
        List<Alarms> GetAllActiveAlarms(); // returns all alarms from SQL Database.
    }
    //--------------------------------------------
    // General Functions Interface: (SCADA <--> Database)
    public interface GeneralFunctions<T>
    {
        void Delete(T item); // delete the selected item from the database.
        T Find(int id); // returns the first item with the given id.
        T Find(string item); // returns the first item with the given code.
        void ADD(T item); // insert into the database.
        List<T> GetAll(); // returns all items from the database.
        void Update(T item); // update the selected item in the database. 
        List<T> Filter(string item); // returns all items that meet the filter criteria.
       // void ExportToExcel(string filePath); // export data to a excel file.
       // void ImportFromExcel(string filePath); // import data from a excel file.
    }
    //--------------------------------------------------
    // Operation Result Classes: wrapper class to handle errors and not found data
    // used as return type for the methods defined in the service classes.
    public class OperationResults
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    //----------
    public class OperationResults<T> : OperationResults
    {
        public T? data { get; set; }
        public static OperationResults<T> success( T data, string message = "")
            => new OperationResults<T> { Success = true, Message = message, data = data };
        public static OperationResults<T> failure(string message)
            => new OperationResults<T> { Success = false, Message = message};
    }
    //----------------------------------------------------
    // Formula Service class:
    public class FormulaService 
    {
     // Data field:
       private GeneralFunctions<Formula> formula;
     //-------------------
     // Constructor:
        public FormulaService(GeneralFunctions<Formula> formula)
        {
            this.formula = formula; 
        }
     //-------------------------
     // Methods:
        public OperationResults CreateFormula(Formula F)
        {
            // in the presentation layer create an object from Formula class, assign textboxs' to that object parameters.
            // then this object is passed to the CreateFormula function and added to the SQL Database.
            try
            {
                formula.ADD(F); // to MySQL database
                // display a message to indicate that the formula has been created  & Saved successfully
                return new OperationResults { Success = true, Message = "Formula created and saved to database successfully." };
                // passed to the presentation layer to be displayed in a message box.
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Formula creation failed." };
            }
        }
        public OperationResults EditFormula(Formula old_formula)
        {
            // in the presentation layer the selected formula from the list is restored from the database to the old_formula object
            // then this object is passed to the EditFormula function and a GUI form is opened showing all old_formula parameters to be edit
            // then after editing this data is saved back to the SQL database.
            // searching in the database will be by the formula code.
            try
            {   // display a message to indicate that the formula has been updated successfully.
                formula.Update(old_formula); // in MySQL database
                return new OperationResults { Success = true, Message = "Formula updated successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Formula update failed." };
            }
        }
        public OperationResults DeleteFormula(Formula formula_to_delete)
        {
            // in the presentation layer the selected formula from the list is restored from the database to the formula_to_delete object
            // then this object is deleted from the database.
            try
            { // display a message to indicate that the deletion process has been done successfully.
                formula.Delete(formula_to_delete); // from MySQL database
                return new OperationResults {Success = true, Message = "Formula deleted successfully." };
            }
            catch
            {
                return new OperationResults {Success = false, Message = "Error: Formula deletion failed." };
            }
        }
        public OperationResults<List<Formula>> GetAllFormulas()
        {
          // this method is used to retrun a copy of the database and display this copy in a GUI LIST.
           var result =  formula.GetAll();
            if(result == null || result.Count == 0)
            {
                return OperationResults<List<Formula>>.failure("No formulas found.");
            }
            return OperationResults<List<Formula>>.success(result, "Formula Retrieved Successfully");
        }
        public OperationResults<Formula> FindFormula(string formula_code)
        {
         // this method is used to serach in the database for a specific formula by comparing by the formula_code.
            var result =  formula.Find(formula_code); // from MySQL database
            if(result == null)
            {
                return OperationResults<Formula>.failure("Formula with code: "+formula_code+" is not found.");
            }
            return OperationResults<Formula>.success(result, "Formula with code: " + formula_code+ " is found successfully");
        }
     //--------------------------------------------
    }
    //---------------------------------------
    // CLient Service Class:
    public class ClientService
    {
     // Data fields:
        private GeneralFunctions<Client> client;
     //---------------------------
     // Constructor:
        public ClientService(GeneralFunctions<Client> client)
        {
            this.client = client;
        }
     //-------------------------------
     // Methods:
        public OperationResults AddNewClient(Client C)
        {
            // in the presentation layer create an object from client class, assign textboxs' to that object parameters.
            // then this object is passed to the AddNewClient function and added to the SQL Database.
            try
            {  // display a message to indicate that the client has been created  & Saved successfully
                client.ADD(C); // to MySQL database
                return new OperationResults { Success = true, Message = "Client created and saved to database successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Client creation failed." };
            } 
        }
        public OperationResults EditClient(Client old_client)
        {
            // in the presentation layer the selected client from the list is restored from the database to the old_client object
            // then this object is passed to the EditClient function and a GUI form is opened showing all old_client parameters to be edited
            // then after editing, this data is saved back to the SQL database.
            // searching in the database will be by comparing the Client_ID
            try
            { // display a message to indicate that updating client's data is done successfully.
                client.Update(old_client); // in MySQL database
                return new OperationResults { Success = true, Message = "Client data updated successfully." };
            }
            catch
            {
               return new OperationResults { Success = false, Message = "Error: Client data update failed." };
            }
        }
        public OperationResults DeleteClient(Client client_to_delete)
        {
            // in the presentation layer the selected client from the list is restored from the database to the client_to_delete object
            // then this object is deleted from the database.
            try
            { // display a message to indicate that the deletion process is done successfully.
                client.Delete(client_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Client deleted successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Client deletion failed." };
            }
        }
        public OperationResults<List<Client>> GetAllClients()
        {
         // this method is used to return a copy from client database to be shown in the GUI layer.
           var results =  client.GetAll();
            if(results == null || results.Count ==0)
            {
                return OperationResults<List<Client>>.failure("No clients found.");
            }
            return OperationResults<List<Client>>.success(results, "Clients Retrieved Successfully");
        }
        public OperationResults<Client> FindClient(int client_id)
        {
         // this method is used to search for clients by using their IDs.
            var result = client.Find(client_id); // from MySQL database
            if(result == null)
            {
                return OperationResults<Client>.failure("Client with ID: "+client_id+" is not found.");
            }
            return OperationResults<Client>.success(result, "Client with ID: " + client_id + " is found successfully");
        }
        public OperationResults<Client> FindClient(string client_name)
        {
         // this method is used to search for clients by using their Names.
         // this methof will return the first matching row.
            var result = client.Find(client_name); // from MySQL database
            if(result == null)
            {
                return OperationResults<Client>.failure("Client with Name: " + client_name + " is not found.");
            }
            return OperationResults<Client>.success(result, "Client with Name: " + client_name + " is found successfully");
        }
     //------------------------------------------------
    }
    //-------------------------------------------
    // Driver Service Class:
    public class DriverService
    {
     // Data Fields:
        private GeneralFunctions<Driver> driver;
      //------------------------
     // Constructor:
        public DriverService(GeneralFunctions<Driver> driver)
        {
            this.driver = driver;
        }
     //-----------------------
     // Methods:
        public OperationResults AddNewDriver(Driver D)
        {
            // in the presentation layer create an object from Driver class, assign textboxs' to that object parameters.
            // then this object is passed to the AddNewDiver function and added to the SQL Database.
            try
            { // display a message to indicate that the driver has been created  & Saved successfully
                driver.ADD(D); // to MySQL database
                return new OperationResults { Success = true, Message = "Driver created and saved to database successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Driver creation failed." };
            }
        }
        public OperationResults EditDriver(Driver old_driver)
        {
            // in the presentation layer the selected Driver from the list is restored from the database to the old_driver object
            // then this object is passed to the EditDriver function and a GUI form is opened showing all old_Driver parameters to be edited
            // then after editing, this data is saved back to the SQL database.
            // searching in the database will be by comparing the Driver_ID
            try
            { // display a message to indicate that the parameters are updated successfully.
                driver.Update(old_driver); // in MySQL database
                return new OperationResults { Success = true, Message = "Driver data updated successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Driver data update failed." };
            }
        }
        public OperationResults DeleteDriver(Driver driver_to_delete)
        {
            // in the presentation layer the selected driver from the list is restored from the database to the driver_to_delete object
            // then this object is deleted from the database.
            try
            {
                driver.Delete(driver_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Driver deleted successfully." };   
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Driver deletion failed." };
            }
        }
        public OperationResults<List<Driver>> GetAllDrivers()
        {
         // this method is used to return a copy from driver database to be shown in the GUI layer.
            var results = driver.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Driver>>.failure("No Drivers Found");
            }
            return OperationResults<List<Driver>>.success(results, "Drivers Retrieved Successfully");
        }
        public OperationResults<Driver> FindDriver(int driver_id)
        {
         // this method is used to search for drivers by using their IDs.
            var results = driver.Find(driver_id); // from MySQL database
            if(results == null)
            {
                return OperationResults<Driver>.failure("Driver with ID: "+driver_id+" is not found.");
            }
            return OperationResults<Driver>.success(results, "Driver with ID: " + driver_id + " is found successfully");
        }
        public OperationResults<Driver> FindDriver(string driver_name)
        {
         // this method is used to search for drivers by using their Names.
            var result = driver.Find(driver_name); // from MySQL database
            if(result == null)
            {
                return OperationResults<Driver>.failure("Driver with Name: " + driver_name + " is not found.");
            }
            return OperationResults<Driver>.success(result, "Driver with Name: " + driver_name + " is found successfully");
        }
        //-------------------------------------------------
    }
    //------------------------------------------
    // Truck Service Class:
    public class TruckService
    {
     // Data Fields:
        private GeneralFunctions<Truck> truck;
     //--------------------------------------------
     // Constructor:
        public TruckService(GeneralFunctions<Truck> truck)
        {
            this.truck = truck;
        }
     //----------------------------
     // Methods:
        public OperationResults AddNewTruck(Truck T)
        {
            // in the presentation layer create an object from Truck class, assign textboxs' to that object parameters.
            // then this object is passed to the AddNewTruck function and added to the SQL Database.
            try
            {  // display a message to indicate that the truck has been created  & Saved successfully
                truck.ADD(T); // to MySQL database
                return new OperationResults { Success = true, Message = "Truck created and saved to database successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Truck creation failed." };
            }  
        }
        public OperationResults EditTruck(Truck old_truck)
        {
            // in the presentation layer the selected Driver from the list is restored from the database to the old_driver object
            // then this object is passed to the EditDriver function and a GUI form is opened showing all old_Driver parameters to be edited
            // then after editing, this data is saved back to the SQL database.
            // searching in the database will be by comparing the Driver_ID
            try
            {
                truck.Update(old_truck); // in MySQL database
                return new OperationResults { Success = true, Message = "Truck data updated successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Truck data update failed." };
            }
        }
        public OperationResults DeleteTruck(Truck truck_to_delete)
        {
            try
            {
                truck.Delete(truck_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Truck deleted successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Truck deletion failed." };
            }
        }
        public OperationResults<List<Truck>> GetAllTrucks()
        {

             var results = truck.GetAll();
            if( results == null || results.Count == 0)
            {
                return OperationResults<List<Truck>>.failure("No Trucks Found");
            }
            return OperationResults<List<Truck>>.success(results, "Trucks Retrieved Successfully");
        }
        public OperationResults<Truck> FindTruck(int truck_id)
        {
            var result = truck.Find(truck_id); // from MySQL database
            if(result == null)
            {
                return OperationResults<Truck>.failure("Truck with ID: "+truck_id+" is not found.");
            }
            return OperationResults<Truck>.success(result, "Truck with ID: " + truck_id + " is found successfully");
        }
     //-------------------------------------------
    }
    //----------------------------------------------------
    // Components Service Class:
    public class ComponentsService
    {
        // Data Fields:
        private GeneralFunctions<Components> components;
        //-----------------------------------------
        // Constructor:
        public ComponentsService(GeneralFunctions<Components> components)
        {
            this.components = components;
        }
        //------------------------------
        // Methods:
        public OperationResults AddNewComponent(Components C)
        {
            try
            { // display a message to indicate that the component has been created  & Saved successfully
            
                components.ADD(C); // to MySQL database
                return new OperationResults { Success = true, Message = "Component created and saved to database successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Component Creation Failed" };
            }
        }
        public OperationResults EditComponent(Components old_component)
        {
            try
            {
                components.Update(old_component); // in MySQL database
                return new OperationResults { Success = true, Message = "Component updated successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Component Update Failed" };
            }
        }
        public OperationResults DeleteComponent(Components component_to_delete)
        {
            try
            {
                components.Delete(component_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Component deleted successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Component Deletion Failed" };
            }
        }
        public OperationResults<List<Components>> GetAllComponents()
        {
            var results = components.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Components>>.failure("No Components Found");
            }
            return OperationResults<List<Components>>.success(results, "Components Retrieved Successfully");
        }
        public OperationResults<Components> FindComponent(int component_id)
        {
            var result = components.Find(component_id); // from MySQL database
            if(result == null)
            {
                return OperationResults<Components>.failure("Component with ID: "+component_id+" is not found.");
            }
            return OperationResults<Components>.success(result, "Component with ID: " + component_id + " is found successfully");
        }
        //-----------------------------------------------
    }
    //---------------------------------------------------------------------------
    // Supplier Service Class:
    public class SupplierService
    {
        // Data Fields:
        private GeneralFunctions<Supplier> supplier;
        //-----------------------
        // Constructor:
        public SupplierService(GeneralFunctions<Supplier> supplier)
        {
            this.supplier = supplier;
        }
        //--------------------
        // Methods:
        public OperationResults AddNewSupplier(Supplier S)
        {
            try
            { // display a message to indicate that the supplier has been created  & Saved successfully
                supplier.ADD(S); // to MySQL database
                return new OperationResults { Success = true, Message = "Supplier created and Saved to database sucessfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Suuplier Creation Failed" };
            }
        }
        public OperationResults EditSupplier(Supplier old_supplier)
        {
            try
            {
                supplier.Update(old_supplier); // in MySQL database
                return new OperationResults { Success = true, Message = "Supplier Data is updated successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = " Supplier data update failed" };
            }
        }
        public OperationResults DeleteSupplier(Supplier supplier_to_delete)
        {
            try
            {
                supplier.Delete(supplier_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Supplier Deletion is done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = " Supplier deletion failed" };
            }
        }
        public OperationResults<List<Supplier>> GetAllSuppliers()
        {
             var results = supplier.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Supplier>>.failure("No Suppliers Found");
            }
            return OperationResults<List<Supplier>>.success(results, "Suppliers Retrieved Successfully");
        }
        public OperationResults<Supplier> FindtSupplier(int supplier_id)
        {
            var result = supplier.Find(supplier_id); // from MySQL database
            if (result == null)
            {
                return OperationResults<Supplier>.failure("Supplier with id: " + supplier_id + " is not found");
            }
            return OperationResults<Supplier>.success(result, "Supplier with id: " + supplier_id + " is found successfully");
        }
        public OperationResults<Supplier> FindSupplier(string supplier_name)
        {
            var result = supplier.Find(supplier_name); // from MySQL database
            if(result == null)
            {
                return OperationResults<Supplier>.failure("Supplier with name: " + supplier_name + " is not found");
            }
            return OperationResults<Supplier>.success(result, "Supplier with name: " + supplier_name + " is found successfully");
        }
        //------------------------------
    }
    //--------------------------------------------------------
    // Employee Service Class:
    public class EmployeeService
    {
        // Data Fields:
        private GeneralFunctions<Employee> employee;
        //------------------------------
        // Constructor:
        public EmployeeService(GeneralFunctions<Employee> employee)
        {
            this.employee = employee;
        }
        //---------------------------------
        // Methods:
        public OperationResults AddNewEmployee(Employee E)
        {
            try
            { // display a message to indicate that the employee has been created  & Saved successfully
                employee.ADD(E); // to MySQL database
                return new OperationResults { Success = true, Message = "Employee created and saved to database successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Employee creation failed." };
            } 
        }
        public OperationResults EditEmployee(Employee old_employee)
        {
            try
            {
                employee.Update(old_employee); // in MySQL database
                return new OperationResults { Success = true, Message = "Employee's data is updated successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Employee data update failed." };
            }
        }
        public OperationResults DeleteEmployee(Employee employee_to_delete)
        {
            try
            {
                employee.Delete(employee_to_delete); // from MySQL database
                return new OperationResults  { Success = true, Message = "Employee deleted successfully." };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Error: Employee deletion failed." };
            }
        }
        public OperationResults<Employee> GetEmployee(int id)
        {
            var result = employee.Find(id); // from MySQL database
            if(result == null)
            {
                return OperationResults<Employee>.failure("Employee with ID: "+id+" is not found.");
            }
            return OperationResults<Employee>.success(result, "Employee with ID: " + id + " is found successfully");    
        }
        public OperationResults<Employee> GetEmployee(string name)
        {
            var result = employee.Find(name); // from MySQL database
            if( result == null )
            {
                return OperationResults<Employee>.failure("Employee with the name: "+name+" is not found.");
            }
            return OperationResults<Employee>.success(result, "Employee with the name: " + name + " is found successfully");
        }
        public OperationResults<List<Employee>> GetAllEmployees()
        {
             var results = employee.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Employee>>.failure("No Employees are found");
            }
            return OperationResults<List<Employee>>.success(results, "Employees Retrieved Successfully");
        }
        //----------------------------------------------------
    }
    //-------------------------------------------------------------
    // Alarm Service Class:
    public class AlarmService
    {
        // Data Fields:
        private GeneralFunctions<Alarms> alarm;
        private AlarmInterface alarmInterface;
        //-------------------------
        // Constructor:
        public AlarmService(GeneralFunctions<Alarms> alarm_SQL, AlarmInterface alarm_DB)
        {
            this.alarm = alarm_SQL; // opeartions done on MySQL database.
            this.alarmInterface = alarm_DB; // operations done on TIA portal datablock.
        }
        //--------------------------
        // Methods:
        public OperationResults<int> StoreAlarms(List<int> alarm_id)
        {
            int Alarm_Counter = 0;
            try
            {
                foreach (var a_id in alarm_id)
                {
                    if (alarmInterface.CheckAlarmStatus(a_id) == true)
                    {
                        Alarms a = alarmInterface.GetActiveAlarm(a_id);
                        a.setOccurance_Date(DateOnly.FromDateTime(System.DateTime.Now));
                        a.setOccurance_Time(TimeOnly.FromDateTime(System.DateTime.Now));
                        alarm.ADD(a); // store the active alarm in the MySQL database.
                        Alarm_Counter++;
                    }
                }
                return new OperationResults<int>
                {
                    Success = true,
                    Message = Alarm_Counter > 0
                ? $"{Alarm_Counter} alarm(s) stored successfully."
                : "No active alarms found to store.",
                    data = Alarm_Counter
                };
            }
            catch (Exception ex)
            {
                return new OperationResults<int>
                {
                    Success = false,
                    Message = $"Error while storing alarms: {ex.Message}",
                    data = Alarm_Counter
                };
            }
            
        }
        public OperationResults<List<Alarms>> GetAllAlarms()
        {
             var results = alarm.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Alarms>>.failure("No Alarms are found");
            }
            return OperationResults<List<Alarms>>.success(results, "Alarms are retrieved successfully");
        }
        public OperationResults<List<Alarms>> GetAllActiveAlarms()
        {
            var results = alarmInterface.GetAllActiveAlarms(); // from TIA portal datablock
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<Alarms>>.failure("No active alarms are found");
            }
            return OperationResults<List<Alarms>>.success(results, "Active Alarms are retrieved");
        }
        //---------------------------
    }
    //--------------------------------------------------------------
    // Docket Service Class:
    public class DocketService
    {
        // Data Fields:
        private GeneralFunctions<DeliveryDocket> docket;
        //-----------------------------
        // Constructor:
        public DocketService(GeneralFunctions<DeliveryDocket> docket)
        {
            this.docket = docket;
        }
        //----------------------------
        // Methods:
        public OperationResults CreateDocket(DeliveryDocket D)
        {
            try
            {
                docket.ADD(D); // to MySQL database
                return new OperationResults { Success = true, Message = "Docket Created Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Docket Creation Failed" };
            }
        }
        public OperationResults EditDocket(DeliveryDocket old_docket)
        {
            try
            {
                docket.Update(old_docket); // in MySQL database
                return new OperationResults { Success = true, Message = "Docket data updated Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Docket Data update is failed" };
            }
        }
        public OperationResults DeleteDocket(DeliveryDocket docket_to_delete)
        {
            try
            {
                docket.Delete(docket_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Docket Deleted Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Docket Deletion is Failed" };
            }
        }
        public OperationResults<List<DeliveryDocket>>  GetAllDockets()
        {
             var results = docket.GetAll();
            if(results.Count == 0 || results == null)
            {
                return OperationResults<List<DeliveryDocket>>.failure("No Dockets are found");
            }
            return OperationResults<List<DeliveryDocket>>.success(results, "Dockets are retrieved");
        }
        public OperationResults<DeliveryDocket> FindDocket(int docket_id)
        {
            var result = docket.Find(docket_id); // from MySQL database
            if(result == null)
            {
                return OperationResults<DeliveryDocket>.failure("Docket with id: " + docket_id + " is not found");
            }
            return OperationResults<DeliveryDocket>.success(result, "Docket with id: " + docket_id + "is found");
        }
        //---------------------------------
    }
    //--------------------------------------------------------------------
    // Order Service Class:
    public class OrderService
    {  
        // Data Fields:
        private GeneralFunctions<Order> order;
        //----------------------------------
        // Constructor:
        public OrderService(GeneralFunctions<Order> order)
        {
            this.order = order;
        }
        //---------------------------
        // Methods:
        public OperationResults CreateOrder(Order O)
        {
            try
            {
                order.ADD(O); // to MySQL database
                return new OperationResults { Success = true, Message = "Order Created Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Order Creation Failed" };
            }
            // display a message to indicate that the order has been created  & Saved successfully
        }
        public OperationResults EditOrder(Order old_order)
        {
            try
            {
                order.Update(old_order); // in MySQL database
                return new OperationResults { Success = true, Message = "Order Updated Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Order Update Faild" };
            }
        }
        public OperationResults DeleteOrder(Order order_to_delete)
        {
            try
            {
                order.Delete(order_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Order Deleted Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Order Deletion is failed" };
            }
        }
        public OperationResults<List<Order>> GetAllOrders()
        {
             var results = order.GetAll();
            if(results == null || results.Count ==0)
            {
                return OperationResults<List<Order>>.failure("No Orders Found");
            }
            return OperationResults<List<Order>>.success(results, "Orders are retrieved");
        }
        public OperationResults<Order> FindOrder(int order_id)
        {
            var result = order.Find(order_id); // from MySQL database
            if(result == null)
            {
                return OperationResults<Order>.failure("Order with id: " + order_id + " is not found");
            }
            return OperationResults<Order>.success(result, "Order with id: " + order_id + " is found");
        }
        //-----------------------
    }
    //-----------------------------------------------------
    // Order Lines Service Class:
    public class OrderLinesService
    {
        //Data Fields:
        private GeneralFunctions<OrderLines> orderlines;
        //-------------------------
        // Constructor:
        public OrderLinesService(GeneralFunctions<OrderLines> orderlines)
        {
            this.orderlines = orderlines;
        }
        //--------------------------
        // Methods:
        public OperationResults CreatLine(OrderLines line)
        {
            try
            {
                orderlines.ADD(line);
                return new OperationResults { Success = true, Message = "Order Line is added successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Order Line creation failed" };
            }
        }
        public OperationResults EditLine(OrderLines old_line)
        {
            try
            {
                orderlines.Update(old_line); // in MySQL database
                return new OperationResults { Success = true, Message = "Line Updated Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Line Update Faild" };
            }
        }
        public OperationResults DeleteLine(OrderLines line_to_delete)
        {
            try
            {
                orderlines.Delete(line_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "line Deleted Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Line Deletion is failed" };
            }
        }
        public OperationResults<List<OrderLines>> GetAllLines()
        {
            var results = orderlines.GetAll();
            if (results == null || results.Count == 0)
            {
                return OperationResults<List<OrderLines>>.failure("No Lines Found");
            }
            return OperationResults<List<OrderLines>>.success(results, "Lines are retrieved");
        }
        public OperationResults<OrderLines> FindLine(int line_id)
        {
            var result = orderlines.Find(line_id); // from MySQL database
            if (result == null)
            {
                return OperationResults<OrderLines>.failure("line with id: " + line_id + " is not found");
            }
            return OperationResults<OrderLines>.success(result, "line with id: " + line_id + " is found");
        }
        //------------------------------------------
    }
    //-----------------------------------------------------------
    // Shipments Service Class:
    public class ShipmentsService
    {
        // Data Fields:
        private GeneralFunctions<Shipments> shipment;
        //-----------------
        // Constructor:
        public ShipmentsService(GeneralFunctions<Shipments> shipments)
        {
            this.shipment = shipments;
        }
        //----------------------------
        // Methods:
        public OperationResults CreatShipment(Shipments ship)
        {
            try
            {
                shipment.ADD(ship);
                return new OperationResults { Success = true, Message = "Shipment is created successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Shipment creation failed" };
            }
        }
        public OperationResults EditShipemnt(Shipments ship)
        {
            try
            {
                shipment.Update(ship); // in MySQL database
                return new OperationResults { Success = true, Message = "Shipment Updated Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Shipment Update Faild" };
            }
        }
        public OperationResults DeleteShipment(Shipments ship)
        {
            try
            {
                shipment.Delete(ship); // from MySQL database
                return new OperationResults { Success = true, Message = "Shipment Deleted Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Shipment Deletion is failed" };
            }
        }
        public OperationResults<List<Shipments>> GetAllShipments()
        {
            var results = shipment.GetAll();
            if (results == null || results.Count == 0)
            {
                return OperationResults<List<Shipments>>.failure("No Shipments Found");
            }
            return OperationResults<List<Shipments>>.success(results, "Shipments are retrieved");
        }
        public OperationResults<Shipments> FindShipment(int ship_id)
        {
            var result = shipment.Find(ship_id); // from MySQL database
            if (result == null)
            {
                return OperationResults<Shipments>.failure("Shipment with id: " + ship_id + " is not found");
            }
            return OperationResults<Shipments>.success(result, "Shipment with id: " + ship_id + " is found");
        }
        //-------------------------------

    }
    //-------------------------------------------------------------
    // Communication Service Class:
    public class CommunicationService
    {
        // Data Fields:
        private GeneralFunctions<CommunicationConfiguration> communication;
        //-----------------------------------------
        // Constructor:
        public CommunicationService(GeneralFunctions<CommunicationConfiguration> communication)
        {
            this.communication = communication;
        }
        //---------------------------
        // Methods:
        public OperationResults AddCommunicationConfig(CommunicationConfiguration C)
        {
            try
            {
                communication.ADD(C); // to MySQL database
                return new OperationResults { Success = true, Message = "Communication record is stored successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Communication record Storing is failed" };
            }
        }
        public OperationResults DeleteCommunicationConfig(CommunicationConfiguration communication_to_delete)
        {
            try
            {
                communication.Delete(communication_to_delete); // from MySQL database
                return new OperationResults { Success = true, Message = "Communication record is deleted successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Communication deletion is failed" };
            }
        }
        public OperationResults<List<CommunicationConfiguration>> GetAllCommunicationConfigs()
        {
           var results = communication.GetAll();
            if(results == null || results.Count ==0)
            {
                return OperationResults<List<CommunicationConfiguration>>.failure("No records found");
            }
            return OperationResults<List<CommunicationConfiguration>>.success(results, "Records retrieved successfully");
        }
        //---------------------------
    }
    //------------------------------------------------------------
    // Actuator Service Class:
    public class ActuatorService
    {
        // Data Fields:
        private ActuatorInterface actuatorinterface;
        //----------------------
        // Constructor:
        public ActuatorService(ActuatorInterface item)
        {
            this.actuatorinterface = item;
        }
        //-------------------------
        // Methods:
        public bool checkstatus(Actuator a)
        {
            var actuator = a;
            return actuatorinterface.IsActive(actuator);
        }
        public void ActivateActuator(Actuator a)
        {
            var actuator = a;
            actuatorinterface.Activate(actuator); // remember to set the actuator 
        }
        public void DeactivateActuator(Actuator a)
        {
            var actuator = a;
            actuatorinterface.Deactivate(actuator);
        }
        //-----------------------------
    }
    //---------------------------------------------------
    // Sensor Service Class:
    public class SensorService
    {
        // Data Fields:
        private SensorInterface sensor;
        //--------------
        //Constructor:
        public SensorService(SensorInterface item)
        {
            this.sensor = item;
        }
        //-----------------------------
        // Methods:
        public float ReadSensorValue(Sensors s)
        {
            var sensor_item = s;
            return sensor.ReadValue(sensor_item);
        }
        public void CalibrateSensor(Sensors s)
        {
            var sensor_item = s;
            sensor.Calibrate(sensor_item);
        }
        public bool IsSensorOperational(Sensors s)
        {
            var sensor_item = s;
            return sensor.IsOperational(sensor_item);
        }
        //-----------------------------
    }
    //-----------------------------------------------------------
    // Destination Service Class:
  public class DestinationService
    {
        // Data Fields:
        private GeneralFunctions<Destination> destination;
        //---------------------------------
        // Constructor:
        public DestinationService(GeneralFunctions<Destination> destination)
        {
            this.destination = destination;
        }
        //------------------------------
        // Methods:
        public OperationResults AddNewDestination(Destination d)
        {
            try
            {
                destination.ADD(d);
                return new OperationResults { Success = true, Message = " Destination is created successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Destination creation failed" };
            }
        }
        public OperationResults RemoveDestination(Destination d)
        {
            try
            {
                destination.Delete(d);
                return new OperationResults { Success = true, Message = "Destination is deleted successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Destination deletion failed" };
            }
        }
        public OperationResults<List<Destination>> GetDestinationList()
        {
            var results = destination.GetAll();
            if(results.Count == 0 || results == null)
            {
                return OperationResults<List<Destination>>.failure("No destination found");
            }
            return OperationResults<List< Destination>>.success(results, "Destinations are retrieved");
        }
        public OperationResults EditDestination(Destination d)
        {
            try
            {
                destination.Update(d);
                return new OperationResults { Success = true, Message = "Destinaton Updated Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Destination Update Failed" };
            }
        }
        public OperationResults<Destination> FindDestination(int id)
        {
            var result = destination.Find(id);
            if(result == null)
            {
                return OperationResults<Destination>.failure("Destination with id: " + id + " is not found");
            }
            return OperationResults<Destination>.success(result, "Destination with id: " + id + " is found");
        }
        //------------------------------------
    }
    //-----------------------------------------------------
    // Weighing Module Class:
    public class WeighingModuleService
    {
        // Data fields:
        private GeneralFunctions<WeighingModule> weighingModule;
        //------------------------------
        //Constructor:
        public WeighingModuleService(GeneralFunctions<WeighingModule> weighingModule)
        {
            this.weighingModule = weighingModule;
        }
        //------------------------------
        // Methods:
        public OperationResults AddNewConfiguration(WeighingModule w)
        {
            try
            {
                weighingModule.ADD(w);
                return new OperationResults { Success = true, Message = "Weighing Configuration is Saved Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Weighing Configuartion Saving is failed" };
            }
        }
        public OperationResults DeleteConfiguration(WeighingModule w)
        {
            try
            {
                weighingModule.Delete(w);
                return new OperationResults { Success = true, Message = "Weighing Configuration deletion is done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Weighing Configuration Deletion is failed" };
            }
        }
        public OperationResults EditConfiguration(WeighingModule w)
        {
            try
            {
                weighingModule.Update(w);
                return new OperationResults { Success = true, Message = "Weighing Configuration Update done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Weighing Configuration Update failed" };
            }
        }
        //-------------------------------
    }
    //------------------------------------------------------------
    // Discharge Module Service Class:
    public class DischargeModuleService
    {
        // Data Fields:
        private GeneralFunctions<DischargingModule> dischargeModule;
        //--------------------------
        // Constructor:
        public DischargeModuleService(GeneralFunctions<DischargingModule> dischargeModule)
        {
            this.dischargeModule = dischargeModule;
        }
        //-----------------------
        // Methods:
        public OperationResults AddNewConfiguration(DischargingModule D)
        {
            try
            {
                dischargeModule.ADD(D);
                return new OperationResults { Success = true, Message = "Discharge Configuration is Saved Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Discharge Configuration Saving Failed" };
            }
        }
        public OperationResults DeleteConfiguration(DischargingModule D)
        {
            try
            {
                dischargeModule.Delete(D);
                return new OperationResults { Success = true, Message = "Configuartion Deletion is done Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Configuration Deletion Failed" };
            }
        }
        public OperationResults EditConfiguration(DischargingModule D)
        {
            try
            {
                dischargeModule.Update(D);
                return new OperationResults { Success = true, Message = "Configuration Update is done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Configuration Update is failed" };
            }
        }
        //---------------------------
    }
    //---------------------------------------------------------------
    // Mixing Module Service Class:
    public class MixingModuleService
    {
        // Data Fields:
        private GeneralFunctions<MixingModule> mixingModule;
        //---------------
        // Constructor:
        public MixingModuleService(GeneralFunctions<MixingModule> mixingModule)
        {
            this.mixingModule = mixingModule;
        }
        //---------------------------
        // Methods:
        public OperationResults AddNewConfiguration(MixingModule m)
        {
            try
            {
                mixingModule.ADD(m);
                return new OperationResults { Success = true, Message = "Module Configuration is saved successfully" };
            }
            catch
            {
                return new OperationResults { Success = true, Message = "Module Configuration is not saved" };
            }
        }
        public OperationResults DeleteConfiguration(MixingModule m)
        {
            try
            {
                mixingModule.Delete(m);
                return new OperationResults { Success = true, Message = " Configuration Deletion is done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Configuration Deletion is not saved" };
            }
        }
        public OperationResults EditConfiguration(MixingModule m)
        {
            try
            {
                mixingModule.Update(m);
                return new OperationResults { Success = true, Message = "Configuration Update is done Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Configuration Update is failed" };
            }
        }
        //------------------------------
    }
    //---------------------------------------------------------------------
    // Product Service Class:
    public class ProductService
    {
        // Data Fields:
        private GeneralFunctions<Products> product;
        //----------------------
        // Constructor:
        public ProductService(GeneralFunctions<Products> p)
        {
            this.product = p;
        }
        //--------------------------
        // Methods:
        public OperationResults AddNewProduct(Products p)
        {
            try
            {
                product.ADD(p);
                return new OperationResults { Success = true, Message = "Product Created Successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Product creation is failed" };
            }
        }
        public OperationResults DeleteProduct(Products p)
        {
            try
            {
                product.Delete(p);
                return new OperationResults { Success = true, Message = "Product Deletion is done successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Product Deletion is failed" };
            }
        }
        public OperationResults<List<Products>> GetAllProducts()
        {
            var results = product.GetAll(); 
            if (results == null || results.Count == 0)
            {
                return OperationResults<List<Products>>.failure("No products found");
            }
            return OperationResults<List<Products>>.success(results, "Products are retrieved successfully");
        }
        public OperationResults<Products> FindProduct(int id)
        {
            var results = product.Find(id);
            if (results == null)
            {
                return OperationResults<Products>.failure("Product with id: " + id + " is not found");
            }
            return OperationResults<Products>.success(results, "Product with id: " + id + " is not found");
        }
        public OperationResults<Products> FindProduct(string s)
        {
            var results = product.Find(s); 
            if (results == null)
            {
                return OperationResults<Products>.failure("Product with name: " + s + " is not found");
            }
            return OperationResults<Products>.success(results, "Product with name: " + s + " is found");
        }
        //------------------------
    }
    //--------------------------------------------------------
    // Login Service Class:
    public class LoginFormService
    {
        // Data Fields:
        private GeneralFunctions<LoginForm> loginForm;
        //-----------------
        // Constructor:
        public LoginFormService(GeneralFunctions<LoginForm> loginForm)
        {
            this.loginForm = loginForm;
        }
        //-----------------------------------
        // Methods:
        public OperationResults AddLogin(LoginForm l)
        {
            try
            {
                loginForm.ADD(l);
                return new OperationResults { Success = true, Message = " Login Data is Saved" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Login Data is not Saved" };
            }
        }
        public OperationResults DeleteLogin(LoginForm l)
        {
            try
            {
                loginForm.Delete(l);
                return new OperationResults { Success = true, Message = "Data is deleted successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Data deletion is failed" };
            }
        }
        public OperationResults<List<LoginForm>> GetAllLogins()
        {
            var results =  loginForm.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<LoginForm>>.failure("No data is found");
            }
            return OperationResults<List<LoginForm>>.success(results, "data is retrieved suuccessfully");
        }
        //----------------------------------------
    }
    //-----------------------------------------------------------------------
    // Material Data Service Class:
    public class MaterialDataService
    {
        // Data Fields:
        private GeneralFunctions<MaterialsData> material;
        //-----------------------
        //Constructor:
        public MaterialDataService(GeneralFunctions<MaterialsData> material)
        {
            this.material = material;
        }
        //---------------------------------------
        // Methods:
        public OperationResults AddNewData(MaterialsData m)
        {
            try
            {
                material.ADD(m);
                return new OperationResults { Success = true, Message = "Material Data saved successfully" };
            }
            catch 
            {
                return new OperationResults { Success = false, Message = "Material Data is not saved" };
            }
        }
        public OperationResults RemoveMaterial(MaterialsData m)
        {
            try
            {
                material.Delete(m);
                return new OperationResults { Success = true, Message = "Material deletion is done" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = " Material deletion is not done" };
            }
        }
        public OperationResults<List<MaterialsData>> GetAllMaterials()
        {
            var results = material.GetAll();
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<MaterialsData>>.failure("No materials found");
            }
            return OperationResults<List<MaterialsData>>.success(results, "Materials Retrieved Successfully");
        }
        public OperationResults EditMaterial(MaterialsData m)
        {
            try
            {
                material.Update(m);
                return new OperationResults { Success = true, Message = " Material data updated successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Material data update failed" }; 
            }
        }
        public OperationResults<MaterialsData> FindMaterial(int id)
        {
            var result = material.Find(id);
            if (result == null)
            {
                return OperationResults<MaterialsData>.failure("Material with id: " + id + " is not found");
            }
            return OperationResults<MaterialsData>.success(result, "Material with id: " + id + "is found");
        }
        public OperationResults<MaterialsData> FindMaterial(string name)
        {
            var results = material.Find(name);
            if (results == null)
            {
                return OperationResults<MaterialsData>.failure("Material with name: " + name + " is not found");
            }
            return OperationResults<MaterialsData>.success(results, "Material with name: "+name+" is found");
        }
        //--------------------------------
    }
    //------------------------------------------------------
    // Material Tracking Service Class:
    public class MaterialTrackingService
    {
        // Data Fields:
        private GeneralFunctions<MaterialTracking> material_record;
        //--------------------------------
        // Constructor:
        public MaterialTrackingService(GeneralFunctions<MaterialTracking> record)
        {
            this.material_record = record;
        }
        //----------------------------------
        // Methods:
        public OperationResults AddNewRecord(MaterialTracking m)
        {
            try
            {
                material_record.ADD(m);
                return new OperationResults { Success = true, Message = "Record is saved successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = "Recors is not saved" };
            }
        }
        public OperationResults DeleteRecord(MaterialTracking m)
        {
            try
            {
                material_record.Delete(m);
                return new OperationResults { Success = true, Message = "Record is deleted successfully" };
            }
            catch
            {
                return new OperationResults { Success = false, Message = " Record deletion is failed" };
            }
        }
        public OperationResults<List<MaterialTracking>> GetAllTracks()
        {
            var results = material_record.GetAll();
            if (results == null || results.Count == 0)
            {
                return OperationResults<List<MaterialTracking>>.failure("No records found");
            }
            return OperationResults<List<MaterialTracking>>.success(results, "Records are retrieved");
        }
        public OperationResults<MaterialTracking> FindRecord(int id)
        {
            var result = material_record.Find(id);
            if(result == null)
            {
                return OperationResults<MaterialTracking>.failure("Record with id: " + id + " is not found");
            }
            return OperationResults<MaterialTracking>.success(result, "Record with id: " + id + " is found");
        }
        public OperationResults<List<MaterialTracking>> FilterRecords(string start_time_end_time)
        {
            var results = material_record.Filter(start_time_end_time);
            if(results == null || results.Count == 0)
            {
                return OperationResults<List<MaterialTracking>>.failure("no data exists within this range");
            }
            return OperationResults<List<MaterialTracking>>.success(results, "filtertion done successfully");
        }
        //-----------------------------------------
    }
    //---------------------------------------------------------------------
    // Producion Service Class:
    public class ProductionService
    {
        // Production service will handle the production process.
    }
    //---------------------------------------------------
    // Report Service Class:
    public class ReportService
    {
        // Data Fields:
        private OrderService order;  // to generate reports about orders.
        private OrderLinesService orderLines; 
        private ShipmentsService shipments;
        private ClientService client; // to generate reports about clients.
        private ProductService product; // to generate reports about products.
        private MaterialTrackingService materialTracking; // to generate reports about material tracking.
        private MaterialDataService materialdata; // to generate reports about materials data.
        private LoginFormService login;
        private EmployeeService employee; // to generate reports about employees.
        private CommunicationService communication; // to generate reports about communication configurations.
        private AlarmService alarm; // to generate reports about alarms.
        private SupplierService supplier; // to generate reports about suppliers.
        private TruckService truck; // to generate reports about trucks.
        private DriverService driver; // to generate reports about drivers.
        private FormulaService formula; // to generate reports about formulas.
        private ComponentsService components; // to generate reports about components.
        private ProductionService production; // to generate reports about production.
        private DestinationService destination; // to generate reports about destinations.
        //------------------------------------
        // Constructor:
        public ReportService()
        {
        }
        //----------------------------------
        // initializing Methods for each service class:
        public void InitializeOrderService(OrderService o)
        {
            this.order = o;
        }
        public void InitialzeLineService(OrderLinesService o)
        {
            this.orderLines = o;
        }
        public void InitializeShipmentService(ShipmentsService s)
        {
            this.shipments = s;
        }
        public void InitializeClientService(ClientService c)
        {
            this.client = c;
        }
        public void InitializeProductService(ProductService p)
        {
            this.product = p;
        }
        public void InitializeMaterialTrackingService(MaterialTrackingService m)
        {
            this.materialTracking = m;
        }
        public void InitializeLoginFormService(LoginFormService l)
        {
            this.login = l;
        }
        public void InitializeEmployeeService(EmployeeService e)
        {
            this.employee = e;
        }
        public void InitializeCommunicationService(CommunicationService c)
        {
            this.communication = c;
        }
        public void InitializeAlarmService(AlarmService a)
        {
            this.alarm = a;
        }
        public void InitializeSupplierService(SupplierService s)
        {
            this.supplier = s;
        }
        public void InitializeTruckService(TruckService t)
        {
            this.truck = t;
        }
        public void InitializeDriverService(DriverService d)
        {
            this.driver = d;
        }
        public void InitializeFormulaService(FormulaService f)
        {
            this.formula = f;
        }
        public void InitializeComponentsService(ComponentsService c)
        {
            this.components = c;
        }
        public void InitializeProductionService(ProductionService p)
        {
            this.production = p;
        }
        public void InitializeDestinationService(DestinationService d)
        {
            this.destination = d;
        }
        //---------------------------------
        // Methods to generate reports: 
        public ClientOrderReportDTOs GenerateClientReport(int client_id, DateTime? Start_Date = null, DateTime? Finish_Date = null)
        {
            var orders_results = order.GetAllOrders();
            var lines_results = orderLines.GetAllLines();
            var Lines = lines_results.data;
            var shipments_results = shipments.GetAllShipments();
            var ships = shipments_results.data;
            List<Order> orders = new List<Order>();
            if (orders_results != null && orders_results.data != null)
            {
                orders = orders_results.data.Where(o => o.getClient_ID() == client_id).ToList();
            }
            // will handle exception later
            if(lines_results != null && lines_results.data != null)
            {
                var orderIds = orders.Select(o => o.getID()).ToList();
                Lines = lines_results.data.Where(l => orderIds.Contains(l.getOrder_ID())).ToList();
            }
            // will handle exception later
            if (shipments_results != null && shipments_results.data != null)
            {
                var lineIds = Lines.Select(o => o.getOrder_Line_ID()).ToList();
                ships = shipments_results.data.Where(s => lineIds.Contains(s.getLine_ID())).ToList();
            }
            // will handle exception later

            var client_result = client.FindClient(client_id);
              var clients = client_result.data;
            // just if a time persiod is specified:
            if (Start_Date != null && Finish_Date != null)
            {
                orders = orders.Where(o => o.getIssue_Date() >= Start_Date && o.getIssue_Date() <= Finish_Date).ToList();
                var orderIds = orders.Select(o => o.getID()).ToList();
                Lines = lines_results.data.Where(l => orderIds.Contains(l.getOrder_ID())).ToList();
                var lineIds = Lines.Select(o => o.getOrder_Line_ID()).ToList();
                ships = shipments_results.data.Where(s => lineIds.Contains(s.getLine_ID())).ToList();
            }
            //-----------------------------------------
            var trucks_results = truck.GetAllTrucks();
            var trucks = trucks_results.data;
            var drivers_results = driver.GetAllDrivers();
            var drivers = drivers_results.data;
            var destinations_results = destination.GetDestinationList();
            var destinations = destinations_results.data;
            var Employees_results = employee.GetAllEmployees();
            var Employees = Employees_results.data;
            var materials_results = materialTracking.GetAllTracks();
            var materials = materials_results.data;
            var products_results = product.GetAllProducts();
            var products = products_results.data;
            var formulas_results = formula.GetAllFormulas();
            var formulas = formulas_results.data;
            var Report = new ClientOrderReportDTOs();
            Report.Clients = clients;
            foreach (Order v in orders)
            {
                Report.Orders.Add(v);
                var shipIds = ships.Select(s => s.getTruck_ID()).ToList();
                var matchedTruck = trucks.FirstOrDefault(tr => shipIds.Contains(tr.getTruck_ID()));
                if (matchedTruck != null)
                {
                    Report.Trucks.Add(matchedTruck);
                    var matchedDriver = drivers.FirstOrDefault(dr => dr.getID() == matchedTruck.getDriver_ID());
                    if (matchedDriver != null)
                    {
                        Report.Drivers.Add(matchedDriver);
                    }
                    else
                    {
                        Report.NullValues.Add("No Driver Assigned");
                    }
                }
                else
                {
                    Report.NullValues.Add("No Truck Assigned");
                    Report.NullValues.Add("No Driver Assigned");
                }
                var linesids = Lines.Select( l => l.getDestination_Id()).ToList(); 
                var matchedDestination = destinations.FirstOrDefault(ds => linesids.Contains(ds.getDestination_ID()));
                if (matchedDestination != null)
                {
                    Report.Destinations.Add(matchedDestination);
                }
                else
                {
                    Report.NullValues.Add("No Destination Assigned");
                }
                var shipId = ships.Select(s => s.getEmployee_ID()).ToList();
                var matchedEmployee = Employees.FirstOrDefault(e => shipId.Contains(e.getID()));
                if (matchedEmployee != null)
                {
                    Report.Employees.Add(matchedEmployee);
                }
                else
                {
                    Report.NullValues.Add("No Employee Assigned");
                }
                var shipsCode = ships.Select(s => s.getFormula_Code()).ToList();
                var matchedFormula = formulas.FirstOrDefault(f => shipsCode.Contains(f.getFormulaCode()));
                if (matchedFormula != null)
                {
                    Report.Formulas.Add(matchedFormula);
                }
                else
                {
                    Report.NullValues.Add("No Formula Assigned");
                }
                var shipment_product = ships.Select(s => s.getProduct_Id()).ToList();
                var matchedProduct = products.FirstOrDefault(p => shipment_product.Contains(p.getProduct_ID()));
                if (matchedProduct != null)
                {
                    Report.Products.Add(matchedProduct);
                }
                else
                {
                    Report.NullValues.Add("No Product Assigned");
                }

            }
            return Report;
        }
        //--------------------------------
        // Material Report:
        public List<MaterialReportDTOs> GenerateMaterialsReport(DateOnly? Start_Date = null, DateOnly? End_Date = null)
        {
            var Materials_results = materialdata.GetAllMaterials(); // definitions from Material_Data table
            var Materials = Materials_results.data;
            var Tracks_Results = materialTracking.GetAllTracks();   // records from Material_Tracking table
            var Tracks = Tracks_Results.data;
            var suppliers_results = supplier.GetAllSuppliers();
            var suppliers = suppliers_results.data;
            var Compute_Rate = false;
            float avgConsumption_rate = 0.0f;

            // Apply date filter if needed:
            if (Start_Date != null && End_Date != null)
            {
                Compute_Rate = true;
                Tracks = Tracks
                    .Where(m => m.getReceive_Date() >= Start_Date && m.getReceive_Date() <= End_Date)
                    .ToList();
            }
            //-----------------------------------------
            var Report = new List<MaterialReportDTOs>();
            foreach (var material in Materials)
            {
                var tracks = Tracks.Where(t => t.getMaterialID() == material.getMaterial_ID()).ToList();

                if (!tracks.Any())
                    continue; // skip materials with no usage

                int usageCount = tracks.Count;
                float avgConsumption = tracks.Average(t => t.getConsumed_Quantity());
                // calculate average consumption rate if date filter is applied
                if (Compute_Rate)
                {
                    var totaldays = (End_Date.Value.ToDateTime(TimeOnly.MinValue) - Start_Date.Value.ToDateTime(TimeOnly.MinValue)).Days + 1; // inclusive of both start and end dates
                    avgConsumption_rate = usageCount > 0 ? (avgConsumption / totaldays) : 0;
                }

                // pick first supplier 
                var firstTrack = tracks.First();
                var matchedSupplier = suppliers.FirstOrDefault(s => s.getID() == firstTrack.getSupplier_ID());

                Report.Add(new MaterialReportDTOs
                {
                    Material_Name = material.getName(),
                    Unit = material.getUnit(),
                    Cost_Per_Unit = material.getCost(),
                    Usage_Count = usageCount,
                    Average_Consumed_Quantity = avgConsumption,
                    Average_Consumption_Rate = avgConsumption_rate,
                    Supplier_Name = matchedSupplier?.getName() ?? "Unknown",
                    Supplier_Address = matchedSupplier?.getLocation() ?? "N/A",
                    Supplier_Email = matchedSupplier?.getEmail() ?? "N/A",
                    Supplier_Phone = matchedSupplier.getPhone_No()
                });
            }
            return Report;
        }
        //--------------------------------
        // Truck Report:
        public TruckReportDTOs GenerateTruckReport(int truck_id, DateTime? Start_Date = null, DateTime? End_Date = null)
        {
            var trucks_results = truck.FindTruck(truck_id);
            var trucks = trucks_results.data;
            var shipments_results = shipments.GetAllShipments();
            var ship = shipments_results.data;
            var drivers_results = driver.GetAllDrivers();
            var drivers = drivers_results.data;
            ship = ship.Where(s => s.getTruck_ID() == trucks.getTruck_ID()).ToList();

            if (trucks.getDriver_ID() != 0)
            {
                drivers = drivers.Where(dr => dr.getID() == trucks.getDriver_ID()).ToList();
            }
            else
            {
                throw new Exception("No Driver Assigned to this Truck: " + trucks.getTruck_ID());
            }
            // just if a time persiod is specified: 
            if (Start_Date != null && End_Date != null)
            {
                ship = ship.Where(o => o.getDepature_Time() >= Start_Date && o.getDepature_Time() <= End_Date).ToList();
            }
            //-----------------------------------------
            var Report = new TruckReportDTOs();

            Report.Truck_ID = trucks.getTruck_ID();
            Report.Truck_Plate = trucks.getTruck_Plate();
            Report.Truck_Capacity = trucks.getTruck_Capacity();
            Report.License_Issue_Date = trucks.getLicense_Issue_Date();
            Report.License_Expiry_Date = trucks.getLicense_Expiry_Date();
            foreach (var d in drivers)
            {
                Report.Driver_ID = d.getID();
                Report.Driver_Name = d.getName();
                Report.Driver_Phone = d.getPhone_No();
                Report.Driver_Address = d.getAddress();
                Report.Driver_License_Issue_Date = d.getIssue_Date();
                Report.Driver_License_Expiry_Date = d.getExpiry_Date();
            }
            Report.Number_of_Uses = ship.Count;
            return Report;
        }
        //--------------------------------
        // Product Report:
        public ProductReportDTOs GenerateProductReport(int product_id, DateTime? start_date = null, DateTime? end_date = null)
        {
            var products_results = product.FindProduct(product_id);
            var products = products_results.data;
            var clients_results = client.GetAllClients(); 
            var clients = clients_results.data;
             clients = clients.Where(c => c.getID() == products.getClient_ID()).ToList();
            var formulas_results = formula.FindFormula(products.getFormula_Code());
            var formulas = formulas_results.data;
            var ships_results = shipments.GetAllShipments();
            var ships = ships_results.data;
            ships = ships.Where(s => s.getProduct_Id() == products.getProduct_ID()).ToList();
            var order_results = order.GetAllOrders();
            var orders = order_results.data;
            // just if a time persiod is specified:
            if (start_date != null && end_date != null)
            {
                orders = orders.Where(o => o.getStart_Time() >= start_date && o.getStart_Time() <= end_date).ToList();
            }
            //-----------------------------------------
            var Report = new ProductReportDTOs();
            Report.Product_ID = products.getProduct_ID();
            Report.Product_Name = products.getProduct_Name();
            Report.Product_Description = products.getDescription();
            Report.Product_Specifications = products.getSpecifications();
            Report.Product_Code = products.getCode();
            Report.Number_of_Requests = orders.Count;
            foreach (var c in clients)
            {
                Report.Client_ID = c.getID();
                Report.Client_Name = c.getName();
                Report.Client_Email = c.getEmail();
                Report.Client_Company = c.getCompany();
            }
            Report.Formula_Code = formulas.getFormulaCode();
            Report.Concrete_Grade = formulas.getConcrete_Grade();
            return Report;
        }
        //--------------------------------
        // Components Report:
        public List<ComponentDTOs> GenerateComponentsReport()
        {
            var components_results = components.GetAllComponents();
            var componentsList = components_results.data;
            var suppliers_results = supplier.GetAllSuppliers();
            var suppliers = suppliers_results.data;

            var Report = new List<ComponentDTOs>();
            foreach (var component in componentsList)
            {
                suppliers = suppliers.Where(s => s.getID() == component.getSupplier_Id()).ToList();
                Report.Add(new ComponentDTOs
                {
                    Component_ID = component.getID(),
                    Component_Name = component.getName(),
                    Component_Cost = component.getCost(),
                    Component_State = component.getState(),
                    Purchasing_Date = component.getPurchasing_Date(),
                    Supplier_Name = suppliers.FirstOrDefault()?.getName() ?? "Unknown",
                    Supplier_ID = suppliers.FirstOrDefault()?.getID() ?? 0,
                    Supplier_Email = suppliers.FirstOrDefault()?.getEmail() ?? "N/A",
                    Supplier_Location = suppliers.FirstOrDefault()?.getLocation() ?? "N/A",
                    Supplier_State = suppliers.FirstOrDefault()?.getState() ?? "N/A"
                });
            }
            return Report;
        }
        //--------------------------------
        // Employee Report: 
        public List<EmployeeReportDTOs> GenerateEmployeeReport()
        {
            var employees_results = employee.GetAllEmployees();
            var employees = employees_results.data;
            var Orders_results = order.GetAllOrders();
            var orders = Orders_results.data;
            var shipment_results = shipments.GetAllShipments();
            var ships = shipment_results.data;  
            var Logins_results = login.GetAllLogins();
            var Logins = Logins_results.data;

            var Report = new List<EmployeeReportDTOs>();

            foreach (var emp in employees)
            {
                // filter individually for each employee
                var employeeLogins = Logins
                    .Where(l => l.getLogin_Email() == emp.getWork_Email())
                    .ToList();

                var employeeOrders = ships
                    .Where(s => s.getEmployee_ID() == emp.getID())
                    .ToList();

                var lastLogin = employeeLogins
                    .OrderByDescending(l => l.getLogin_Date())
                    .ThenByDescending(l => l.getLogin_Time())
                    .FirstOrDefault();

                Report.Add(new EmployeeReportDTOs
                {
                    Employee_ID = emp.getID(),
                    Employee_Name = emp.getName(),
                    Employee_Work_Email = emp.getWork_Email(),
                    Employee_Phone = emp.getPhone_No(),
                    Employee_Address = emp.getAddress(),
                    Employee_Role = emp.getJob_Title(),
                    Employee_Age = emp.getAge(),
                    Employee_Salary = emp.getSalary(),
                    Employee_Bonus = emp.getBonus(),
                    Employee_Total_Salary = emp.getTotal_Salary(),
                    Employee_Status = emp.getStatus(),

                    Total_Logins = employeeLogins.Count,
                    Last_Login_Date = lastLogin.getLogin_Date(),
                    Last_Login_Time = lastLogin.getLogin_Time(),

                    Total_Orders_Handled = employeeOrders.Count
                });
            }
            return Report;
        }
        //--------------------------------
        // Alarm Report:
        public List<AlarmReportDTOs> GenerateAlarmReport(DateOnly? Start_Date = null, DateOnly? End_Date = null)
        {
            var Alarms_results = alarm.GetAllAlarms();
            var Alarms = Alarms_results.data;
            var Orders_results = order.GetAllOrders(); // to link alarms to orders if needed in the future.
            var orders = Orders_results.data;
            // Apply date filter if needed:
            if (Start_Date != null && End_Date != null)
            {
                Alarms = Alarms
                    .Where(a => a.getOccurance_Date() >= Start_Date && a.getOccurance_Date() <= End_Date)
                    .ToList();
            }
            else if (Start_Date != null && End_Date == null)
            {
                Alarms = Alarms
                    .Where(a => a.getOccurance_Date() >= Start_Date)
                    .ToList();
            }
            else if (Start_Date == null && End_Date != null)
            {
                Alarms = Alarms
                    .Where(a => a.getOccurance_Date() <= End_Date)
                    .ToList();
            }
            // if both are null, return all alarms
            //-----------------------------------------
            var Report = new List<AlarmReportDTOs>();
            foreach (var a in Alarms)
            {
                Report.Add(new AlarmReportDTOs
                {
                    Alarm_ID = a.getID(),
                    Alarm_Name = a.getName(),
                    Alarm_Date = a.getOccurance_Date(),
                    Alarm_Time = a.getOccurance_Time()
                });
            }
            return Report;
        }
        //---------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------
}