
Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ' Initialize the column to '0'.
        ColumnToSort = 0

        ' Initialize the sort order to 'none'.
        OrderOfSort = SortOrder.None

        ' Initialize the CaseInsensitiveComparer object.
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        ' Compare the two items.
        compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)

        ' Calculate the correct return value based on the object 
        ' comparison.
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return typical result of 
            ' compare operation.
            Return compareResult
        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of 
            ' compare operation.
            Return (-compareResult)
        Else
            ' Return '0' to indicate that they are equal.
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property
End Class
' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
    End Function
End Class