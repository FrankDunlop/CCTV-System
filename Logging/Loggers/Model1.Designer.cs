﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 26/07/2017 11:01:22
namespace DVR.Logging
{
    
    /// <summary>
    /// There are no comments for DVREntities1 in the schema.
    /// </summary>
    public partial class DVREntities1 : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new DVREntities1 object using the connection string found in the 'DVREntities1' section of the application configuration file.
        /// </summary>
        public DVREntities1() : 
                base("name=DVREntities1", "DVREntities1")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DVREntities1 object.
        /// </summary>
        public DVREntities1(string connectionString) : 
                base(connectionString, "DVREntities1")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DVREntities1 object.
        /// </summary>
        public DVREntities1(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "DVREntities1")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Logs in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<Log> Logs
        {
            get
            {
                if ((this._Logs == null))
                {
                    this._Logs = base.CreateQuery<Log>("[Logs]");
                }
                return this._Logs;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<Log> _Logs;
        /// <summary>
        /// There are no comments for Logs in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToLogs(Log log)
        {
            base.AddObject("Logs", log);
        }
    }
    /// <summary>
    /// There are no comments for DVRModel.Log in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DVRModel", Name="Log")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Log : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Log object.
        /// </summary>
        /// <param name="id">Initial value of ID.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static Log CreateLog(int id)
        {
            Log log = new Log();
            log.ID = id;
            return log;
        }
        /// <summary>
        /// There are no comments for property ID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnIDChanging(value);
                this.ReportPropertyChanging("ID");
                this._ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIDChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIDChanged();
        /// <summary>
        /// There are no comments for property Message in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this.OnMessageChanging(value);
                this.ReportPropertyChanging("Message");
                this._Message = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Message");
                this.OnMessageChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Message;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMessageChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMessageChanged();
    }
}
