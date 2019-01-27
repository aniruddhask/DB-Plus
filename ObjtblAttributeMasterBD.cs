using System;
namespace Centrum.BD
{
    /// <summary>
    /// Summary Description for ObjtblAttributeMasterBD
    /// </summary>
    public class ObjtblAttributeMasterBD
    {
        private System.String _strAttributeId;
        private System.String _strName;
        private System.String _strAttributeTypeId;
        private System.String _strDescription;
        private System.String _strDisplayTo = "";
        private System.Boolean _blIsSearchable;
        private System.Boolean _blIsPredefined;
        private System.Boolean _blStatus;
        private System.DateTime _dTimeCreatedDateTime = DateTime.Now;
        private System.String _strCreatedByUserId;
        private System.DateTime _dTimeLastModifiedDateTime = DateTime.Now;
        private System.String _strModifiedByUserId;
        public ObjtblAttributeMasterBD()
        { }
        public ObjtblAttributeMasterBD(System.String AttributeId, System.String Name, System.String AttributeTypeId, System.String Description, System.String DisplayTo, System.Boolean IsSearchable, System.Boolean IsPredefined, System.Boolean Status, System.DateTime CreatedDateTime, System.String CreatedByUserId, System.DateTime LastModifiedDateTime, System.String ModifiedByUserId)
        {
            _strAttributeId = AttributeId;
            _strName = Name;
            _strAttributeTypeId = AttributeTypeId;
            _strDescription = Description;
            _strDisplayTo = DisplayTo;
            _blIsSearchable = IsSearchable;
            _blIsPredefined = IsPredefined;
            _blStatus = Status;
            _dTimeCreatedDateTime = CreatedDateTime;
            _strCreatedByUserId = CreatedByUserId;
            _dTimeLastModifiedDateTime = LastModifiedDateTime;
            _strModifiedByUserId = ModifiedByUserId;
        }
        /// <summary>
        /// This is Properties For AttributeId;
        /// </summary>
        public System.String AttributeId
        {
            set
            {
                _strAttributeId = value;
            }
            get
            {
                return _strAttributeId;
            }
        }
        /// <summary>
        /// This is Properties For Name;
        /// </summary>
        public System.String Name
        {
            set
            {
                _strName = value;
            }
            get
            {
                return _strName;
            }
        }
        /// <summary>
        /// This is Properties For AttributeTypeId;
        /// </summary>
        public System.String AttributeTypeId
        {
            set
            {
                _strAttributeTypeId = value;
            }
            get
            {
                return _strAttributeTypeId;
            }
        }
        /// <summary>
        /// This is Properties For Description;
        /// </summary>
        public System.String Description
        {
            set
            {
                _strDescription = value;
            }
            get
            {
                return _strDescription;
            }
        }
        /// <summary>
        /// This is Properties For DisplayTo;
        /// </summary>
        public System.String DisplayTo
        {
            set
            {
                _strDisplayTo = value;
            }
            get
            {
                return _strDisplayTo;
            }
        }
        /// <summary>
        /// This is Properties For IsSearchable;
        /// </summary>
        public System.Boolean IsSearchable
        {
            set
            {
                _blIsSearchable = value;
            }
            get
            {
                return _blIsSearchable;
            }
        }
        /// <summary>
        /// This is Properties For IsPredefined;
        /// </summary>
        public System.Boolean IsPredefined
        {
            set
            {
                _blIsPredefined = value;
            }
            get
            {
                return _blIsPredefined;
            }
        }
        /// <summary>
        /// This is Properties For Status;
        /// </summary>
        public System.Boolean Status
        {
            set
            {
                _blStatus = value;
            }
            get
            {
                return _blStatus;
            }
        }
        /// <summary>
        /// This is Properties For CreatedDateTime;
        /// </summary>
        public System.DateTime CreatedDateTime
        {
            set
            {
                _dTimeCreatedDateTime = value;
            }
            get
            {
                return _dTimeCreatedDateTime;
            }
        }
        /// <summary>
        /// This is Properties For CreatedByUserId;
        /// </summary>
        public System.String CreatedByUserId
        {
            set
            {
                _strCreatedByUserId = value;
            }
            get
            {
                return _strCreatedByUserId;
            }
        }
        /// <summary>
        /// This is Properties For LastModifiedDateTime;
        /// </summary>
        public System.DateTime LastModifiedDateTime
        {
            set
            {
                _dTimeLastModifiedDateTime = value;
            }
            get
            {
                return _dTimeLastModifiedDateTime;
            }
        }
        /// <summary>
        /// This is Properties For ModifiedByUserId;
        /// </summary>
        public System.String ModifiedByUserId
        {
            set
            {
                _strModifiedByUserId = value;
            }
            get
            {
                return _strModifiedByUserId;
            }
        }
    }//Class Close
}//NameSpace Close
