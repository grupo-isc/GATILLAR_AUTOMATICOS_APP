﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gatillar_automaticos_ec.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://schemas.datacontract.org/2004/07/Dispatch_Services")]
    [System.SerializableAttribute()]
    public partial class Response : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string mensajeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int codigo {
            get {
                return this.codigoField;
            }
            set {
                if ((this.codigoField.Equals(value) != true)) {
                    this.codigoField = value;
                    this.RaisePropertyChanged("codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string mensaje {
            get {
                return this.mensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.mensajeField, value) != true)) {
                    this.mensajeField = value;
                    this.RaisePropertyChanged("mensaje");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServiceDispatch")]
    public interface IServiceDispatch {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatch/dispatch", ReplyAction="http://tempuri.org/IServiceDispatch/dispatchResponse")]
        gatillar_automaticos_ec.ServiceReference1.Response dispatch(int idEnvio, int tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatch/dispatch", ReplyAction="http://tempuri.org/IServiceDispatch/dispatchResponse")]
        System.Threading.Tasks.Task<gatillar_automaticos_ec.ServiceReference1.Response> dispatchAsync(int idEnvio, int tipo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDispatchChannel : gatillar_automaticos_ec.ServiceReference1.IServiceDispatch, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDispatchClient : System.ServiceModel.ClientBase<gatillar_automaticos_ec.ServiceReference1.IServiceDispatch>, gatillar_automaticos_ec.ServiceReference1.IServiceDispatch {
        
        public ServiceDispatchClient() {
        }
        
        public ServiceDispatchClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDispatchClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDispatchClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDispatchClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public gatillar_automaticos_ec.ServiceReference1.Response dispatch(int idEnvio, int tipo) {
            return base.Channel.dispatch(idEnvio, tipo);
        }
        
        public System.Threading.Tasks.Task<gatillar_automaticos_ec.ServiceReference1.Response> dispatchAsync(int idEnvio, int tipo) {
            return base.Channel.dispatchAsync(idEnvio, tipo);
        }
    }
}
