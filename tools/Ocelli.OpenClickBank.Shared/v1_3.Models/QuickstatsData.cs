//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.864.0
namespace v1_3.Models
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.864.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("quickstatsData", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("quickstatsData", Namespace="")]
    public partial class QuickstatsData
    {
        
        [System.Xml.Serialization.XmlElementAttribute("quickStatDate", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, DataType="dateTime")]
        public System.Nullable<System.DateTime> QuickStatDate { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("sale", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> Sale { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("refund", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> Refund { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("chargeback", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> Chargeback { get; set; }
    }
}
