﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace DocSo_PC.wrDHN {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="wsDHNSoap", Namespace="http://tempuri.org/")]
    public partial class wsDHN : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback insertBillingOperationCompleted;
        
        private System.Threading.SendOrPostCallback tinhCodeTieuThu_TieuThuOperationCompleted;
        
        private System.Threading.SendOrPostCallback tinhCodeTieuThu_CSMOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public wsDHN() {
            this.Url = global::DocSo_PC.Properties.Settings.Default.DocSo_PC_wrDHN_wsDHN;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event insertBillingCompletedEventHandler insertBillingCompleted;
        
        /// <remarks/>
        public event tinhCodeTieuThu_TieuThuCompletedEventHandler tinhCodeTieuThu_TieuThuCompleted;
        
        /// <remarks/>
        public event tinhCodeTieuThu_CSMCompletedEventHandler tinhCodeTieuThu_CSMCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insertBilling", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool insertBilling(string DocSoID, string checksum, out string message) {
            object[] results = this.Invoke("insertBilling", new object[] {
                        DocSoID,
                        checksum});
            message = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void insertBillingAsync(string DocSoID, string checksum) {
            this.insertBillingAsync(DocSoID, checksum, null);
        }
        
        /// <remarks/>
        public void insertBillingAsync(string DocSoID, string checksum, object userState) {
            if ((this.insertBillingOperationCompleted == null)) {
                this.insertBillingOperationCompleted = new System.Threading.SendOrPostCallback(this.OninsertBillingOperationCompleted);
            }
            this.InvokeAsync("insertBilling", new object[] {
                        DocSoID,
                        checksum}, this.insertBillingOperationCompleted, userState);
        }
        
        private void OninsertBillingOperationCompleted(object arg) {
            if ((this.insertBillingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insertBillingCompleted(this, new insertBillingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/tinhCodeTieuThu_TieuThu", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool tinhCodeTieuThu_TieuThu(string DocSoID, string Code, int TieuThu, out int GiaBan, out int ThueGTGT, out int PhiBVMT, out int TongCong) {
            object[] results = this.Invoke("tinhCodeTieuThu_TieuThu", new object[] {
                        DocSoID,
                        Code,
                        TieuThu});
            GiaBan = ((int)(results[1]));
            ThueGTGT = ((int)(results[2]));
            PhiBVMT = ((int)(results[3]));
            TongCong = ((int)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void tinhCodeTieuThu_TieuThuAsync(string DocSoID, string Code, int TieuThu) {
            this.tinhCodeTieuThu_TieuThuAsync(DocSoID, Code, TieuThu, null);
        }
        
        /// <remarks/>
        public void tinhCodeTieuThu_TieuThuAsync(string DocSoID, string Code, int TieuThu, object userState) {
            if ((this.tinhCodeTieuThu_TieuThuOperationCompleted == null)) {
                this.tinhCodeTieuThu_TieuThuOperationCompleted = new System.Threading.SendOrPostCallback(this.OntinhCodeTieuThu_TieuThuOperationCompleted);
            }
            this.InvokeAsync("tinhCodeTieuThu_TieuThu", new object[] {
                        DocSoID,
                        Code,
                        TieuThu}, this.tinhCodeTieuThu_TieuThuOperationCompleted, userState);
        }
        
        private void OntinhCodeTieuThu_TieuThuOperationCompleted(object arg) {
            if ((this.tinhCodeTieuThu_TieuThuCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.tinhCodeTieuThu_TieuThuCompleted(this, new tinhCodeTieuThu_TieuThuCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/tinhCodeTieuThu_CSM", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool tinhCodeTieuThu_CSM(string DocSoID, string Code, int CSM, out int TieuThu, out int GiaBan, out int ThueGTGT, out int PhiBVMT, out int TongCong) {
            object[] results = this.Invoke("tinhCodeTieuThu_CSM", new object[] {
                        DocSoID,
                        Code,
                        CSM});
            TieuThu = ((int)(results[1]));
            GiaBan = ((int)(results[2]));
            ThueGTGT = ((int)(results[3]));
            PhiBVMT = ((int)(results[4]));
            TongCong = ((int)(results[5]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void tinhCodeTieuThu_CSMAsync(string DocSoID, string Code, int CSM) {
            this.tinhCodeTieuThu_CSMAsync(DocSoID, Code, CSM, null);
        }
        
        /// <remarks/>
        public void tinhCodeTieuThu_CSMAsync(string DocSoID, string Code, int CSM, object userState) {
            if ((this.tinhCodeTieuThu_CSMOperationCompleted == null)) {
                this.tinhCodeTieuThu_CSMOperationCompleted = new System.Threading.SendOrPostCallback(this.OntinhCodeTieuThu_CSMOperationCompleted);
            }
            this.InvokeAsync("tinhCodeTieuThu_CSM", new object[] {
                        DocSoID,
                        Code,
                        CSM}, this.tinhCodeTieuThu_CSMOperationCompleted, userState);
        }
        
        private void OntinhCodeTieuThu_CSMOperationCompleted(object arg) {
            if ((this.tinhCodeTieuThu_CSMCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.tinhCodeTieuThu_CSMCompleted(this, new tinhCodeTieuThu_CSMCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void insertBillingCompletedEventHandler(object sender, insertBillingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class insertBillingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal insertBillingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string message {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void tinhCodeTieuThu_TieuThuCompletedEventHandler(object sender, tinhCodeTieuThu_TieuThuCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class tinhCodeTieuThu_TieuThuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal tinhCodeTieuThu_TieuThuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public int GiaBan {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public int ThueGTGT {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public int PhiBVMT {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public int TongCong {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void tinhCodeTieuThu_CSMCompletedEventHandler(object sender, tinhCodeTieuThu_CSMCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class tinhCodeTieuThu_CSMCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal tinhCodeTieuThu_CSMCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public int TieuThu {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public int GiaBan {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public int ThueGTGT {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public int PhiBVMT {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[4]));
            }
        }
        
        /// <remarks/>
        public int TongCong {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[5]));
            }
        }
    }
}

#pragma warning restore 1591