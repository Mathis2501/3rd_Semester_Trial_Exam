﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace AuctionsService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuctionItem", Namespace="http://schemas.datacontract.org/2004/07/WCF_AuctionWebApplication")]
    public partial class AuctionItem : object
    {
        
        private string BidCustomNameField;
        
        private string BidCustomPhoneField;
        
        private int BidPriceField;
        
        private System.DateTime BidTimestampField;
        
        private string ItemDescriptionField;
        
        private int ItemNumberField;
        
        private int RatingPriceField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        [Required]
        [MinLength(4)]
        public string BidCustomName
        {
            get
            {
                return this.BidCustomNameField;
            }
            set
            {
                this.BidCustomNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        [Required]
        [RegularExpression(@"(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$", ErrorMessage = "Please enter 8 digits")]
        public string BidCustomPhone
        {
            get
            {
                return this.BidCustomPhoneField;
            }
            set
            {
                this.BidCustomPhoneField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        [Required]
        public int BidPrice
        {
            get
            {
                return this.BidPriceField;
            }
            set
            {
                this.BidPriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BidTimestamp
        {
            get
            {
                return this.BidTimestampField;
            }
            set
            {
                this.BidTimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ItemDescription
        {
            get
            {
                return this.ItemDescriptionField;
            }
            set
            {
                this.ItemDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemNumber
        {
            get
            {
                return this.ItemNumberField;
            }
            set
            {
                this.ItemNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RatingPrice
        {
            get
            {
                return this.RatingPriceField;
            }
            set
            {
                this.RatingPriceField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuctionsService.IAuctionsService")]
    public interface IAuctionsService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuctionsService/GetAllAuctionItems", ReplyAction="http://tempuri.org/IAuctionsService/GetAllAuctionItemsResponse")]
        System.Threading.Tasks.Task<AuctionsService.AuctionItem[]> GetAllAuctionItemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuctionsService/GetAuctionItem", ReplyAction="http://tempuri.org/IAuctionsService/GetAuctionItemResponse")]
        System.Threading.Tasks.Task<AuctionsService.AuctionItem> GetAuctionItemAsync(int itemNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuctionsService/CreateAuctionItem", ReplyAction="http://tempuri.org/IAuctionsService/CreateAuctionItemResponse")]
        System.Threading.Tasks.Task<string> CreateAuctionItemAsync(int itemNumber, string idemDescription, int ratingPrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuctionsService/ProvideBid", ReplyAction="http://tempuri.org/IAuctionsService/ProvideBidResponse")]
        System.Threading.Tasks.Task<string> ProvideBidAsync(int itemNumber, int bidPrice, string bidCustomName, string bidCustomPhone);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public interface IAuctionsServiceChannel : AuctionsService.IAuctionsService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public partial class AuctionsServiceClient : System.ServiceModel.ClientBase<AuctionsService.IAuctionsService>, AuctionsService.IAuctionsService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AuctionsServiceClient() : 
                base(AuctionsServiceClient.GetDefaultBinding(), AuctionsServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IAuctionsService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuctionsServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(AuctionsServiceClient.GetBindingForEndpoint(endpointConfiguration), AuctionsServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuctionsServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AuctionsServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuctionsServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AuctionsServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AuctionsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<AuctionsService.AuctionItem[]> GetAllAuctionItemsAsync()
        {
            return base.Channel.GetAllAuctionItemsAsync();
        }
        
        public System.Threading.Tasks.Task<AuctionsService.AuctionItem> GetAuctionItemAsync(int itemNumber)
        {
            return base.Channel.GetAuctionItemAsync(itemNumber);
        }
        
        public System.Threading.Tasks.Task<string> CreateAuctionItemAsync(int itemNumber, string idemDescription, int ratingPrice)
        {
            return base.Channel.CreateAuctionItemAsync(itemNumber, idemDescription, ratingPrice);
        }
        
        public System.Threading.Tasks.Task<string> ProvideBidAsync(int itemNumber, int bidPrice, string bidCustomName, string bidCustomPhone)
        {
            return base.Channel.ProvideBidAsync(itemNumber, bidPrice, bidCustomName, bidCustomPhone);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAuctionsService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAuctionsService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:1559/AuctionsService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AuctionsServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IAuctionsService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AuctionsServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IAuctionsService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IAuctionsService,
        }
    }
}
