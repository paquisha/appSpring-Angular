using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ADReportingTool
{
    public class ModelReportingTool : DbContext
    {
        // Your context has been configured to use a 'ModelReportingTool' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ADReportingTool.ModelReportingTool' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelReportingTool' 
        // connection string in the application configuration file.
        public ModelReportingTool()
            : base("name=ModelReportingTool")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ContactUser> ContactUsers { get; set; }
        public DbSet<AttentionSchedule> AttentionSchedules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Ruc { get; set; }
        public virtual ICollection<ContactUser> ContactUsers { get; set; }
        public virtual ICollection<AttentionSchedule> AttentionSchedules { get; set; }
    }

    public class ContactUser
    {
        public int ContactUserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }

    public class AttentionSchedule
    {
        public int AttentionScheduleID { get; set; }
        public string AttentionScheduleName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Object> Objectss { get; set; }
    }
    public class Object
    {
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
    }

    public class Alert
    {
        public int AlertID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

    public class Notification
    {
        public int NotificationID { get; set; }
        public string AlertName { get; set; }
        public string AlertDescription { get; set; }
        public int Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DestinataryMails { get; set; }
        public string CCMails { get; set; }
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}