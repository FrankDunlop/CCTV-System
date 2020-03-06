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
// Generation date: 03/03/2020 18:07:01
namespace DAL.EF
{
    
    /// <summary>
    /// There are no comments for DVREntities in the schema.
    /// </summary>
    public partial class DVREntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new DVREntities object using the connection string found in the 'DVREntities' section of the application configuration file.
        /// </summary>
        public DVREntities() : 
                base("name=DVREntities", "DVREntities")
        {
            OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DVREntities object.
        /// </summary>
        public DVREntities(string connectionString) : 
                base(connectionString, "DVREntities")
        {
            OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DVREntities object.
        /// </summary>
        public DVREntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "DVREntities")
        {
            OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for CamSettings in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<CamSetting> CamSettings
        {
            get
            {
                if ((_CamSettings == null))
                {
                    _CamSettings = base.CreateQuery<CamSetting>("[CamSettings]");
                }
                return _CamSettings;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<CamSetting> _CamSettings;
        /// <summary>
        /// There are no comments for Logs in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<Log> Logs
        {
            get
            {
                if ((_Logs == null))
                {
                    _Logs = base.CreateQuery<Log>("[Logs]");
                }
                return _Logs;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<Log> _Logs;
        /// <summary>
        /// There are no comments for CamSettings in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToCamSettings(CamSetting camSetting)
        {
            base.AddObject("CamSettings", camSetting);
        }
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
    /// There are no comments for DVRModel.CamSetting in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CamNum
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DVRModel", Name="CamSetting")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class CamSetting : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new CamSetting object.
        /// </summary>
        /// <param name="camNum">Initial value of CamNum.</param>
        /// <param name="blackTest">Initial value of BlackTest.</param>
        /// <param name="textBottom">Initial value of TextBottom.</param>
        /// <param name="motionDetectEnabled">Initial value of MotionDetectEnabled.</param>
        /// <param name="recOnMotion">Initial value of RecOnMotion.</param>
        /// <param name="recSeconds">Initial value of RecSeconds.</param>
        /// <param name="sensitivity">Initial value of Sensitivity.</param>
        /// <param name="privacyEnabled">Initial value of PrivacyEnabled.</param>
        /// <param name="privacySelected">Initial value of PrivacySelected.</param>
        /// <param name="showTimeDate">Initial value of ShowTimeDate.</param>
        /// <param name="fPS">Initial value of FPS.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static CamSetting CreateCamSetting(int camNum, bool blackTest, bool textBottom, bool motionDetectEnabled, bool recOnMotion, int recSeconds, int sensitivity, bool privacyEnabled, bool privacySelected, bool showTimeDate, int fPS)
        {
            CamSetting camSetting = new CamSetting();
            camSetting.CamNum = camNum;
            camSetting.BlackTest = blackTest;
            camSetting.TextBottom = textBottom;
            camSetting.MotionDetectEnabled = motionDetectEnabled;
            camSetting.RecOnMotion = recOnMotion;
            camSetting.RecSeconds = recSeconds;
            camSetting.Sensitivity = sensitivity;
            camSetting.PrivacyEnabled = privacyEnabled;
            camSetting.PrivacySelected = privacySelected;
            camSetting.ShowTimeDate = showTimeDate;
            camSetting.FPS = fPS;
            return camSetting;
        }
        /// <summary>
        /// There are no comments for property CamNum in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int CamNum
        {
            get
            {
                return _CamNum;
            }
            set
            {
                OnCamNumChanging(value);
                ReportPropertyChanging("CamNum");
                _CamNum = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CamNum");
                OnCamNumChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _CamNum;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCamNumChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCamNumChanged();
        /// <summary>
        /// There are no comments for property CamName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string CamName
        {
            get
            {
                return _CamName;
            }
            set
            {
                OnCamNameChanging(value);
                ReportPropertyChanging("CamName");
                _CamName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CamName");
                OnCamNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CamName;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCamNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCamNameChanged();
        /// <summary>
        /// There are no comments for property BlackTest in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool BlackTest
        {
            get
            {
                return _BlackTest;
            }
            set
            {
                OnBlackTestChanging(value);
                ReportPropertyChanging("BlackTest");
                _BlackTest = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BlackTest");
                OnBlackTestChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _BlackTest;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnBlackTestChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnBlackTestChanged();
        /// <summary>
        /// There are no comments for property TextBottom in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool TextBottom
        {
            get
            {
                return _TextBottom;
            }
            set
            {
                OnTextBottomChanging(value);
                ReportPropertyChanging("TextBottom");
                _TextBottom = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TextBottom");
                OnTextBottomChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _TextBottom;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTextBottomChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTextBottomChanged();
        /// <summary>
        /// There are no comments for property LowRes in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<bool> LowRes
        {
            get
            {
                return _LowRes;
            }
            set
            {
                OnLowResChanging(value);
                ReportPropertyChanging("LowRes");
                _LowRes = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LowRes");
                OnLowResChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<bool> _LowRes;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLowResChanging(global::System.Nullable<bool> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLowResChanged();
        /// <summary>
        /// There are no comments for property MotionDetectEnabled in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool MotionDetectEnabled
        {
            get
            {
                return _MotionDetectEnabled;
            }
            set
            {
                OnMotionDetectEnabledChanging(value);
                ReportPropertyChanging("MotionDetectEnabled");
                _MotionDetectEnabled = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MotionDetectEnabled");
                OnMotionDetectEnabledChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _MotionDetectEnabled;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMotionDetectEnabledChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMotionDetectEnabledChanged();
        /// <summary>
        /// There are no comments for property RecOnMotion in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool RecOnMotion
        {
            get
            {
                return _RecOnMotion;
            }
            set
            {
                OnRecOnMotionChanging(value);
                ReportPropertyChanging("RecOnMotion");
                _RecOnMotion = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RecOnMotion");
                OnRecOnMotionChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _RecOnMotion;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnRecOnMotionChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnRecOnMotionChanged();
        /// <summary>
        /// There are no comments for property RecSeconds in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int RecSeconds
        {
            get
            {
                return _RecSeconds;
            }
            set
            {
                OnRecSecondsChanging(value);
                ReportPropertyChanging("RecSeconds");
                _RecSeconds = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RecSeconds");
                OnRecSecondsChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _RecSeconds;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnRecSecondsChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnRecSecondsChanged();
        /// <summary>
        /// There are no comments for property Sensitivity in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int Sensitivity
        {
            get
            {
                return _Sensitivity;
            }
            set
            {
                OnSensitivityChanging(value);
                ReportPropertyChanging("Sensitivity");
                _Sensitivity = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Sensitivity");
                OnSensitivityChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _Sensitivity;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSensitivityChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSensitivityChanged();
        /// <summary>
        /// There are no comments for property PrivacyEnabled in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool PrivacyEnabled
        {
            get
            {
                return _PrivacyEnabled;
            }
            set
            {
                OnPrivacyEnabledChanging(value);
                ReportPropertyChanging("PrivacyEnabled");
                _PrivacyEnabled = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PrivacyEnabled");
                OnPrivacyEnabledChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _PrivacyEnabled;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnPrivacyEnabledChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnPrivacyEnabledChanged();
        /// <summary>
        /// There are no comments for property PrivacySelected in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool PrivacySelected
        {
            get
            {
                return _PrivacySelected;
            }
            set
            {
                OnPrivacySelectedChanging(value);
                ReportPropertyChanging("PrivacySelected");
                _PrivacySelected = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PrivacySelected");
                OnPrivacySelectedChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _PrivacySelected;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnPrivacySelectedChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnPrivacySelectedChanged();
        /// <summary>
        /// There are no comments for property ShowTimeDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool ShowTimeDate
        {
            get
            {
                return _ShowTimeDate;
            }
            set
            {
                OnShowTimeDateChanging(value);
                ReportPropertyChanging("ShowTimeDate");
                _ShowTimeDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShowTimeDate");
                OnShowTimeDateChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _ShowTimeDate;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnShowTimeDateChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnShowTimeDateChanged();
        /// <summary>
        /// There are no comments for property FPS in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int FPS
        {
            get
            {
                return _FPS;
            }
            set
            {
                OnFPSChanging(value);
                ReportPropertyChanging("FPS");
                _FPS = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FPS");
                OnFPSChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _FPS;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnFPSChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnFPSChanged();
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
                return _ID;
            }
            set
            {
                OnIDChanging(value);
                ReportPropertyChanging("ID");
                _ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID");
                OnIDChanged();
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
                return _Message;
            }
            set
            {
                OnMessageChanging(value);
                ReportPropertyChanging("Message");
                _Message = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Message");
                OnMessageChanged();
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
