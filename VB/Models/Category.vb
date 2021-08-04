Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data

Public Class Category
	Public Property CategoryID() As Integer

	Public Property CategoryName() As String

	Public Property Description() As String

	Public Property Picture() As Byte()

	Public Property Icon_17() As Byte()

	Public Property Icon_25() As Byte()

	Public Shared Function GetCategories() As List(Of Category)
		Dim catData As DataTable = DataHelper.ProcessSelectCommand("SELECT * FROM [Categories]")
		If catData IsNot Nothing Then
			Dim categories As New List(Of Category)()
			For Each row As DataRow In catData.Rows
'INSTANT VB NOTE: The variable category was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
				Dim category_Renamed As New Category() With {
					.CategoryID = DirectCast(row("CategoryID"), Integer),
					.CategoryName = DirectCast(row("CategoryName"), String),
					.Description = DirectCast(row("Description"), String),
					.Picture = DirectCast(row("Picture"), Byte()),
					.Icon_17 = DirectCast(row("Icon_17"), Byte()),
					.Icon_25 = DirectCast(row("Icon_25"), Byte())
				}
				categories.Add(category_Renamed)
			Next row
			Return categories
		End If
		Return Nothing
	End Function
End Class
