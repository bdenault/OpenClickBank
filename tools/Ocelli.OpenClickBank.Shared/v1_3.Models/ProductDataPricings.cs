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
    [System.Xml.Serialization.XmlTypeAttribute("ProductDataPricings", Namespace="", AnonymousType=true)]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProductDataPricings
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Pricing> _pricing;
        
        [System.Xml.Serialization.XmlElementAttribute("pricing")]
        public System.Collections.ObjectModel.Collection<Pricing> Pricing
        {
            get
            {
                return _pricing;
            }
            set
            {
                _pricing = value;
            }
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PricingSpecified
        {
            get
            {
                return ((this.Pricing != null) 
                            && (this.Pricing.Count != 0));
            }
        }
    }
}
