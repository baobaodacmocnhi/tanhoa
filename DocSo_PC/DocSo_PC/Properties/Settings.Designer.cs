﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocSo_PC.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HP_G7\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;Use" +
            "r ID=sa;Password=db8@tanhoa")]
        public string CAPNUOCTANHOAConnectionString {
            get {
                return ((string)(this["CAPNUOCTANHOAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=server9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=" +
            "sa;Password=db9@tanhoa")]
        public string HOADON_TAConnectionString {
            get {
                return ((string)(this["HOADON_TAConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=serverg8-01;Initial Catalog=TRUNGTAMKHACHHANG;Persist Security Info=T" +
            "rue;User ID=sa;Password=db11@tanhoa")]
        public string TRUNGTAMKHACHHANGConnectionString {
            get {
                return ((string)(this["TRUNGTAMKHACHHANGConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://serverg8-01:81/wsthutien.asmx")]
        public string DocSo_PC_wrThuTien_wsThuTien {
            get {
                return ((string)(this["DocSo_PC_wrThuTien_wsThuTien"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://serverg8-01:81/wsdhn.asmx")]
        public string DocSo_PC_wrDHN_wsDHN {
            get {
                return ((string)(this["DocSo_PC_wrDHN_wsDHN"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=hp_g7\\kd;Initial Catalog=DocSoTH;Persist Security Info=True;User ID=s" +
            "a;Password=db8@tanhoa")]
        public string DocSoTHConnectionString {
            get {
                return ((string)(this["DocSoTHConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://serverg8-01:81/wsthuongvu.asmx")]
        public string DocSo_PC_wrThuongVu_wsThuongVu {
            get {
                return ((string)(this["DocSo_PC_wrThuongVu_wsThuongVu"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=serverg8-01;Initial Catalog=KTKS_DonKH;Persist Security Info=True;Use" +
            "r ID=sa;Password=db11@tanhoa")]
        public string KTKS_DonKHConnectionString {
            get {
                return ((string)(this["KTKS_DonKHConnectionString"]));
            }
        }
    }
}
