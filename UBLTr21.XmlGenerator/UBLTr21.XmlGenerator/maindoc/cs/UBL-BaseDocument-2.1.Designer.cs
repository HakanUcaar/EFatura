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

    [System.CodeDom.Compiler.GeneratedCodeAttribute("ublxsd", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:BaseDocument-2")]
    [System.Xml.Serialization.XmlRootAttribute("UblBaseDocument", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:BaseDocument-2", IsNullable = false)]
    public abstract partial class UblBaseDocumentType
    {
        #region private
        private List<UBLExtensionType> _uBLExtensions;

        private UBLVersionIDType _uBLVersionID;

        private CustomizationIDType _customizationID;

        private ProfileIDType _profileID;        
        #endregion

        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        [System.Xml.Serialization.XmlArrayItemAttribute("UBLExtension", IsNullable = false)]
        public List<UBLExtensionType> UBLExtensions
        {
            get
            {
                return this._uBLExtensions;
            }
            set
            {
                this._uBLExtensions = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public UBLVersionIDType UBLVersionID
        {
            get
            {
                return this._uBLVersionID;
            }
            set
            {
                this._uBLVersionID = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CustomizationIDType CustomizationID
        {
            get
            {
                return this._customizationID;
            }
            set
            {
                this._customizationID = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ProfileIDType ProfileID
        {
            get
            {
                return this._profileID;
            }
            set
            {
                this._profileID = value;
            }
        }
    }
    public abstract partial class UblBaseDocumentType
    {
        /// <summary>
        /// Variable holding the default UBL version given to all documents in their base class constructor. Default is "2.0". 
        /// This library is Generated for "2.0" only, so don't change it.
        /// </summary>
        public static string GlbUblVersionID = "2.0";

        /// <summary>
        /// Default value given to all UBL documents in their base class constructor. Default is null. 
        /// UBL Larsen can't guess what should go in here. Depends on region/business etc.
        /// </summary>
        public static string GlbCustomizationID = null;

        /// <summary>
        /// Default value given to all UBL documents in their base constructor. Default is null. Consult UBL documentation.
        /// Example: Basic billing is "urn:www.nesubl.eu:profiles:profile5:ver1.0"
        /// More samples at http://www.oioubl.info/Codelists/en/urn_oioubl_id_profileid-1.1.html
        /// </summary>
        public static string GlbProfileID = null;

        /// <summary>
        /// UBL Base class constructor. Gets called by all UBL maindoc's when they are constructed.
        /// </summary>
        public UblBaseDocumentType()
        {
            this._profileID = new ProfileIDType();
            this._customizationID = new CustomizationIDType();
            this._uBLVersionID = new UBLVersionIDType();
            this._uBLExtensions = new List<UBLExtensionType>();
            this.UBLVersionID.Value = GlbUblVersionID;
            this.CustomizationID.Value = GlbCustomizationID;
            this.ProfileID.Value = GlbProfileID;
        }

        /// <summary>
        /// Takes care of namespace prefix in saved xml documents
        /// </summary>
        [System.Xml.Serialization.XmlNamespaceDeclarations()]
        public XmlSerializerNamespaces Xmlns
        {
            get
            {
                return new XmlSerializerNamespaces(
                    new XmlQualifiedName[] 
                        {
                            new XmlQualifiedName("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"),
                            new XmlQualifiedName("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"),
                            new XmlQualifiedName("n4", "http://www.altova.com/samplexml/other-namespace"),
                            //new XmlQualifiedName("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"),
                            new XmlQualifiedName("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"),
                            //new XmlQualifiedName("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"),
                            //new XmlQualifiedName("", (this.GetType().GetCustomAttributes(typeof(XmlTypeAttribute), false).FirstOrDefault() as XmlTypeAttribute).Namespace)
                        });
            }
            set { }
        }
    }
    
}
#pragma warning restore
