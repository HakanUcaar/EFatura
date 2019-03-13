// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.4.0.7
//    <NameSpace>UblTr</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><DataMemberNameArg>OnlyIfDifferent</DataMemberNameArg><DataMemberOnXmlIgnore>False</DataMemberOnXmlIgnore><CodeBaseTag>Net45</CodeBaseTag><InitializeFields>All</InitializeFields><GenerateUnusedComplexTypes>False</GenerateUnusedComplexTypes><GenerateUnusedSimpleTypes>False</GenerateUnusedSimpleTypes><GenerateXMLAttributes>True</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableLazyLoading>False</EnableLazyLoading><VirtualProp>False</VirtualProp><PascalCase>False</PascalCase><AutomaticProperties>False</AutomaticProperties><PropNameSpecified>None</PropNameSpecified><PrivateFieldName>StartWithUnderscore</PrivateFieldName><PrivateFieldNamePrefix></PrivateFieldNamePrefix><EnableRestriction>False</EnableRestriction><RestrictionMaxLenght>False</RestrictionMaxLenght><RestrictionRegEx>False</RestrictionRegEx><RestrictionRange>False</RestrictionRange><ValidateProperty>False</ValidateProperty><ClassNamePrefix></ClassNamePrefix><ClassLevel>Public</ClassLevel><PartialClass>True</PartialClass><ClassesInSeparateFiles>False</ClassesInSeparateFiles><ClassesInSeparateFilesDir></ClassesInSeparateFilesDir><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><EnableAppInfoSettings>False</EnableAppInfoSettings><EnableExternalSchemasCache>False</EnableExternalSchemasCache><EnableDebug>False</EnableDebug><EnableWarn>False</EnableWarn><ExcludeImportedTypes>False</ExcludeImportedTypes><ExpandNesteadAttributeGroup>False</ExpandNesteadAttributeGroup><CleanupCode>False</CleanupCode><EnableXmlSerialization>False</EnableXmlSerialization><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><EnableEncoding>False</EnableEncoding><EnableXMLIndent>False</EnableXMLIndent><IndentChar>Indent2Space</IndentChar><NewLineAttr>False</NewLineAttr><OmitXML>False</OmitXML><Encoder>UTF8</Encoder><Serializer>XmlSerializer</Serializer><sspNullable>False</sspNullable><sspString>False</sspString><sspCollection>False</sspCollection><sspComplexType>False</sspComplexType><sspSimpleType>False</sspSimpleType><sspEnumType>False</sspEnumType><XmlSerializerEvent>False</XmlSerializerEvent><BaseClassName>EntityBase</BaseClassName><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><CustomUsings></CustomUsings><AttributesToExlude></AttributesToExlude>
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace UblTr
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Xml;
    using System.Collections.Generic;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class BinaryObjectType
    {

        #region Private fields
        private string _format;

        private string _mimeCode;

        private string _encodingCode;

        private string _characterSetCode;

        private string _uri;

        private string _filename;

        private byte[] _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string format
        {
            get
            {
                return this._format;
            }
            set
            {
                this._format = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string mimeCode
        {
            get
            {
                return this._mimeCode;
            }
            set
            {
                this._mimeCode = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string encodingCode
        {
            get
            {
                return this._encodingCode;
            }
            set
            {
                this._encodingCode = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string characterSetCode
        {
            get
            {
                return this._characterSetCode;
            }
            set
            {
                this._characterSetCode = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string uri
        {
            get
            {
                return this._uri;
            }
            set
            {
                this._uri = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string filename
        {
            get
            {
                return this._filename;
            }
            set
            {
                this._filename = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class TextType
    {

        #region Private fields
        private string _languageID;

        private string _languageLocaleID;

        private string _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
        public string languageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                this._languageID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string languageLocaleID
        {
            get
            {
                return this._languageLocaleID;
            }
            set
            {
                this._languageLocaleID = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class CodeType
    {

        #region Private fields
        private string _listID;

        private string _listAgencyID;

        private string _listAgencyName;

        private string _listName;

        private string _listVersionID;

        private string _name;

        private string _languageID;

        private string _listURI;

        private string _listSchemeURI;

        private string _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string listID
        {
            get
            {
                return this._listID;
            }
            set
            {
                this._listID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string listAgencyID
        {
            get
            {
                return this._listAgencyID;
            }
            set
            {
                this._listAgencyID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string listAgencyName
        {
            get
            {
                return this._listAgencyName;
            }
            set
            {
                this._listAgencyName = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string listName
        {
            get
            {
                return this._listName;
            }
            set
            {
                this._listName = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string listVersionID
        {
            get
            {
                return this._listVersionID;
            }
            set
            {
                this._listVersionID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "language")]
        public string languageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                this._languageID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string listURI
        {
            get
            {
                return this._listURI;
            }
            set
            {
                this._listURI = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string listSchemeURI
        {
            get
            {
                return this._listSchemeURI;
            }
            set
            {
                this._listSchemeURI = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "normalizedString")]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class IdentifierType
    {

        #region Private fields
        private string _schemeID;

        private string _schemeName;

        private string _schemeAgencyID;

        private string _schemeAgencyName;

        private string _schemeVersionID;

        private string _schemeDataURI;

        private string _schemeURI;

        private string _value;
        #endregion

        public static implicit operator IdentifierType(System.String value)
        {
            return string.IsNullOrEmpty(value) ? null : new IdentifierType { Value = value };
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeID
        {
            get
            {
                return this._schemeID;
            }
            set
            {
                this._schemeID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeName
        {
            get
            {
                return this._schemeName;
            }
            set
            {
                this._schemeName = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeAgencyID
        {
            get
            {
                return this._schemeAgencyID;
            }
            set
            {
                this._schemeAgencyID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeAgencyName
        {
            get
            {
                return this._schemeAgencyName;
            }
            set
            {
                this._schemeAgencyName = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeVersionID
        {
            get
            {
                return this._schemeVersionID;
            }
            set
            {
                this._schemeVersionID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeDataURI
        {
            get
            {
                return this._schemeDataURI;
            }
            set
            {
                this._schemeDataURI = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeURI
        {
            get
            {
                return this._schemeURI;
            }
            set
            {
                this._schemeURI = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute(DataType = "normalizedString")]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class QuantityType
    {

        #region Private fields
        private string _unitCode;

        private string _unitCodeListID;

        private string _unitCodeListAgencyID;

        private string _unitCodeListAgencyName;

        private decimal _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string unitCode
        {
            get
            {
                return this._unitCode;
            }
            set
            {
                this._unitCode = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string unitCodeListID
        {
            get
            {
                return this._unitCodeListID;
            }
            set
            {
                this._unitCodeListID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string unitCodeListAgencyID
        {
            get
            {
                return this._unitCodeListAgencyID;
            }
            set
            {
                this._unitCodeListAgencyID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitCodeListAgencyName
        {
            get
            {
                return this._unitCodeListAgencyName;
            }
            set
            {
                this._unitCodeListAgencyName = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class AmountType
    {

        #region Private fields
        private string _currencyID;

        private string _currencyCodeListVersionID;

        private decimal _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string currencyID
        {
            get
            {
                return this._currencyID;
            }
            set
            {
                this._currencyID = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string currencyCodeListVersionID
        {
            get
            {
                return this._currencyCodeListVersionID;
            }
            set
            {
                this._currencyCodeListVersionID = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class NumericType
    {

        #region Private fields
        private string _format;

        private decimal _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string format
        {
            get
            {
                return this._format;
            }
            set
            {
                this._format = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class MeasureType
    {

        #region Private fields
        private string _unitCode;

        private string _unitCodeListVersionID;

        private decimal _value;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string unitCode
        {
            get
            {
                return this._unitCode;
            }
            set
            {
                this._unitCode = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "normalizedString")]
        public string unitCodeListVersionID
        {
            get
            {
                return this._unitCodeListVersionID;
            }
            set
            {
                this._unitCodeListVersionID = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
    
}
#pragma warning restore
