using System;
namespace Centrum.BD
{
	/// <summary>
	/// Summary Description for ObjtblAttributeTypeMasterBD
	/// </summary>
	public class ObjtblAttributeTypeMasterBD
	{
		private System.String _strAttributeTypeId;
		private System.String _strName;
		private System.String _strTypeOf;
		private System.Boolean _blStatus;
		private System.DateTime _dTimeCreatedDateTime = DateTime.Now;
		private System.String _strCreatedByUserId;
		private System.DateTime _dTimeLastModifiedDateTime = DateTime.Now;
		private System.String _strModifiedByUserId;
		public ObjtblAttributeTypeMasterBD()
		{}
		public ObjtblAttributeTypeMasterBD(System.String AttributeTypeId, System.String Name, System.String TypeOf, System.Boolean Status, System.DateTime CreatedDateTime, System.String CreatedByUserId, System.DateTime LastModifiedDateTime, System.String ModifiedByUserId)
		{
			_strAttributeTypeId = AttributeTypeId;
			_strName = Name;
			_strTypeOf = TypeOf;
			_blStatus = Status;
			_dTimeCreatedDateTime = CreatedDateTime;
			_strCreatedByUserId = CreatedByUserId;
			_dTimeLastModifiedDateTime = LastModifiedDateTime;
			_strModifiedByUserId = ModifiedByUserId;
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
		/// This is Properties For TypeOf;
		/// </summary>
		public System.String TypeOf
		{
			set
			{
				_strTypeOf = value;
			}
			get
			{
				return _strTypeOf;
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
