
Imports System
Imports System.Data
Imports DataAccessLayer.DataAccessLayer
Imports System.Collections

Namespace BusinessLayer
    ''' <summary>
    ''' Summary description for Record.
    ''' </summary>
    Public MustInherit Class IRecord
        Protected _isNew As Boolean = False
        Protected _isDirty As Boolean = False
        Protected _isDeleted As Boolean = False

        Protected mStatus As StatusEnum.rStatus
        'This variable is used to store the result data
        Protected _table As New DataTable()
        'This variables are used for the properties for holding the created and modified details
        Protected _intCreatedBy As Integer
        Protected _dtCreatedOn As DateTime
        Protected _intModifiedBy As Integer
        Protected _dtModifiedOn As DateTime

        Protected _criteria As New Criteria()

#Region "Contructors"
        Public Sub New()
        End Sub
#End Region

#Region "Enumerations"
        Public Enum SqlDataForDB
            CreatedBy = System.Data.SqlDbType.Int
            CreatedOn = System.Data.SqlDbType.DateTime
            ModifiedBy = System.Data.SqlDbType.Int
            ModifiedOn = System.Data.SqlDbType.DateTime
        End Enum
        Public Enum SqlSizeForDB
            CreatedBy = 4
            CreatedOn = 8
            ModifiedBy = 4
            ModifiedOn = 8
        End Enum
#End Region

#Region "Properties"
        ' These methods have been added to hold the 
        '		 * created and modified data 
        '		 * which are used for all the business entities


        ''' <summary>
        ''' Gets and sets the <c>CreatedBy</c>
        ''' </summary>
        ''' <value>The <c>CreatedBy</c> column value</value>
        Public Property CreatedBy() As Integer
            Get
                Return _intCreatedBy
            End Get
            Set(value As Integer)
                _intCreatedBy = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>CreatedOn</c>
        ''' </summary>
        ''' <value>The <c>CreatedOn</c> column value</value>
        Public Property CreatedOn() As DateTime
            Get
                Return _dtCreatedOn
            End Get
            Set(value As DateTime)
                _dtCreatedOn = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>ModifiedBy</c>
        ''' </summary>
        ''' <value>The <c>ModifiedBy</c> column value</value>
        Public Property ModifiedBy() As Integer
            Get
                Return _intModifiedBy
            End Get
            Set(value As Integer)
                _intModifiedBy = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>ModifiedOn</c>
        ''' </summary>
        ''' <value>The <c>ModifiedOn</c> column value</value>
        Public Property ModifiedOn() As DateTime
            Get
                Return _dtModifiedOn
            End Get
            Set(value As DateTime)
                _dtModifiedOn = value
            End Set
        End Property
#End Region

#Region "Save"
        Public Save()
#End Region

#Region "Load"
        ''' <summary>
        ''' Loads and populates the record for the selected criteria.
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns>Returns true, if the loading of record is successful</returns>
        Public Overridable Function Load(criteria As Criteria) As Boolean
            Try
                Dim dataAccess As New DALDataAccess
                Dim type As Type = Me.[GetType]()
                Dim recordAttribute As RecordAttribute = DirectCast(Attribute.GetCustomAttribute(type, GetType(RecordAttribute)), RecordAttribute)
                Dim storedProc As String = recordAttribute.StoredProcLoad

                dataAccess.AddCommand(CommandType.StoredProcedure, storedProc)
                dataAccess.AddParam("@vWhere", SqlDbType.VarChar, criteria.Where)

                Dim dataSet As DataSet = dataAccess.GetDataset()
                If dataSet.Tables.Count > 0 Then
                    Me._table = dataSet.Tables(0)
                End If

                'Set the PrimaryKey column
                Dim pKeys As ArrayList = recordAttribute.PrimaryKeys
                Dim pkColumns As DataColumn() = New DataColumn(pKeys.Count - 1) {}
                Dim iCount As Integer = 0
                For Each pKey As String In pKeys
                    pkColumns(iCount) = Me._table.Columns(pKey)
                    iCount += 1
                Next

                Me._table.PrimaryKey = pkColumns

                Return True
            Catch ex As Exception
                Throw
            Finally
            End Try
        End Function
#End Region

#Region "Delete"
        ''' <summary>
        ''' Delete record for selected criteria
        ''' </summary>
        Public Overridable Sub Delete()
            Try
                Dim dataAccess As New DALDataAccess()
                Dim type As Type = Me.[GetType]()
                Dim recordAttribute As RecordAttribute = DirectCast(Attribute.GetCustomAttribute(type, GetType(RecordAttribute)), RecordAttribute)
                Dim storedProc As String = recordAttribute.StoredProcDelete

                dataAccess.AddCommand(CommandType.StoredProcedure, storedProc)
                dataAccess.AddParam("@tableName", SqlDbType.VarChar, recordAttribute.TableName)
                dataAccess.AddParam("@vWhere", SqlDbType.VarChar, _criteria.Where)
                dataAccess.ExecuteNonQuery()
                _isDeleted = True
            Catch generatedExceptionName As Exception
                _isDeleted = False
                Throw
            Finally
            End Try
        End Sub
#End Region

#Region "Populate Records"
        Public Overridable Sub PopulateRecord(row As DataRow)
        End Sub
#End Region

#Region "Methods to validate entry to Parameters"
        Public Function ParamDateTime(val As DateTime) As Object
            If val = DateTime.MinValue Then
                Return DBNull.Value
            Else
                Return val
            End If
        End Function

        Public Function ParamInt(val As Integer) As Object
            If val = Integer.MinValue Then
                Return DBNull.Value
            Else
                Return val
            End If
        End Function

        Public Function ParamString(val As String) As Object
            If val = String.Empty Then
                Return DBNull.Value
            Else
                Return val
            End If
        End Function

#End Region

#Region "Methods to validate values retrieved from Database"
        Public Function ValidateDateTime(val As Object) As DateTime
            Dim retVal As DateTime

            If val = Nothing Then
                retVal = DateTime.MinValue
            Else
                retVal = Convert.ToDateTime(val)
            End If

            Return retVal
        End Function

        Public Function ValidateInt(val As Object) As Integer
            Dim retVal As Integer

            If val = Nothing Then
                retVal = Integer.MinValue
            Else
                retVal = Convert.ToInt32(val)
            End If

            Return retVal
        End Function

        Public Function ValidateSmallInt(val As Object) As Int16
            Dim retVal As Int16

            If val = Nothing Then
                retVal = Int16.MinValue
            Else
                retVal = Convert.ToInt16(val)
            End If

            Return retVal
        End Function

        Public Function ValidateChar(val As Object) As Char
            Dim retVal As Char

            If val = Nothing Then
                retVal = Char.MinValue
            Else
                retVal = Convert.ToChar(val)
            End If

            Return retVal
        End Function

        Public Function ValidateString(val As Object) As String
            Dim retVal As String

            If val = Nothing Then
                retVal = String.Empty
            Else
                retVal = Convert.ToString(val)
            End If

            Return retVal
        End Function

        Public Function ValidateDecimal(val As Object) As Decimal
            Dim retVal As Decimal

            If val = Nothing Then
                retVal = [Decimal].MinValue
            Else
                retVal = Convert.ToDecimal(val)
            End If

            Return retVal
        End Function

        Public Function ValidateFloat(val As Object) As Single
            Dim retVal As Single

            If val = Nothing Then
                retVal = Single.MinValue
            Else

                retVal = Convert.ToSingle(val)
            End If

            Return retVal
        End Function

#End Region

#Region "Property Procedures"
        ''' <summary>
        ''' Gets and sets the <c>IsNew</c>
        ''' </summary>
        ''' <value>The <c>IsNew</c> column value</value>
        Public Property IsNew() As Boolean
            Get
                Return _isNew
            End Get
            Set(value As Boolean)
                _isNew = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>IsDirty</c>
        ''' </summary>
        ''' <value>The <c>IsDirty</c> column value</value>
        Public Property IsDirty() As Boolean
            Get
                Return _isDirty
            End Get
            Set(value As Boolean)
                _isDirty = value
            End Set
        End Property

        ''' <summary>
        ''' Gets the <c>IsDeleted</c>
        ''' </summary>
        ''' <value>The <c>IsDeleted</c> column value</value>
        Public ReadOnly Property IsDeleted() As Boolean
            Get
                Return _isDeleted
            End Get
        End Property

        ''' <summary>
        ''' Gets and sets the <c>RecordStatus</c>
        ''' </summary>
        ''' <value>The <c>RecordStatus</c> column value</value>
        Public Property RecordStatus() As StatusEnum.rStatus
            Get
                Return mStatus
            End Get
            Set(value As StatusEnum.rStatus)
                _isDirty = True
                mStatus = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the <c>Table</c>
        ''' </summary>
        ''' <value>The <c>Table</c> column value</value>
        Public Property Table() As DataTable
            Get
                Return Me._table
            End Get
            Set(value As DataTable)
                Me._table = value
            End Set
        End Property
#End Region

    End Class
End Namespace
