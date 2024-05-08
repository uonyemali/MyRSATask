
Imports System.Data.Entity
Imports System.Linq

Public Class Repository(Of T As Class)
    Implements IRepository(Of T)

    Private ReadOnly _context As WeatherForecasterContext
    Private ReadOnly _set As DbSet(Of T)

    Public Sub New(context As WeatherForecasterContext)
        _context = context
        _set = context.Set(Of T)()
    End Sub

    Public Sub Add(entity As T) Implements IRepository(Of T).Add
        _set.Add(entity)
    End Sub

    Public Sub Delete(entity As T) Implements IRepository(Of T).Delete
        _set.Remove(entity)
    End Sub

    Public Function GetAll() As IQueryable(Of T) Implements IRepository(Of T).GetAll
        Return _set
    End Function

    Public Sub SaveChanges() Implements IRepository(Of T).SaveChanges
        _context.SaveChanges()
    End Sub

    Public Sub Update(entity As T) Implements IRepository(Of T).Update
        _context.Entry(entity).State = EntityState.Modified
    End Sub
End Class
