Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data

Public Class Category
	Private privateCategoryID As Integer
	Public Property CategoryID() As Integer
		Get
			Return privateCategoryID
		End Get
		Set(ByVal value As Integer)
			privateCategoryID = value
		End Set
	End Property

	Private privateCategoryName As String
	Public Property CategoryName() As String
		Get
			Return privateCategoryName
		End Get
		Set(ByVal value As String)
			privateCategoryName = value
		End Set
	End Property

	Private privateDescription As String
	Public Property Description() As String
		Get
			Return privateDescription
		End Get
		Set(ByVal value As String)
			privateDescription = value
		End Set
	End Property

	Private privatePicture As Byte()
	Public Property Picture() As Byte()
		Get
			Return privatePicture
		End Get
		Set(ByVal value As Byte())
			privatePicture = value
		End Set
	End Property

	Private privateIcon_17 As Byte()
	Public Property Icon_17() As Byte()
		Get
			Return privateIcon_17
		End Get
		Set(ByVal value As Byte())
			privateIcon_17 = value
		End Set
	End Property

	Private privateIcon_25 As Byte()
	Public Property Icon_25() As Byte()
		Get
			Return privateIcon_25
		End Get
		Set(ByVal value As Byte())
			privateIcon_25 = value
		End Set
	End Property

	Public Shared Function GetCategories() As List(Of Category)
		Dim catData As DataTable = DataHelper.ProcessSelectCommand("SELECT * FROM [Categories]")
		If catData IsNot Nothing Then
			Dim categories As New List(Of Category)()
			For Each row As DataRow In catData.Rows
				Dim category As New Category() With {.CategoryID = CInt(Fix(row("CategoryID"))), .CategoryName = CStr(row("CategoryName")), .Description = CStr(row("Description")), .Picture = CType(row("Picture"), Byte()), .Icon_17 = CType(row("Icon_17"), Byte()), .Icon_25 = CType(row("Icon_25"), Byte())}
				categories.Add(category)
			Next row
			Return categories
		End If
		Return Nothing
	End Function
End Class